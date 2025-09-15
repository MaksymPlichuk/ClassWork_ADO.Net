using System;
using System.Linq;

namespace _04_LinqToSQL
{

    class LinqToObjFunctions()
    {
        private int[] GenerateIntArray()
        {
            Random random = new Random();
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 100);
            }
            return arr;
        }

        public void PositiveSortedNums()
        {
            Console.WriteLine("\tTask 1");

            int[] arr = GenerateIntArray();

            var query = arr.Where(p => p >= 0).Order();
            Console.Write("All suitable: ");
            foreach (int i in query)
            {
                Console.Write(i +"  ");
            }
            Console.WriteLine();
        }

        public void PositiveBinaryNums() {
            Console.WriteLine("\n\tTask 2");

            int[] arr = GenerateIntArray();

            var query = arr.Where(p => p >= 0 && p > 9 && p < 100);

            Console.Write("All suitable: ");
            foreach (int i in query)
            {
                Console.Write(i + "  ");
            }
            Console.Write("\nNumber of elements: "); Console.Write(query.Count()+"\n");
            Console.Write("Avg of numbers: "); Console.Write(query.Average()+"\n");

        }

        public void LeapYears()
        {
            Console.WriteLine("\n\tTask 3");
            Random random = new Random();
            int[] arr = new int[15];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1000, 2200);
            }

            var query = arr.Where(p => (p % 400 == 0) || (p % 4 == 0 && p % 100 != 0)).Order();

            Console.Write("Leap years: ");
            foreach (int i in query)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();
        }

        public void MaxEven() {
            Console.WriteLine("\n\tTask 4");

            int[] arr = GenerateIntArray();

            var query = arr.Where(p => p % 2 == 0).Max();

            Console.WriteLine($"Max even number: {query}");

        }

        public void ChangingSring() {
            Console.WriteLine("\n\tTask 5");


            string[] arr = new string[3];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter {i+1} string: "); arr[i] = Console.ReadLine()! + "!!!";
            }

            Console.WriteLine("\nAll strings: ");
            foreach(string i in arr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
        public void FindCharInString()
        {
            Console.WriteLine("\n\tTask 6");


            string[] arr = new string[3];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter {i + 1} string: "); arr[i] = Console.ReadLine()!;
            }

            Console.Write("Enter a symbol to find: ");string text = Console.ReadLine()!; char symb = text[0];


            var query = arr.Where(p => p.Contains(symb));

            Console.WriteLine($"\nStrings that contain {symb}: ");
            foreach (string i in query)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        public void GroupStringByCharacters()
        {
            Console.WriteLine("\n\tTask 7");


            string[] arr = new string[10];

            for (int i = 0; i < arr.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter {i + 1} string: "); arr[i] = Console.ReadLine()!;
                    if (string.IsNullOrEmpty(arr[i])) continue;
                    else break;
                }
               
            }


            var query = arr.GroupBy(p => p.Length).OrderBy(p => p.Key);

            foreach (var i in query)
            {
                Console.WriteLine($"Words with {i.Key} symbols:");
                foreach (var item in i)
                {
                    Console.WriteLine($" {item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Linq to obj

            LinqToObjFunctions funcs = new LinqToObjFunctions();

            funcs.PositiveSortedNums();
            funcs.PositiveBinaryNums();
            funcs.LeapYears();
            funcs.MaxEven();
            funcs.ChangingSring();
            funcs.FindCharInString();
            funcs.GroupStringByCharacters();

        }
    }
}
