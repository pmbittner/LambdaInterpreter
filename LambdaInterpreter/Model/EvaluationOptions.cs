using System;

namespace LambdaInterpreter.model
{
    public class EvaluationOptions
    {
        public enum Type
        {
            Normative, Applicative
        }

        public void Step()
        {
            if (PrintSteps)
            {
                Console.WriteLine(Root);
            }
        }

        public Type EvalType
        {
            get;
            set;
        } = Type.Normative;

        public bool PrintSteps { get; set; } = false;
        
        internal Term Root { get; set; }
    }
}