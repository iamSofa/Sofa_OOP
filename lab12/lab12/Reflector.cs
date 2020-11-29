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
        public static void GetMethods(string objName)
        {
            Type myType = Type.GetType(objName);

            Console.WriteLine("\nМетоды:");
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
        public static void GetFieldsProperties(string objName)
        {
            Type myType = Type.GetType(objName);
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }
            Console.WriteLine("\nСвойства:");
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
        }
        public static void GetInterface(string objName)
        {
            Type myType = Type.GetType(objName);
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void GetMethodsParameterType(string objName, string parameterType)
        {
            Type myType = Type.GetType(objName);
            Console.WriteLine("\nМетоды:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType.Name == parameterType)
                    {
                        Console.Write($" {method.ReturnType.Name} {method.Name} (");
                        Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                        if (i + 1 < parameters.Length) Console.Write(", ");
                        Console.WriteLine(")");
                    }
                }
                
            }
        }
    }
}
