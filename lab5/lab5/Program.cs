using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            //lab5
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
            
            //lab6
            Console.WriteLine("Lab6");

            Library bookFromLibrary = new Library(objArr);
            bookFromLibrary.PrintEditions();
            Console.WriteLine();
            bookFromLibrary.DeleteEdition(1);
            bookFromLibrary.PrintEditions();
            Console.WriteLine();
            bookFromLibrary.AddEdition(textbook);
            bookFromLibrary.PrintEditions();

            Library.LibraryController library1 = new Library.LibraryController(bookFromLibrary);
            Console.WriteLine();
            Console.Write("Количество учебников:");
            Console.WriteLine(library1.AmountTextbooks());
            Console.WriteLine();
            Console.Write("Список печатных изданий старше 1999 года:");
            library1.OutputByYear(1999);
            Console.WriteLine();
            Console.Write("Общая цена всех печатных изданий: ");
            Console.WriteLine(library1.TotalCost() + " " + "рублей");

            //lab7 

            Console.WriteLine("\nLab7");

            Textbook textbook1 = new Textbook();
            try
            {
                textbook1.PublishingYear = -55;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message); 
            }
            finally
            {
                Console.WriteLine("Введите новое число");
                textbook1.PublishingYear = (short)Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine();
            try
            {
                Journal journal1 = new Journal(-2);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Book book1 = new Book();
            try
            {
                book1.Type = (Book.BookType)125;
            }
            catch(Exception)
            {
                Console.WriteLine("Получена ошибка!");
            }

            Book edition = null;
            try
            {
                edition.cost = 200;
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine();
                Console.WriteLine(exception.TargetSite);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tОшибка!\t" + ex.Message);
            }

            try
            {
                book1.cost /= 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Деление на ноль!\t" + ex.Source);
            }

            int[] a = null;
            Debug.Assert(a != null, "Ссылка на нуль!");

            Console.ReadKey();
        }
    }
}
