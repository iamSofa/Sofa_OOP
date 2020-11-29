using System;
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
            Reflector.GetMethods("lab12.Matrix");
            Console.WriteLine("\n");
            Reflector.GetFieldsProperties("lab12.Matrix");
            Console.WriteLine("\n");
            Reflector.GetInterface("lab12.Matrix");
            Console.WriteLine("\n");
            Reflector.GetMethodsParameterType("lab12.Matrix", "Int32");
            Console.ReadKey();
        }
    }
}
