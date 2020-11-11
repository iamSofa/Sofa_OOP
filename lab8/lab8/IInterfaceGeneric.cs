using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    interface IInterfaceGeneric<T>
    {
        void Insert(T value);
        void Delete();
        void View();

    }
}
