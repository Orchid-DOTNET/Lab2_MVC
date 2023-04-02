using System;
using System.IO;

namespace ConsoleExamples
{
    internal class Assignment2
    {
        static void Main()
        {
            string filePath = "C:\\Users\\Bivek\\Desktop\\dotNet\\BscCSIT-2023\\Section B\\BivekChaudhary\\ConsoleExamples\\Assignment2.txt";

            int lineCount = 0;
            bool errorOccurred = false;

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            if (!errorOccurred)
            {
                Console.WriteLine($"The file contains {lineCount} lines.");
            }
            else
            {
                Console.WriteLine("An error occurred while reading the file.");
            }
        }
    }

}
