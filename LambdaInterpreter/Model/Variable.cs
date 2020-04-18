using System;

namespace LambdaInterpreter.model
{
    public class Variable : Term
    {
        public Variable(string name)
        {
            Name = name;
        }
        
        /**
         * Just use a String for.
         * We can change this to Int or whatever for efficiency later.
         */
        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}