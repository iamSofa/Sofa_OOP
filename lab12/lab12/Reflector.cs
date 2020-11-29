using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Reflector
    {
        public static void  GetMethods(string objName)
        {
            Type myType = Type.GetType(objName);

            Console.WriteLine("Методы:\n");
            foreach (MethodInfo method in myType.GetMethods())
            {
                Console.Write($" {method.ReturnType.Name} {method.Name} (");
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
    }
}
