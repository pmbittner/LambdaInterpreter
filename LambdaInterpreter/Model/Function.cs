using System;
using System.Collections.Generic;
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
        
        public List<Variable> Parameters
        {
            get;
        }

        public Term Body
        {
            get;
            set;
        }

        public override string ToString()
        {
            return LAMBDA + String.Join(' ', Parameters) + $"{DOT} {Body}";
        }
    }
}