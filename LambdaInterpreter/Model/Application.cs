using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LambdaInterpreter.model
{
    public class Application : Term
    {
        public Application() : this(null, null) {}

        public Application(Term left, Term right)
        {
            Left = left;
            Right = right;
        }
        
        public Term Left { get; set; }
        public Term Right { get; set; }

        internal override void AddMyFreeVariablesTo(List<Variable> fv)
        {
            Left.AddMyFreeVariablesTo(fv);
            Right.AddMyFreeVariablesTo(fv);
        }

        public override void AlphaReduce(string oldVarName, string newVarName)
        {
            Left.AlphaReduce(oldVarName, newVarName);
            Right.AlphaReduce(oldVarName, newVarName);
        }

        public override Term Substitute(Variable prev, Term now)
        {
            // We have to clone such that the same term object won't be referenced in two places.
            // Modifications in one place of the term could lead to simultaneous modifications in other
            // parts of the term which is incorrect!
            Left = Left.Substitute(prev, now);
            Right = Right.Substitute(prev, now.Clone());
            return this;
        }
        
        internal override Term Eval(EvaluationOptions options)
        {
            if (!Array.Exists(new []{EvaluationOptions.Type.Applicative, EvaluationOptions.Type.Normative}, t => t == options.EvalType))
            {
                throw new NotImplementedException();
            }

            Left = Left.Eval(options);

            if (options.EvalType == EvaluationOptions.Type.Applicative)
            {
                Right = Right.Eval(options);
            }

            if (Left is Function f)
            {
                Left = f.BetaReduce(Right);
                Right = null;
                options.Step();
                return Left.Eval(options);
            }

            if (options.EvalType == EvaluationOptions.Type.Normative)
            {
                Right = Right.Eval(options);
            }

            return this;
        }
        
        public override Term Clone()
        {
            return new Application(Left.Clone(), Right.Clone());
        }

        public override string ToString()
        {
            return Right == null ? Left.ToString() : $"({Left} {Right})";
        }
    }
}