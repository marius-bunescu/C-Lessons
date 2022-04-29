using System;
using System.Collections;
using System.Collections.Generic;


namespace Collections
{
    public class Program
    {
        static void Main(String[] args)
        {
            #region ArrayList
            ArrayList aList = new ArrayList();

            aList.Add("Mercedes");
            aList.Add("Audi");
            aList.Add("Opel");
            aList.Add("Toyota");
            aList.Add("Ford");


            aList.Sort();
            Console.WriteLine("Count: {0}", aList.Count);
            Console.WriteLine("\nElements sorted in ascending order\n");
            foreach (object o in aList)
            {
                Console.WriteLine(o);
            }


            aList.Sort();
            aList.Reverse();
            Console.WriteLine("\nElements sorted in descending order\n");
            foreach (object o in aList)
            {
                Console.WriteLine(o);
            }


            //aList.RemoveAt(4);
            //Console.WriteLine("\nRemoviing an element\n");
            //foreach (object o in aList)
            //{
            //    Console.WriteLine(o);
            //}



            //Console.WriteLine("\nRemoviing a range\n");
            //aList.RemoveRange(0, 3);
            //foreach (object o in aList)
            //{
            //    Console.WriteLine(o);
            //}


            Console.WriteLine("\nMercedes = {0}", aList.IndexOf("Mercedes", 0));

            #endregion

            Console.WriteLine("----------------------------------");
            #region Dictionary
            Dictionary<string, string> Cars = new Dictionary<string, string>();

            Cars.Add("Germany", "Opel");
            Cars.Add("America", "Ford");
            Cars.Add("Japan", "Toyota");

           


            Console.WriteLine("Count: {0}", Cars.Count);
            Console.WriteLine("\nAmerica: {0}", Cars.ContainsKey("America"));
            foreach (object o in Cars)
            {
                Console.WriteLine(o);
            }

            Cars.Remove("Germany");
            foreach (object o in Cars)
            {
                Console.WriteLine(o);
            }


            #endregion
            Console.WriteLine("----------------------------------");
            #region Queue
            Queue nums = new Queue();

            nums.Enqueue(24);
            nums.Enqueue(61);
            nums.Enqueue(-78);
            nums.Enqueue(100);
            nums.Enqueue(1);



            foreach (object o in nums)
            {
                Console.WriteLine($"\nQueue: {o}");
            }

            Console.WriteLine("\nIs nr 61 in Queue: {0}", nums.Contains(61));
            if (nums.Count > 3)
            {
                nums.Dequeue();
            }
            object[] arr = nums.ToArray();

            Console.WriteLine(string.Join(", ", arr));
            #endregion
        }



    }
}