using System;

namespace LambdaInterpreter.model
{
    public class Alias : Variable
    {
        private bool hasUniqueBody = false;
        
        public Alias(string name, Term body) : base(name)
        {
            Body = body;
        }

        public Alias(Alias other) : base(other)
        {
            // We do not clone the body here but do it in a lazy manner during evaluation.
            Body = other.Body;
        }
        
        public Term Body { get; private set; }
        
        public override void AlphaReduce(string oldVarName, string newVarName)
        {
            if (Name.Equals(oldVarName))
            {
                throw new NotSupportedException("Cannot rename an alias!");
            }
        }
        
        public override Term Substitute(Variable prev, Term now)
        {
            return this;
        }
        
        internal override Term Evaluate(EvaluationOptions options)
        {
            // We have to clone to avoid side-effects when the same alias also occurs in other places of a term.
            if (!hasUniqueBody)
            {
                Body = Body.Clone();
                // We have to do this to avoid naming conflicts when resolving an alias.
                Body.AlphaReduceFreeVariables();
                hasUniqueBody = true;
            }
            
            return Body.Evaluate(options);
        }
        
        public override Term Clone()
        {
            return new Alias(this);
        }

        public override string ToString()
        {
            return $"<{base.ToString()}>";
        }
    }
}