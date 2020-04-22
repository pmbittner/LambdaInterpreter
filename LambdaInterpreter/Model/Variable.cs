using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace LambdaInterpreter.model
{
    public class Variable : Term
    {
        public Variable(string name)
        {
            Name = name;
        }

        public Variable(Variable other)
        {
            Name = other.Name;
        }
        
        /**
         * Just use a String for now.
         * We can change this to Int or whatever for efficiency later.
         */
        public string Name { get; set; }

        public bool NameEquals(Variable other)
        {
            return NameEquals(other.Name);
        }
        
        public bool NameEquals(string other)
        {
            return Name.Equals(other);
        }

        internal override void AddMyFreeVariablesTo(List<Variable> fv)
        {
            fv.Add(this);
        }

        public override void AlphaReduce(string oldVarName, string newVarName)
        {
            if (Name.Equals(oldVarName))
            {
                Name = newVarName;
            }
        }

        public override Term Substitute(Variable prev, Term now)
        {
            if (NameEquals(prev))
            {
                return now;
            }
            
            return this;
        }

        internal override Term Eval(EvaluationOptions options)
        {
            return this;
        }

        public override Term Clone()
        {
            return new Variable(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}