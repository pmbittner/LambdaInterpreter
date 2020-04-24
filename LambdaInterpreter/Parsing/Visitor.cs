using System;
using Antlr;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LambdaInterpreter.model;

namespace LambdaInterpreter.Interpreter
{
    public class Visitor : LambdaParserBaseVisitor<Term>
    {
        DebugPrint debug;

        public Visitor()
        {
            debug = new DebugPrint();
            debug.Enabled = false;
        }

        protected override Term AggregateResult(Term aggregate, Term nextResult)
        {
            if (aggregate != null)
            {
                if (nextResult != null)
                {
                    return new Application(aggregate, nextResult);
                }

                return aggregate;
            }

            return nextResult;
        }

        public override Term VisitTerm([NotNull] LambdaParser.TermContext context)
        {
            debug.Print("[VisitTerm] START");
            debug.IncIndent();
            if (context.ChildCount == 1)
            {
                debug.Print("SINGLE CHILD");
                Term t = base.VisitTerm(context);
                debug.Print(t.ToString());
                
                debug.DecIndent();
                debug.Print("[VisitTerm] END");
                return t;
            }
            debug.Print("MULIPLE CHILDREN");
            
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
                    debug.Print("set left = " + term);
                    application.Left = term;
                }
                else 
                {
                    debug.Print("set right = " + term);
                    application.Right = term;

                    // if not last child
                    if (i < context.ChildCount - 1)
                    {
                        debug.Print("restructure");
                        Application next = new Application();
                        next.Left = application;
                        application = next;
                    }
                }
            }
            debug.Print("multi = " + application);
            debug.DecIndent();
            debug.Print("[VisitTerm] END");

            return application;
        }

        public override Term VisitFunction(LambdaParser.FunctionContext context)
        {
            debug.Print("[VisitFunction] START");
            debug.IncIndent();
            Function function = new Function();

            foreach (LambdaParser.VariableContext parameter in context._parameters)
            {
                function.Parameters.Add(VisitVariable(parameter) as Variable);
            }
            
            function.Body = VisitTerm(context.term());
            
            debug.Print($"{function}");
            debug.DecIndent();
            debug.Print("[VisitFunction] END");
            return function;
        }
        
        public override Term VisitVariable([NotNull] LambdaParser.VariableContext context)
        {
            debug.Print($"[VisitVariable] {context.GetText()}");
            return new Variable(context.GetText());
        }
    }
}