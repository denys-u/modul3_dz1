namespace Modul3_dz1
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var myList = new MyList<int>(5) { 6, 8, 9, 2 };
            var array = new MyList<int> { 4, 6, 9, 3, 7, 1, 5 };

            myList.AddRange(array);

            myList.Capacity = 2;

            Console.WriteLine($"Count = {myList.Count} Capacity = {myList.Capacity}");

            foreach (var item in myList)
            {
                Console.WriteLine($"{item}");
            }

            myList.Remove(4);
            myList.RemoveAt(4);

            myList.Sort(new IntComparer());

            Console.WriteLine($"Count = {myList.Count} Capacity = {myList.Capacity}");

            foreach (var item in myList)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
