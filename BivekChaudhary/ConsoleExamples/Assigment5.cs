using System;
//Assigment 5 C# Program for handling exceptions using try catch and finally

namespace ExceptionHandling
{
    public class Assigment5
    {
        static void Main(string[] args)
        {
            //Input First Number
            Console.WriteLine("Enter first number:");
            int firstNum = int.Parse(Console.ReadLine());

            //Input Second Number
            Console.WriteLine("Enter second number:");
            int secondNum = int.Parse(Console.ReadLine());

            try
            {
                // May create an exception 
                int divResult = firstNum / secondNum;
                Console.WriteLine("Division of two numbers is: " + divResult);
            }

            //Executed only when an exception is occured
            catch (Exception e)
            {
                Console.WriteLine("An exception occurred: " + e.Message);
            }

            finally
            {
                // Always executed whether there is exception occurred or not 
                int sumResult = firstNum + secondNum;
                Console.WriteLine("Sum of two numbers is: " + sumResult);
            }
        }
    }
}
