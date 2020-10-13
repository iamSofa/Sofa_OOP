using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Persona
    {
        public string gender;
        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
