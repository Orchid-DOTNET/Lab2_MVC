using System;
//Assignment 4 Create a Calculator application that make calculation of addition, subtration, multiplication, division
//Using interface in MultipleInheritance

namespace MultipleInheritance
{

    interface Cal1
    {
        // method without body
        void add(int a, int b);

    }

    interface Call2
    {
        void sub(int a, int b);
    }

    interface Call3
    {
        void mul(int a, int b);
    }

    interface Call4
    {
        void div(int a, int b);
    }

    class Calculator : Cal1, Call2, Call3, Call4
    {

        // implementation of methods inside interface
        public void add(int a, int b)
        {

            int result1 = a + b;
            Console.WriteLine("Addition of a and b : " + result1);
        }

        public void sub(int a, int b)
        {
            int result2 = a - b;
            Console.WriteLine("Subtraction of a and b : " + result2);
        }

        public void mul(int a, int b)
        {
            int result3 = a * b;
            Console.WriteLine("Multiplication of a and b : " + result3);
        }

        public void div(int a, int b)
        {
            int result4 = a / b;
            Console.WriteLine("Division of a and b : " +  result4);
        }
    }


    class Assigment4
    {
        static void Main(string[] args)
        {

            Calculator r1 = new Calculator();

            r1.add(20, 10);
            r1.sub(20, 10);
            r1.mul(20, 10);
            r1.div(20, 10);

        }
    }
}
