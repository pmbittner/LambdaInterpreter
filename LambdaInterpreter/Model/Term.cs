using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Antlr4.Runtime.Misc;

namespace LambdaInterpreter.model
{
    public abstract class Term
    {
        public List<Variable> GetFreeVariables()
        {
            List<Variable> fv = new ArrayList<Variable>();
            AddMyFreeVariablesTo(fv);
            return fv;
        }
        
        internal abstract void AddMyFreeVariablesTo(List<Variable> fv);

        public abstract void AlphaReduce(string oldVarName, string newVarName);

        public void AlphaReduceFreeVariables()
        {
            GetFreeVariables().ForEach(
                v => AlphaReduce(v.Name, MainClass.GenerateVariableName()));
        }
        
        public abstract Term Substitute(Variable prev, Term now);

        [Pure]
        public Term Interpreted(EvaluationOptions options)
        {
            return Clone().Interpret(options);
        }

        public Term Interpret(EvaluationOptions options)
        {
            options.Root = this;
            options.Step();
            Term result = Evaluate(options);
            options.Root = null;
            return result;
        }

        internal abstract Term Evaluate(EvaluationOptions options);

        internal Term EmbedAliases(Dictionary<string, Alias> aliases)
        {
            List<Variable> freeVariables = GetFreeVariables();

            Term res = this;
            
            foreach (Variable fv in freeVariables)
            {
                if (aliases.TryGetValue(fv.Name, out var alias))
                {
                    res = res.Substitute(fv, alias.Clone());
                }
            }

            return res;
        }

        public abstract Term Clone();
    }
}