using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Negative : ArgumentException
    {
        private double value;
        public Negative(string message, double value) : base(message)
        {
            this.value = value;
        }
    }
}
