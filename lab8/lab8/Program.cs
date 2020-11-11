using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        public static Random rand;
        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);

            List<int> list = new List<int>(5);
            List<int> newList = new List<int>(7);
            Console.WriteLine(list);
            Console.WriteLine(newList);
            Console.WriteLine();
            Console.WriteLine(list >> 2);
            Console.WriteLine(list);
            Console.WriteLine(list + 3);
            Console.WriteLine(list);
            Console.WriteLine(list != newList);
            Console.WriteLine(list == newList);


            List<PrintedEdition> l = new List<PrintedEdition>(0);
            try
            {
                l.Insert(new PrintedEdition("Book1", 1999, 32, 102));
                l.Insert(new PrintedEdition("Book2", 2020, 12, 534));
                l.Insert(new PrintedEdition("Book3", 2003, 2, 17));
            }
            catch
            {
                PrintedEdition edition = new PrintedEdition("123", 123, 123, 123);
                l.Insert(edition);
            }
            l.View();
            try
            {
                l.Delete();
            }
            finally
            {
                Console.WriteLine("Удаление элементов было проверено на наличиие ошибок!");
            }
            l.View();

            Console.ReadKey();
        }
    }



    public static class Extensions
    {
        public static int Sum(this List<int> source)
        {
            int sum = 0;
            for (int i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }
            return sum;
        }
        public static int MaxMinDif(this List<int> source)
        {
            int mx = int.MinValue, mn = int.MaxValue;
            for (int i = 0; i < source.Length; i++)
            {
                mx = Math.Max(mx, source[i]);
                mn = Math.Min(mn, source[i]);
            }
            return mx - mn;
        }
        public static int Count(this List<int> source)
        {
            return source.Length;
        }
        public static string GetLongestWord(this string source)
        {
            string[] words = source.Split(' ');
            string mxWord = String.Empty;
            foreach (var word in words)
            {
                if (word.Length > mxWord.Length)
                    mxWord = word;
            }
            return mxWord;
        }
        public static List<int> DeleteLastElement(this List<int> source)
        {
            return source >>= source.Length;
        }
    }
}


