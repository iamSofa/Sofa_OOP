using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.Title = "Лолита";
            Console.WriteLine(book);
        }
    }
}
