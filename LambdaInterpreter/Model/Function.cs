using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Transactions;
using Antlr4.Runtime.Misc;

namespace LambdaInterpreter.model
{
    public class Function : Term
    {
        private const String LAMBDA = "\\";
        private const String DOT = ".";
        
        public Function()
        {
            Parameters = new ArrayList<Variable>();
        }

        public Function(Function other)
        {
            Parameters = new ArrayList<Variable>(other.Parameters.Count);
            other.Parameters.ForEach(p => Parameters.Add(p.Clone() as Variable));
            Body = other.Body.Clone();
        }
        
        public List<Variable> Parameters { get; }

        public Term Body { get; set; }

        internal override void AddMyFreeVariablesTo(List<Variable> fv)
        {
            List<Variable> bodyVars = Body.GetFreeVariables();
            
            foreach (Variable p in Parameters)
            {
                bodyVars.RemoveAll(v => v.NameEquals(p));
            }
            
            fv.AddRange(bodyVars);
        }

        private void RenameParameter(Variable parameter)
        {
            string newName = Program.GenerateVariableName();
            Body.AlphaReduce(parameter.Name, newName);
            parameter.Name = newName;
        }

        public override void AlphaReduce(string oldVarName, string newVarName)
        {
            // We dont have to check for newVarName because it will always be unique.
            Parameters.
                FindAll(p => p.NameEquals(oldVarName)).
                ForEach(RenameParameter);
            Body.AlphaReduce(oldVarName, newVarName);
        }

        public Term BetaReduce(Term rhs)
        {
            Variable replaced = Parameters[0];
            Parameters.RemoveAt(0);

            if (Parameters.Exists(p => p.NameEquals(replaced)))
            {
                // There are inner parameters with the same name.
                // So nothing happens because multiple parameters are just an abbreviation for
                // successively applied functions.
                return this;
            }
            
            Body = Body.Substitute(replaced, rhs);
            
            return Parameters.Count == 0 ? Body : this;
        }

        public override Term Substitute(Variable prev, Term now)
        {
            // If prev is a free variable in Body
            if (Parameters.TrueForAll(p => !p.NameEquals(prev)))
            {
                // If one parameter is a free variable in 'now' we have alpha reduce.
                List<Variable> freeVariables = now.GetFreeVariables();

                // That means, we rename all parameters whose names equal a free variable in 'now'.
                Parameters.
                    FindAll(p => freeVariables.Exists(v => v.NameEquals(p))).
                    ForEach(RenameParameter);
                
                Body = Body.Substitute(prev, now);
            }
            
            return this;
        }

        internal override Term Eval(EvaluationOptions options)
        {
            if (options.EvalType == EvaluationOptions.Type.Applicative)
            {
                Body = Body.Eval(options);
            }

            return this;
        }

        public override Term Clone()
        {
            return new Function(this);
        }

        public override string ToString()
        {
            return $"({LAMBDA}{string.Join(' ', Parameters)}{DOT} {Body})";
        }
    }
}