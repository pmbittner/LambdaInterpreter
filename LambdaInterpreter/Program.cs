using System;
using Antlr4.Runtime;
using LambdaInterpreter.Interpreter;
using LambdaInterpreter.model;

namespace LambdaInterpreter
{
    class Program
    {
        private static NameGenerator VariableNameGenerator;
        private static int CurrentNameIndex = 0;

        public static DebugPrint Debug = new DebugPrint();
        
        public static String GenerateVariableName()
        {
            return VariableNameGenerator.getNameAtIndex(CurrentNameIndex++);
        }

        private static void run(Term program, EvaluationOptions.Type type, EvaluationOptions options)
        {
            Console.WriteLine($"{type} Evaluation:");
            
            options.EvalType = type;
            Term result = program.Evaluated(options);
            
            if (!options.PrintSteps)
            {
                Console.WriteLine(result);
            }
        }
        
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error: No file to run given.");
                return;
            }
            
            VariableNameGenerator = new NumericNameGenerator();

            String fileToRun = args[0];
            LambdaFileParser parser = new AntlrRunner();
            Term program = parser.parseFile(fileToRun);
            Console.WriteLine($"Input:\n{program}\n");
            //Console.WriteLine(program.ToIDString());
            
            EvaluationOptions options = new EvaluationOptions();
            options.PrintSteps = true;

            run(program, EvaluationOptions.Type.Normative, options);
            Console.WriteLine();
            run(program, EvaluationOptions.Type.Applicative, options);
        }
    }
}