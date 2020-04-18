using System;
using System.IO;

namespace LambdaInterpreter.IO
{
    public class TextFileIO
    {
        public static String readFile(String path)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream to a string, and write the string to the console.
                    return sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}