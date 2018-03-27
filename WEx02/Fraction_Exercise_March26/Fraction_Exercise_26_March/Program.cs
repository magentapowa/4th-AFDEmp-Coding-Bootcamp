using System;
using System.Collections.Generic;

namespace Fraction_Exercise_26_March
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Hello dude!");

            Fraction f1 = new Fraction(3, 8);
            Fraction f2 = new Fraction(-1, 2);
            Fraction f3 = new Fraction(15, -39);
            Fraction f4 = new Fraction(-47,-179);

            // Calculate() method
            Console.WriteLine("\n// Calculate method");
            Console.WriteLine($"f1 = {f1} = {f1.Calculate}");
            Console.WriteLine($"f2 = {f2} = {f2.Calculate}");
            Console.WriteLine($"f3 = {f3} = {f3.Calculate}");
            Console.WriteLine($"f4 = {f4} = {f4.Calculate}");
            //---------------------------------------------------

            // Operator  overloading
            Console.WriteLine("\n// Operator  overloading");
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
            Console.WriteLine($"{f1} * 5 = {f1 * 5}");
            Console.WriteLine($"4 * {f1} = {4 * f1}");
            //---------------------------------------------------

            // IComperable
            Console.WriteLine("\n// IComperable");
            List<Fraction> myList = new List<Fraction>();
            myList.Add(f1);
            myList.Add(f2);
            myList.Add(f3);
            myList.Add(f4);

            Console.WriteLine("My list:");
            Console.Write("[ ");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i]);
                Console.Write("   ");
            }
            Console.WriteLine("]");
            Console.WriteLine("Sorted list:");
            myList.Sort();
            Console.Write("[ ");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i]);
                Console.Write("   ");
            }
            Console.WriteLine("]");
            //---------------------------------------------------

            // Parse input string to fraction
            string stringToParse;
            Fraction f5;
            Console.WriteLine("\n// Parse input string to fraction");
            while (true)
            {
                Console.WriteLine("Give me a fraction for me to parse: ");
                stringToParse = Console.ReadLine();
                try
                {
                    f5 = Fraction.Parse(stringToParse);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("    Wanna try again?");
                }

            }
            Console.WriteLine($"f5 = {f5} = {f5.Calculate}");
            //---------------------------------------------------


            // Cancel() method
            Console.WriteLine("\n// Cancel() method");
            Fraction f6 = new Fraction(45 , 30);
            Console.WriteLine($"f6 = {f6} = {f6.Calculate}");
            f6.Cancel();
            Console.WriteLine($"f6 = {f6} = {f6.Calculate}");
            //---------------------------------------------------
        }
    }
}
