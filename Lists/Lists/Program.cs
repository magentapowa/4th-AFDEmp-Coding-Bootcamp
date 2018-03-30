using System;

namespace Lists
{
    class MainClass
    {
        public static void Main()
        {
            LinkedList myList = new LinkedList();

        //Appending
            Console.WriteLine("Appending:");
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");
            myList.Append(1);
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");
            myList.Append(2);
            myList.Append(3);
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");
            myList.Append(4);
            myList.Append(5);
            myList.Append(6);
            myList.Append(7);
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");
            Console.WriteLine();

        //Reverting
            myList.Revert();
            Console.WriteLine("Reverting:");
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");
            Console.WriteLine();

        //Get item
            Console.WriteLine("Indexing:");
            int index = 1;
            Console.WriteLine($"Geting item index {index}:");
            Console.WriteLine($"Vale: {myList.Get(index)}");

            index = 10;
            try
            {
                Console.WriteLine($"Geting item index {index}:");
                Console.WriteLine($"Vale: {myList.Get(index)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

        //Remove item
            index = 3;
            myList.Remove(index);
            Console.WriteLine($"Removing item index {index}:");
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");

            index = 0;
            myList.Remove(index);
            Console.WriteLine($"Removing item index {index}:");
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");

            index = myList.Count - 1;
            myList.Remove(index);
            Console.WriteLine($"Removing item index {index}:");
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");

            index = 5; //Out of range
            try
            {
                myList.Remove(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Removing item index {index}:");
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");
            Console.WriteLine();

        //Revert
            myList.Revert();
            Console.WriteLine("Reverting:");
            Console.WriteLine($"list: {myList.GetString()}, length: {myList.Count}");

        }
    }
}
