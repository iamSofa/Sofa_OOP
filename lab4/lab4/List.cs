using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace lab4
{
    public class List
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

        int[] elements;
        public int Length { get; private set; }

        public Owner owner;
        public DateTime date;

        public int this[int i]
        {
            get { return elements[i]; }
            set { elements[i] = value; }
        }
        private List()
        {
            owner = new Owner("Sofiya", "KHCorp");
            date = new DateTime();
        }

        public List(int[] elements) : this()
        {
            this.elements = elements;
            Length = elements.Length;

            string str = String.Empty;
        }
        public List(int size) : this()
        {
            elements = new int[size];
            Length = size;
            for (int i = 0; i < Length; i++)
            {
                elements[i] = Program.rand.Next(-10, 10);
            }
        }

        public static List operator>>(List left, int right)
        {
            right--;
            int[] buffer = new int[left.Length - 1];
            for (int i = 0; i < right; i++)
            {
                buffer[i] = left.elements[i];
            }
            for (int i = right; i < buffer.Length; i++)
            {
                buffer[i] = left.elements[i + 1];
            }
            return new List(buffer);
        }
        
        public static List operator+(List left, int right)
        {
            int[] buffer = new int[left.Length + 1];
            for (int i = 0; i < right; i++)
            {
                buffer[i] = left.elements[i];
            }
            buffer[--right] = Program.rand.Next(-10, 10);
            for (int i = right + 1; i < buffer.Length; i++)
            {
                buffer[i] = left.elements[i - 1];
            }
            return new List(buffer);
        }

        public static bool operator !=(List left, List right)
        {
            if (left.Length != right.Length) return true;
            for (int i = 0; i < left.Length; i++)
            {
                if (left.elements[i] != right.elements[i]) return true;
            }
            return false;
        }

        public static bool operator ==(List left, List right)
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
    }
}
