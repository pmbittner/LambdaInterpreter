using System;
using LambdaInterpreter.model;

namespace LambdaInterpreter.Parsing
{
    public interface LambdaFileParser
    {
        public Term ParseFile(String path);
    }
}