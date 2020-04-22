namespace LambdaInterpreter
{
    public class NumericNameGenerator : NameGenerator
    {
        private const string GENERATED_NAME = "$";
        public string getNameAtIndex(int i)
        {
            return GENERATED_NAME + i;
        }
    }
}