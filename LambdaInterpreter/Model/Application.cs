using System;

namespace LambdaInterpreter.model
{
    public class Application : Term
    {
        public Application()
        {
            Left = null;
            Right = null;
        }

        public Application(Term left, Term right)
        {
            Left = left;
            Right = right;
        }
        
        public Term Left { get; set; }
        public Term Right { get; set; }
        
        public override string ToString()
        {
            return $"({Left}, {Right})";
        }
    }
}