using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Author : Persona
    {
        public Author()
        {
            Name = "Unnamed";
            Gender = "Female";
        }

        public override string ToString()
        {
            return $"{Name}\t{Gender}";
        }
    }
}
