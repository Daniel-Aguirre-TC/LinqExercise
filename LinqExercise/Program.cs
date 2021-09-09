using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {


        static void PrintAll(IEnumerable linqResult)
        {
            foreach (var item in linqResult)
            {
                Console.WriteLine(item);
            }
        }


        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };


        static void ClearForNextSection()
        {
            Console.Write("\n\nPress any key for next section. ");
            Console.ReadKey();
            Console.Clear();
        }



        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            Console.WriteLine(
                "Sum: " + numbers.Sum() +
                "\nAverage: " + numbers.Average()
                );

            ClearForNextSection();

            //Order numbers in ascending order and decsending order. Print each to console.

            var ordered = numbers.OrderBy(x => x.ToString());


            PrintAll(ordered);

            Console.WriteLine("\n---\n");

            var descending = from num in numbers
                             orderby num descending
                             select num;

            PrintAll(descending);

            ClearForNextSection();

            //Print to the console only the numbers greater than 6
            PrintAll(
                from num in numbers
                where num > 6
                select num
                );

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            PrintAll((
                    from num in numbers
                    orderby num descending
                    select num).Take(4));

            ClearForNextSection();

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(26, 4);
            PrintAll(numbers);

            ClearForNextSection();


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.

            //Order this in acesnding order by FirstName.

            PrintAll(
                from obj in employees
                where obj.FirstName.ToLower().StartsWith('c') || obj.FirstName.ToLower().StartsWith('s')
                orderby obj.FirstName
                select obj.FirstName);

            ClearForNextSection();


            //Print all the employees' FullName and Age who are over the age 26 to the console.

            //Order this by Age first and then by FirstName in the same result.

            PrintAll(
                from obj in employees
                where obj.Age > 26
                orderby obj.Age, obj.FirstName
                select obj.FullName + " is " + obj.Age + " years old." );


            ClearForNextSection();

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var requested = from obj in employees
                            where obj.YearsOfExperience > 10 && obj.Age > 35
                            select obj;

            Console.WriteLine($"Sum: {requested.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average: {requested.Average(x => x.YearsOfExperience)}");

            ClearForNextSection();

            employees = employees.Append(new Employee("1234","1234", 45, 52)).ToList();

            PrintAll(from obj in employees select obj.FullName);
            //Add an employee to the end of the list without using employees.Add()



            Console.WriteLine();

            Console.ReadLine();
        }



        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
