using System;
using System.Linq;

namespace LambdaInterpreter
{
    public class DebugPrint
    {
        private int indent = 0;
    
        private string getIndent()
        {
            return string.Concat(Enumerable.Repeat("    ", indent));
        }

        public void IncIndent()
        {
            ++indent;
        }

        public void DecIndent()
        {
            --indent;
        }

        public bool Enabled { get; set; } = true;

        public void Print(string s)
        {
            if (Enabled)
            {
                Console.WriteLine(getIndent() + s);
            }
        }
    }
}