using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab12
{
    public static class Reflector
    {
        private static Regex regObjName = new Regex(@"^[a-z]\S+[.][a-z]\S+", RegexOptions.IgnoreCase);
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
        private static string ReadFromFile(string fileName)
        {
            FileStream fin = new FileStream(fileName, FileMode.Open);
            byte[] data = new byte[fin.Length];
            fin.Read(data, 0, data.Length);
            fin.Close();
            return Encoding.Default.GetString(data);
        }
        public static void InvokeMethods(string objName)
        {
            Type myType = Type.GetType(objName);
            var obj = Activator.CreateInstance(myType);
            foreach (var args in from l in ReadFromFile(objName + ".txt").Split('\n')
                                 select Regex.Split(l, @"\s*=\s*").Where(x => x != string.Empty).Select(x => Regex.Replace(x, @"[()\r]", "")))
            {
                MethodInfo method = myType.GetMethod(args.LastOrDefault());
                object[] prms = (from p in args.FirstOrDefault().Split(',').Where(x => !x.Equals(string.Empty))
                                 from pT in method.GetParameters().Select(x => x.ParameterType)
                                 select Convert.ChangeType(p, pT)).ToArray();
                Console.WriteLine($"{args.LastOrDefault()}() - {method.Invoke(obj, prms) ?? "void"}");
            }
        }

    }
}
