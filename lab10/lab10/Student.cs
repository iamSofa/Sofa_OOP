using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Student
    {
        private string name;
        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
        public Student(string val)
        {
            Name = val;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
