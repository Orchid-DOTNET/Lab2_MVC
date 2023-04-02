using System;
using System.Globalization;
using System.Linq;
//Assigment 3 Display the Employee Details Whose Age is Greater Than 30 Order by ID

namespace ConsoleExamples
{
    public class Employee
    {
        int id;
        string name;
        int age;
        string email;
        float salary;

        public override string ToString()
        {
            return id + " " + name + " " + age + " " + salary;
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
        {
             new Employee {id=101, name="Bivek Chaudhary", age=32, email="bivek@gmail.com", salary=90000 },
             new Employee {id=120, name="Upak Tuladhar", age=35, email="uppak@gmail.com", salary=80000 },
             new Employee {id=106, name="Divya Neupane", age=34, email="divya@gmail.com", salary=70000},
             new Employee {id=116, name="Binaya Limbu", age=27, email="binaya@gmail.com", salary = 100000},
             new Employee {id=107, name="Amisha Sainju", age=37, email="amisha@gmail.com", salary= 120000},
             new Employee {id=109, name="Suman Khatiwada", age=38,email="suman@gmail.com", salary= 50000},
             new Employee {id=112, name="Sudip KC", age=31, email="sudip@gmail.com", salary=45000},
             new Employee {id=126, name="Prayag Dhakal", age=37, email="prayag@gmail.com", salary=60000},
             new Employee {id=140, name="Ramesh Paudel", age=56, email="ramesh@gmail.com", salary=56000},
             new Employee {id=105, name="Sanjeev Neupane", age=28, email="sanjeev@gmail.com", salary=49000},
             new Employee {id=134, name="RaviKant Chaudhary", age=31, email="ravikant@gmail.com", salary=78000},
             new Employee {id=123, name="Bilish Kharbuja", age=38, email="bilish@gmail.com", salary=56000}
        };

            IEnumerable<Employee> orderedEmployeeList =
                from emp in employees
                where emp.age > 30
                orderby emp.id
                select emp;

            Console.WriteLine("ID  Name  Age  Salary");
            Console.WriteLine("=====================");
            foreach (Employee o in orderedEmployeeList)
            {
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine("=================");
        }
    }
}

