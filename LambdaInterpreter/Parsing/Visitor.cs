using System;
using System.Collections.Generic;
using Antlr;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LambdaInterpreter.model;

namespace LambdaInterpreter.Parsing
{
    public class Visitor : LambdaParserBaseVisitor<Term>
    {
        private Dictionary<string, Alias> Aliases { get; set; }
        
        public Visitor()
        {
            Aliases = null;
        }

        public override Term VisitProgram(LambdaParser.ProgramContext context)
        {
            Aliases = new Dictionary<string, Alias>(context._aliases.Count);
            foreach (var aliasContext in context._aliases)
            {
                Alias a = VisitAliasDefinition(aliasContext) as Alias;
                Aliases[a!.Name] = a;
            }

            foreach (KeyValuePair<string, Alias> kv in Aliases)
            {
                Alias a = kv.Value;
                a.Body = a.Body.EmbedAliases(Aliases);
            }
            
            Term res = VisitMain(context.main());
            Aliases = null;
            return res;
        }

        public override Term VisitTerm([NotNull] LambdaParser.TermContext context)
        {
            MainClass.Debug.Print("[VisitTerm] " + context.GetText());
            MainClass.Debug.IncIndent();
            if (context.ChildCount == 1)
            {
                MainClass.Debug.Print("SINGLE CHILD");
                Term t = base.VisitTerm(context);
                MainClass.Debug.Print(t.ToString());
                
                MainClass.Debug.DecIndent();
                return t;
            }
            MainClass.Debug.Print("MULIPLE CHILDREN");
            
            Application application = new Application();
            
            for (int i = 0; i < context.ChildCount; ++i)
            {
                IParseTree child = context.GetChild(i);
                Term term = child.Accept(this);

                if (term == null)
                {
                    throw new NullReferenceException();
                }
                
                if (application.Left == null)
                {
                    MainClass.Debug.Print("set left = " + term);
                    application.Left = term;
                }
                else 
                {
                    MainClass.Debug.Print("set right = " + term);
                    application.Right = term;

                    // if not last child
                    if (i < context.ChildCount - 1)
                    {
                        MainClass.Debug.Print("restructure");
                        Application next = new Application();
                        next.Left = application;
                        application = next;
                    }
                }
            }
            
            MainClass.Debug.Print("multi = " + application);
            MainClass.Debug.DecIndent();

            return application;
        }

        public override Term VisitFunction(LambdaParser.FunctionContext context)
        {
            MainClass.Debug.Print("[VisitFunction] " + context.GetText());
            MainClass.Debug.IncIndent();
            Function function = new Function();

            foreach (LambdaParser.VariableContext parameter in context._parameters)
            {
                function.Parameters.Add(VisitVariable(parameter) as Variable);
            }
            
            function.Body = VisitTerm(context.term());
            
            MainClass.Debug.Print($"{function}");
            MainClass.Debug.DecIndent();
            return function;
        }

        public override Term VisitVariable([NotNull] LambdaParser.VariableContext context)
        {
            MainClass.Debug.Print($"[VisitVariable] {context.GetText()}");
            MainClass.Debug.IncIndent();
            
            string varName = context.GetText();

            if (Aliases.TryGetValue(varName, out var alias))
            {
                MainClass.Debug.Print("is alias");
                MainClass.Debug.DecIndent();
                return alias.Clone();
            }
            
            MainClass.Debug.DecIndent();
            
            return new Variable(varName);
        }

        public override Term VisitAliasDefinition(LambdaParser.AliasDefinitionContext context)
        {
            MainClass.Debug.Print($"[VisitAliasDefinition] {context.GetText()}");
            MainClass.Debug.IncIndent();
            Alias res = new Alias(context.name.Text, VisitTerm(context.body));
            MainClass.Debug.DecIndent();
            return res;
        }
        
        protected override Term AggregateResult(Term aggregate, Term nextResult)
        {
            if (aggregate == null) return nextResult;
            if (nextResult == null)
            {
                return aggregate;
            }
            return new Application(aggregate, nextResult);

        }
    }
}