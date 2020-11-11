using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace lab8
{
    public class List<T> : IInterfaceGeneric<T>
        where T : struct
    {
        public class Owner
        {
            public int ID { get; private set; }
            public string Name { get; private set; }
            public string Company { get; private set; }
            public Owner(string name, string company)
            {
                ID = DateTime.Now.GetHashCode();
                Name = name;
                Company = company;
            }
        }

        T[] elements;
        public int Length { get; private set; }

        public Owner owner;
        public DateTime date;

        public T this[int i]
        {
            get { return elements[i]; }
            set { elements[i] = value; }
        }
        private List()
        {
            owner = new Owner("Sofa", "Corporation");
            date = new DateTime();
        }

        public List(T[] elements) : this()
        {
            this.elements = elements;
            Length = elements.Length;
        }
        public List(int size) : this()
        {
            elements = new T[size];
            Length = size;
            for (int i = 0; i < Length; i++)
            {
                try
                {
                    elements[i] = (T)(object)Program.rand.Next(10, 99);
                }
                catch (Exception e)
                {
                    elements[i] = default;
                }
            }
        }

        public static List<T> operator >>(List<T> left, int right)
        {
            right--;
            T[] buffer = new T[left.Length - 1];
            for (int i = 0; i < right; i++)
            {
                buffer[i] = left.elements[i];
            }
            for (int i = right; i < buffer.Length; i++)
            {
                buffer[i] = left.elements[i + 1];
            }
            return new List<T>(buffer);
        }

        public static List<T> operator +(List<T> left, int right)
        {
            T[] buffer = new T[left.Length + 1];
            for (int i = 0; i < right; i++)
            {
                buffer[i] = left.elements[i];
            }
            try
            {
                buffer[--right] = (T)(object)Program.rand.Next(-10, 10);
            }
            finally
            {
                buffer[--right] = new T();
            }
            for (int i = right + 1; i < buffer.Length; i++)
            {
                buffer[i] = left.elements[i - 1];
            }
            return new List<T>(buffer);
        }

        public static bool operator !=(List<T> left, List<T> right)
        {
            if (left.Length != right.Length) return true;
            for (int i = 0; i < left.Length; i++)
            {
                if ((object)left.elements[i] != (object)right.elements[i]) return true;
            }
            return false;
        }

        public static bool operator ==(List<T> left, List<T> right)
        {
            return !(left != right);
        }

        public override string ToString()
        {
            string result = String.Empty;
            for (int i = 0; i < Length; i++)
            {
                result += $"\t{elements[i]}";
            }
            return result;
        }

        //lab8
        public void Insert(T value)
        {
            T[] buffer = new T[Length + 1];
            for (int i = 0; i < Length; i++)
            {
                buffer[i] = elements[i];
            }
            buffer[Length] = value;
            elements = buffer;
            Length++;
        }

        public void Delete()
        {
            T[] buffer = new T[--Length];
            for (int i = 0; i < Length; i++)
            {
                buffer[i] = elements[i];
            }
            elements = buffer;
        }

        public void View()
        {
            Console.WriteLine($"\tList:\t{ToString()}");
        }
    }
}
