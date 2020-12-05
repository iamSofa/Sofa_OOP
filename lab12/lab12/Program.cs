using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.WriteFile("lab12.Matrix");
            Reflector.GetMethods("lab12.Matrix");
            Console.WriteLine("\n");
            Reflector.GetFieldsProperties("lab12.Matrix");
            Console.WriteLine("\n");
            Reflector.GetInterface("lab12.Matrix");
            Console.WriteLine("\n");
            Reflector.GetMethodsParameterType("lab12.Matrix", "Int32");

            Reflector.GetMethods("lab12.Book");
            Console.WriteLine("\n");
            Reflector.GetFieldsProperties("lab12.Book");
            Console.WriteLine("\n");
            Reflector.GetInterface("lab12.Book");
            Console.WriteLine("\n");
            Reflector.GetMethodsParameterType("lab12.Book", "Int32");

            Console.WriteLine("\n");
            Reflector.InvokeMethods("lab12.Book");
            Console.ReadKey();
        }
    }
}
