using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Persona
    {
        private string gender;
        private string[] name;

        public string[] Name
        {
            get { return name ?? new string[] { "None" }; }
            set { name = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
