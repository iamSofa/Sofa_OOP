using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Created : NullReferenceException
    {
        public Created(string msg) : base(msg) { }
    }
}
