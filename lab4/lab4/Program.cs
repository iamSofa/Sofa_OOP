using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        public static Random rand;
        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);

            List list = new List(5);
            Console.WriteLine(list);
            Console.WriteLine(list >> 2);
            Console.WriteLine(list);
            Console.WriteLine(list + 3);
            Console.WriteLine(list);
            Console.WriteLine(list != list);
            Console.WriteLine(list == list);

            string words = Console.ReadLine();
            Console.WriteLine("Longest word - " + words.GetLongestWord());
            Console.WriteLine(list.DeleteLastElement());
            list.MaxMinDif();
            Console.ReadKey();
        }
    }
    public static class Extensions
    {
        public static int Sum(this List source)
        {
            int sum = 0;
            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }
            return sum;
        }
        public static int MaxMinDif(this List source)
        {
            int mx = int.MinValue, mn = int.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                mx = Math.Max(mx, source[i]);
                mn = Math.Min(mn, source[i]);
            }
            return mx - mn;
        }
        public static int Count(this List source)
        {
            return source.Length;
        }
        public static string GetLongestWord(this string source)
        {
            string[] words = source.Split(' ');
            return words.Max();
        }

        public static List DeleteLastElement(this List source)
        {
            return source >>= source.Length;
        }
    }
}
