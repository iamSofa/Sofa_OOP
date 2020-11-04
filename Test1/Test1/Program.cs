using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1A
            Console.WriteLine(double.MinValue);

            //1B
            string c = Console.ReadLine();
            string d = Console.ReadLine();
            string a = String.Concat(c, d);
            Console.WriteLine(a);

            //1C
            int[][] arrayInt = { new int[3], new int[5] };

            for (int i = 0; i < arrayInt.Length; i++)
            {
                for (int j = 0; j < arrayInt[i].Length; j++)
                {
                    Console.Write("Введите значение: ");
                    arrayInt[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            foreach (int[] x in arrayInt)
            {
                foreach (int k in x)
                {
                    Console.Write("\t" + k);
                }
                Console.WriteLine();
            }

            //2
            Time time = new Time();
            time.Minutes = 23;
            time.Seconds = 12;

            Time time2 = new Time();
            time2.Minutes = 2;
            time2.Seconds = 45;
            Console.WriteLine(time==time2);
            Console.WriteLine(time>time2);

            //3
            Student student = new Student();
            Prepod prepod = new Prepod();
            IStudy stud;
            stud = student;
            IStudy prep;
            prep = prepod;
            stud.Study();
            ((Student)prep).Study();
            prep.Study();
        }

    }
    public class Time
    {
        private const int hours = 22;
        private int minutes;
        private int seconds;

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value > 60) return;
                else minutes = value;
            }
        }
        public int Hours
        {
            get { return hours; }
        }
        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value < 0 || value > 60) return;
                else seconds = value;
            }
        }

        public static bool operator ==(Time left, Time right)
        {
            if ((left.Minutes == right.Minutes)&&(left.Seconds == right.Seconds)) return true;
            else return false;
        }
        public static bool operator !=(Time left, Time right)
        {
            if (left.Minutes != right.Minutes) return true;
            else if (left.Seconds != right.Seconds) return true;
            else return false;
        }

        public static bool operator <(Time left, Time right)
        {
            if (left.Minutes < right.Minutes) return true;
            else if ((left.Minutes == right.Minutes) && (left.Seconds < right.Seconds)) return true;
            else return false;
        }
        public static bool operator >(Time left, Time right)
        {
            if (left.Minutes > right.Minutes) return true;
            else if ((left.Minutes == right.Minutes) && (left.Seconds > right.Seconds)) return true;
            else return false;
        }
    }
    interface IStudy
    {
        void Study();
    }
    class Student : IStudy
    {
        public void Study()
        {
            Console.WriteLine("Учусь");
        }
    }
    class Prepod : Student, IStudy
    {
        void IStudy.Study()
        {
            Console.WriteLine("Учу");
        }
    }
}
