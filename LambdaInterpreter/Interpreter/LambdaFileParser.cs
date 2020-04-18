using System;
using LambdaInterpreter.model;

namespace LambdaInterpreter.Interpreter
{
    public interface LambdaFileParser
    {
        public Term parseFile(String path);
    }
}