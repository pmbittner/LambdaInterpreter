using System;
using Antlr4.Runtime;
using LambdaInterpreter.Interpreter;
using LambdaInterpreter.model;

namespace LambdaInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error: No file to run given.");
                return;
            }
            
            String fileToRun = args[0];
            LambdaFileParser parser = new AntlrRunner();
            Term program = parser.parseFile(fileToRun);
            Console.WriteLine(program.ToString());
        }
    }
}