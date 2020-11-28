using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novenber", "December" };
            string[] someMonths = { "June", "July", "August", "January", "February", "December" };
            foreach (string obj in months)
                Console.Write(obj + " ");

            Console.Write("\n\nВведите количество букв: ");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nМесяцы с заданой длинной: ");
            IEnumerable<string> monthsLength = from n in months
                                          where n.Length == length
                                          select n;
            foreach (string obj in monthsLength)
                Console.Write(obj + " ");

            Console.WriteLine("\n\nЗимние и летние месяцы: ");
            IEnumerable<string> summerWinter = months.Intersect<string>(someMonths);
            foreach (string obj in summerWinter)
                Console.Write(obj + " ");

            Console.WriteLine("\n\nМесяцы в алфавитном порядке: ");
            IEnumerable<string> alphabet = from n in months
                                          orderby n
                                          select n;
            foreach (string obj in alphabet)
                Console.Write(obj + " ");

            Console.WriteLine("\n\nМесяцы, содержащие букву u: ");
            IEnumerable<string> monthsU = from n in months
                                          where n.Contains('u')
                                          select n;
            foreach (string obj in monthsU)
                Console.Write(obj + " ");

            Console.WriteLine("\n\nМесяцы с длинной не менее 4: ");
            IEnumerable<string> months4 = from n in months
                                          where n.Length >= 4
                                          select n;
            foreach (string obj in months4)
                Console.Write(obj + " ");
            Console.WriteLine("\n\n");
            //2, 3
            List<Matrix> matrixList = new List<Matrix>();
            Matrix matrix1 = new Matrix(6, 5);
            matrix1.AddRandom();
            Matrix matrix2 = new Matrix(4, 4);
            matrix2.AddRandom();
            Matrix matrix3 = new Matrix(5, 7);
            matrix3.AddRandom();
            matrixList.Add(matrix1); 
            matrixList.Add(matrix2);
            matrixList.Add(matrix3);
            matrix1.Output(); Console.WriteLine();
            matrix2.Output(); Console.WriteLine();
            matrix3.Output(); Console.WriteLine();

            Console.WriteLine("\nМатрица с наименьшим количеством единиц: ");
            var rez = from n in matrixList
                          orderby n.NumberOfUnits(1)
                          select n;
            rez.First().Output();

            Console.WriteLine("\nCписок матриц с равным количеством заданного символа в каждой строке: ");
            //?

            Console.WriteLine("\nМаксимальная матрица: ");
            var rez2 = from n in matrixList
                      orderby n.NumberOfUnits(1)
                      select n;
            rez2.Last().Output();

            Console.WriteLine("\nКоличество матриц заданного размера: ");
            int len = Convert.ToInt32(Console.ReadLine());
            int width = Convert.ToInt32(Console.ReadLine());
            var rez3 = from n in matrixList
                       where ((n.length == len)&&(n.width == width))
                       select n;
            rez3.First().Output();

            Console.WriteLine("\nУпорядоченный список матриц по количеству единиц: ");
            var rez4 = from n in matrixList
                      orderby n.NumberOfUnits(1)
                      select n;
            foreach (var v in rez4)
            {
                v.Output(); Console.WriteLine();
            }

            //4
            string[] may = { "May" };
            Console.WriteLine("\n\n\nСобственный запрос: ");
            var monthsMy = months.Take(8).Skip(3).Where(t => (t.StartsWith("M"))||(t.StartsWith("A"))).OrderBy(t => t);
            foreach (string obj in monthsMy)
                Console.Write(obj + "\t");
            Console.WriteLine("\n");

            //5
            List<Film> films = new List<Film>()
                {
                   new Film { Title = "1", Producer = "Producer1" },
                   new Film { Title = "2", Producer = "Producer2" }
                };
            List<Book> books = new List<Book>()
                {
                   new Book { Title = "1", Author = "Author3" },
                   new Book { Title = "2", Author = "Author4" }
                };
            
            var rez6 = books.Join(films,
             p => p.Title, 
             t => t.Title,
             (p, t) => new { Producer = t.Producer, Title = p.Title, Author = p.Author });
            foreach (var item in rez6)
            {
                Console.WriteLine($"{item.Producer}; {item.Title}; {item.Author}");
            }

            Console.ReadKey();
        }
    }
}
