using System;
using System.Linq;
using Antlr;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LambdaInterpreter.model;

namespace LambdaInterpreter.Interpreter
{
    public class Visitor : LambdaParserBaseVisitor<Term>
    {
        private int indent = 0;
    
        String getIndent()
        {
            return String.Concat(Enumerable.Repeat("    ", indent));
        }

        void print(String s)
        {
            //Console.WriteLine(getIndent() + s);
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
            print("[VisitTerm] START");
            ++indent;
            if (context.ChildCount == 1)
            {
                print("SINGLE CHILD");
                Term t = base.VisitTerm(context);
                print(t.ToString());
                
                --indent;
                print("[VisitTerm] END");
                return t;
            }
            print("MULIPLE CHILDREN");
            
            Application application = new Application();
            
            for (int i = 0; i < context.ChildCount; ++i)
            {
                IParseTree child = context.GetChild(i);
                Term term = child.Accept(this);

                if (term == null)
                {
                    Console.WriteLine("TERM IS NULL AAAAAA");
                }
                
                if (application.Left == null)
                {
                    print("set left = " + term);
                    application.Left = term;
                }
                else 
                {
                    print("set right = " + term);
                    application.Right = term;

                    // if not last child
                    if (i < context.ChildCount - 1)
                    {
                        print("restructure");
                        Application next = new Application();
                        next.Left = application;
                        application = next;
                    }
                }
            }
            print("multi = " + application);
            --indent;
            print("[VisitTerm] END");

            return application;
        }

        public override Term VisitFunction(LambdaParser.FunctionContext context)
        {
            print("[VisitFunction] START");
            ++indent;
            Function function = new Function();

            foreach (LambdaParser.VariableContext parameter in context._parameters)
            {
                function.Parameters.Add(VisitVariable(parameter) as Variable);
            }
            
            function.Body = VisitTerm(context.term());
            
            print($"{function}");
            --indent;
            print("[VisitFunction] END");
            return function;
        }
        
        public override Term VisitVariable([NotNull] LambdaParser.VariableContext context)
        {
            print($"[VisitVariable] {context.GetText()}");
            return new Variable(context.GetText());
        }
    }
}