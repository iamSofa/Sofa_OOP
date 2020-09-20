using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. ТИПЫ

            // Определите переменные всех возможных примитивных типов С# и проинициализируйте их
            Console.WriteLine("Задание 1");
            Console.WriteLine();

            int typeInt = -15;
            double typeDouble = 21.5;
            char typeChar = 'f';
            bool typeBool = true;
            decimal typeDecimal = 2M;
            string typeString = "Hello";
            object typeObject = "Hi!";
            byte typeByte = 21;
            sbyte typeSbyte = -25;
            ushort typeUshort = 1024;
            short typeShort = -2048;
            uint typeUint = 2345678;
            ulong typeUlong = 2132;
            long typeLong = -23256472;
            float typeFloat = 4;

            Console.WriteLine("Типы C#" + "\n");
            Console.WriteLine("ЧИСЛОВЫЕ (целочисленные) типы:");
            Console.WriteLine(typeByte.GetType() + "\n" + typeSbyte.GetType() + "\n" + typeShort.GetType() + "\n" + typeUshort.GetType() + "\n" + typeInt.GetType() + "\n" + typeUint.GetType() + "\n" + typeLong.GetType() + "\n" + typeUlong.GetType() + "\n");

            Console.WriteLine("ЧИСЛОВЫЕ (с плавающей точкой) типы:");
            Console.WriteLine(typeFloat.GetType() + "\n" + typeDouble.GetType() + "\n" + typeDecimal.GetType() + "\n");

            Console.WriteLine("СИМВОЛЬНЫЕ типы:");
            Console.WriteLine(typeChar.GetType() + "\n" + typeString.GetType() + "\n");

            Console.WriteLine("ЛОГИЧЕСКИЙ тип:");
            Console.WriteLine(typeBool.GetType() + "\n");

            Console.WriteLine("ОСОБЫЕ типы:");
            Console.WriteLine("Object" + "\n" + "Dynamic" + "\n");

            // Выполните 5 операций явного и 5 неявного приведения
            double intDouble = typeInt;
            int intChar = typeChar;
            float longFloat = typeLong;
            decimal shortDecimal = typeShort;
            uint byteUint = typeByte;
            Console.WriteLine("Явное приведение:");
            Console.WriteLine(intChar);

            short sbyteShort = (short)typeSbyte;
            long charLong = (long)typeChar;
            ulong ushortUlong = (ulong)typeUshort;
            ushort byteUshort = (ushort)typeByte;
            double floatDouble = (double)typeFloat;
            Console.WriteLine("Неявное приведение:");
            Console.WriteLine(byteUshort + "\n");

            // Выполните упаковку и распаковку значимых типов
            object intObject = typeInt;
            int objectInt = (int)intObject;

            object charObject = typeChar;
            char objectChar = (char)charObject;

            // Продемонстрируйте работу с неявно типизированной переменной
            var newInt = 5;
            var newChar = 'l';
            var newDouble = 1.6;
            var newString = "GM";
            Console.WriteLine("Неявно типизированная переменная: " + newInt + "\n");

            // Продемонстрируйте пример работы с Nullable переменной
            int? nullInt = null;
            Nullable<bool> nullBool = true;

            Console.Write("1 Значение Nullable: ");
            if (nullInt.HasValue)
                Console.WriteLine(nullInt.Value);
            else
                Console.WriteLine("null");

            Console.Write("2 Значение Nullable: ");
            if (nullBool.HasValue)
                Console.WriteLine(nullBool.Value);
            else
                Console.WriteLine("null");
            Console.WriteLine();

            // 2. СТРОКИ

            // Объявите строковые литералы. Сравните их
            Console.WriteLine("Задание 2" + "\n");
            string strHello = "Hello Darkness";
            string strFriend = "my old friend";
            string strConcat = strHello + ", " + strFriend;

            int result = String.Compare(strHello, strFriend);
            if (result < 0)
            {
                Console.WriteLine("Строка strHello перед строкой strFriend");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка strHello стоит после строки strFriend");
            }
            else
            {
                Console.WriteLine("Строки strHello и strFriend идентичны");
            }

            Console.WriteLine(strConcat);

            Console.WriteLine();

            /* Создайте три строки на основе String. Выполните: сцепление, 
            копирование, выделение подстроки, разделение строки на слова,
            вставки подстроки в заданную позицию, удаление заданной
            подстроки */
            string str1 = "First string";
            string str2 = "Second string";
            string str3 = "Third string";

            string str4 = String.Concat(str1, ", ", str2, ", ", str3);
            Console.WriteLine(str4);

            string newStr1 = String.Copy(str1);
            Console.WriteLine(newStr1);

            Console.WriteLine(str4.Substring(6, 6));

            string[] newStr4 = str4.Split(new char[] { ' ' });

            foreach (string s in newStr4)
            {
                Console.WriteLine(s);
            }

            str3 = str3.Insert(6, str2);
            Console.WriteLine(str3);

            str1 = str1.Remove(0, 6);
            Console.WriteLine(str1);

            // Создайте пустую и null строку. Продемонстрируйте что можно выполнить с такими строками
            string emptyString = "";
            string nullString = null;

            int comString = String.Compare(strHello, nullString);
            if (comString < 0)
            {
                Console.WriteLine("Строка strHello перед строкой nullString");
            }
            else if (comString > 0)
            {
                Console.WriteLine("Строка strHello стоит после строки nullString");
            }
            else
            {
                Console.WriteLine("Строки strHello и nullString идентичны");
            }

            string conString = String.Concat(emptyString, strHello, nullString);
            Console.WriteLine(conString);

            // Создайте строку на основе StringBuilder. Удалите определенные позиции и добавьте новые символы в начало и конец строки
            StringBuilder strBuilder = new StringBuilder("Строка на основе StringBuilder");

            strBuilder.Remove(0, 7);
            strBuilder.Insert(0, "Строчка, созданная ");
            strBuilder.Insert(strBuilder.Length, ", наверное");

            Console.WriteLine(strBuilder);

            // 3. МАССИВЫ

            // Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица)
            Console.WriteLine("Задание 3" + "\n");
            int[,] matrix = new int[,] { {1, 2, 3}, {4, 5, 6} };
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("\t{0}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            /* Создайте одномерный массив строк. Выведите на консоль его
            содержимое, длину массива. Поменяйте произвольный элемент
            (пользователь определяет позицию и значение) */
            string[] arrayString = {"Blue", "Black", "Red", "Green", "Pink"};

            int lArray = arrayString.Length;
            Console.Write("Array Length: ");
            Console.WriteLine(lArray);
            foreach (var str in arrayString)
            {
                Console.WriteLine(str);
            }

            Console.Write("Введите позицию изменяего слова и значение: ");
            string index = Console.ReadLine();
            string value = Console.ReadLine();
            Console.WriteLine();
            int pos = Convert.ToInt32(index);
            arrayString[pos - 1] = value;
            for (int i = 0; i < arrayString.Length; i++)
            {
                Console.WriteLine(arrayString[i]);
            }

            // Создайте ступечатый (не выровненный) массив вещественных чисел с 3 - мя строками, в каждой из которых 2, 3 и 4 столбцов соответственно.Значения массива введите с консоли
            double[][] arrayDouble = { new double[2], new double[3], new double[4] };

            for (int i = 0; i < arrayDouble.Length; i++)
            {
                for (int j = 0; j < arrayDouble[i].Length; j++)
                {
                    Console.Write("Введите значение: ");
                    arrayDouble[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            foreach (double[] x in arrayDouble)
            {
                foreach (double a in x)
                {
                    Console.Write("\t" + a);
                }
                Console.WriteLine();
            }

            // Создайте неявно типизированные переменные для хранения массива и строки
            var intArray = new int[] { 5, 1, 7, 4, 9 };
            var boolArray = new bool[] { true, false };
            var doubleArray = new double[] { 4.67, 9.4, 5.99 };
            var charArray = new char[] { 'h', 'e', 'l', 'l', 'o' };
            var stringArray = new string[] { "why", "are", "so", "many", "tasks" };

            // 4. КОРТЕЖИ

            // Задайте кортеж из 5 элементов с типами int, string, char, string, ulong
            Console.WriteLine("Задание 4" + "\n");
            (int, string, char, string, ulong) tuple = (11, "this is", 'a', "good idea", 993);

            // Выведите кортеж на консоль целиком и выборочно ( например 1, 3, 4 элементы)

            Console.WriteLine(tuple);

            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);

            // Выполните распаковку кортежа в переменные
            int tupleInt = (int)tuple.Item1;
            string tupleString = (string)tuple.Item2;
            char tupleChar = (char)tuple.Item3;
            ulong tupleUlong = (ulong)tuple.Item5;
            Console.WriteLine("Вывод эл-ов кортежа после распаковки: " + tupleInt + "\t" + tupleString + "\t" + tupleChar + "\t" + tupleUlong);

            // Сравните два кортежа
            (int, string, char, string, ulong) tuple2 = (101, "this is", 'a', "bad idea", 73);
            Console.WriteLine(tuple2);

            var tupleCompare = tuple.CompareTo(tuple2);
            Console.WriteLine("Сравнение кортежей: " + tupleCompare);

            // 5. ЛОКАЛЬНАЯ ФУНКИЯ

            Console.WriteLine("Задание 5" + "\n");
            var localFun = LocalFunction();
            Console.WriteLine(localFun);

            Console.ReadKey();
        } 
        static (int, int, int, char) LocalFunction()
        {
            int[] array = new int[7] { 8, 21, 4, 1, 6, 30, 2 };
            string str = "Programm";
            int max = array.Max();
            int min = array.Min();
            int arraySum = array.Sum();
            char first = str[0];
            var res = (max, min, arraySum, first);
            return res;
        }
    }
}
