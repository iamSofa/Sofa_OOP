using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class TypeValue : Exception
    {
        public int Type { get; set; }

        public TypeValue(string message, int value) : base(message)
        {
            Type = value;
        }
    }
}
