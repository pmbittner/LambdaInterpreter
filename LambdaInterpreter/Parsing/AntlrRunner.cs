using System;
using Antlr4.Runtime;
using LambdaInterpreter.model;

namespace LambdaInterpreter.Parsing
{
    public class AntlrRunner : LambdaFileParser
    {
        public Term ParseFile(String path)
        {
            ICharStream stream = CharStreams.fromstring(IO.TextFileIO.readFile(path));
            ITokenSource lexer = new Antlr.LambdaLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            Antlr.LambdaParser parser = new Antlr.LambdaParser(tokens);
            return new Visitor().VisitProgram(parser.program());
        }
    }
}