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
            book.First();
            book.Title = "Лолита";
            book.AuthorName = "Набоков";
            Console.WriteLine(book.ToString());
            book.BigSmallBook();
            book.ReadBook();
            ((Interface1)book).ReadBook();
            book.Last();
            Console.WriteLine();

            Textbook textbook = new Textbook();
            textbook.Title = "Физика";
            textbook.AuthorName = "Буцень";
            Console.WriteLine(textbook);
            textbook.BigSmallBook();
            Console.WriteLine();

            Journal journal = new Journal();
            journal.Title = "vogue";
            journal.AuthorName = "D";
            Console.WriteLine(journal);
            textbook.BigSmallBook();
            Console.WriteLine();

            Persona persona = new Persona();
            persona.Name = "Anna";
            persona.Gender = "Man";

            if (book is Book)
                Console.WriteLine("Объект совпадает с типом Book");
            else
                Console.WriteLine("Объект не совпадает с типом Book");

            if (persona is Author)
                Console.WriteLine("Объект совпадает с типом Book");
            else
                Console.WriteLine("Объект не совпадает с типом Book");
            Console.WriteLine();

            Printer printer = new Printer();
            PrintedEdition[] objArr = new PrintedEdition[] { book, textbook, journal };
            for (int i = 0; i < objArr.Length; i++)
            {
                Console.WriteLine(printer.IAmPrinting(objArr[i]));
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
