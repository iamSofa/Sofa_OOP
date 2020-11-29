using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class Reflector
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
            Console.WriteLine("\nМетоды по заданным параметрам:");
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
        public static void WriteFile(string objName)
        {
            string path = @"C:\Users\Sonya\Desktop\ооп\Sofa_OOP\lab12\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Type myType = Type.GetType(objName);
            using (FileStream fstream = new FileStream($"{path}file.txt", FileMode.Append))
            {
                byte[] array = Encoding.Default.GetBytes("Методы:\n");
                fstream.Write(array, 0, array.Length);
                foreach (MethodInfo method in myType.GetMethods())
                {
                
                    
                    byte[] array1 = Encoding.Default.GetBytes(method.ReturnType.Name + " " + method.Name + "(");
                    fstream.Write(array1, 0, array1.Length);
                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        byte[] array2 = Encoding.Default.GetBytes(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                        fstream.Write(array2, 0, array2.Length);
                    }
                    byte[] array3 = Encoding.Default.GetBytes(")\n");
                    fstream.Write(array3, 0, array3.Length);
                }
                byte[] array4 = Encoding.Default.GetBytes("\nПоля:\n");
                fstream.Write(array4, 0, array4.Length);
                foreach (FieldInfo field in myType.GetFields())
                {
                    byte[] array5 = Encoding.Default.GetBytes(field.FieldType + " " + field.Name + "\n");
                    fstream.Write(array5, 0, array5.Length);
                }
                byte[] array6 = Encoding.Default.GetBytes("\nСвойства:\n");
                fstream.Write(array6, 0, array6.Length);
                foreach (PropertyInfo prop in myType.GetProperties())
                {
                    byte[] array7 = Encoding.Default.GetBytes(prop.PropertyType + " " + prop.Name + "\n");
                    fstream.Write(array7, 0, array7.Length);
                }
                byte[] array8 = Encoding.Default.GetBytes("\nРеализованные интерфейсы:\n");
                fstream.Write(array8, 0, array8.Length);
                foreach (Type i in myType.GetInterfaces())
                {
                    byte[] array9 = Encoding.Default.GetBytes(i.Name + "\n");
                    fstream.Write(array9, 0, array9.Length);
                }
            }
        }
        public static void ReadFile(string objName, string method)
        {
            Type myType = Type.GetType(objName);
            MethodInfo methodInfo = myType.GetMethod(method);

        }

    }
}
