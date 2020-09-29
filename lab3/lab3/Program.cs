using lab3;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[12];
            for (int i = 0; i < books.Length; i++)
            {
                if (i < 4)
                {
                    books[i] = new Book();
                    if (i % 2 == 0)
                    {
                        books[i].Title = "Лолита";
                        books[i].Authors = new string[] { "Набоков" };
                        books[i].PublishingYear = 2016;
                    }
                }
                else if (i < 8)
                {
                    books[i] = new Book("Мятная сказка", new string[] { "Полярный" }  );
                    books[i].PublishingYear = 2002;
                }
                else
                {
                    books[i] = new Book("Вино из одуванчиков");
                    books[i].PublishingYear = 1993;
                }
                Console.WriteLine($"{books[i]}\t{books[i].GetType()}");
            }
          
            Console.WriteLine("Количество элементов: " + Book.GetObjectAmount());
            Console.WriteLine("Сравнение одинаковых объектов: " + books[2].Equals(books[0]));
            Console.WriteLine("Сравнение разных объектов: " + books[5].Equals(books[9]));

            Console.Write("Введите автора: ");
            string author = Console.ReadLine();
            foreach (var book in books)
            {
                bool result;
                book.AmIAuthor(author, out result);
                if (result)
                    Console.WriteLine(book);
            }
            Console.Write("Введите год: ");
            int year = Convert.ToInt32(Console.ReadLine());
            foreach (var book in books)
            {
                if (book.PublishingYear < year)
                    Console.WriteLine(book);
            }

            var anon = new { Title = "Book", Cost = 200 };
            Console.WriteLine(anon.GetType());
            Console.WriteLine(anon);
            Console.ReadKey();
        }
    }

    public partial class Book
    {
        // Поля класса
        private static int objectAmount;
        private readonly long id;
        private string title;
        private string[] authors;
        private const string publishingHouse = "Belarus";
        private short publishingYear;
        private int pageAmount;
        private long cost;
        private string bindingType;

        public static string[] availableBindingTypes;

        // Свойства класса 
        public long ID
        {
            get { return id; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string[] Authors
        {
            get { return authors ?? new string[] { "None" }; }
            set { authors = value; }
        }

        public string PublishingHouse
        {
            get { return publishingHouse; }
        }

        public short PublishingYear
        {
            get { return publishingYear; }
            set
            {
                if (value < 1564 || value > DateTime.Now.Year) return;
                else publishingYear = value;
            }
        }

        public int PageAmount
        {
            get { return pageAmount; }
            set
            {
                if (value < 1) return;
                else pageAmount = value;
            }
        }

        public long Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0 || value > 2*10e2) return;
                else cost = value;
            }
        }

        public string BindingType
        {
            get
            {
                if (bindingType?.Length == 0) return "Без переплёта";
                else return bindingType;
            }
            set
            {
                if (availableBindingTypes.Contains(value))
                    bindingType = value;
            }
        }
        
        // Методы класса
        public static int GetObjectAmount()
        {
            return objectAmount;
        }
        
        public static string GetInformationAbout()
        {
            return "This is class Book";
        }
        public void AmIAuthor(string author, out bool result)
        {
            result = authors.Contains(author);
        }

        public void CalculateCost(ref int otherCost)
        {
            otherCost = (int)(PageAmount * Cost * 1.3);
        }

        // Конструкторы класса
        private Book(int hash)
        {
            id = hash.GetHashCode();
            objectAmount++;
            authors = new string[] { "Linda Mark" };
        }
        public Book() : this(DateTime.Now.Millisecond)
        {
            Title = "Unnamed book";
            Authors = new string[]{ "Alexandr Polyrny" };
            PublishingYear = (short)DateTime.Now.Year;
            PageAmount = 125;
            Cost = (long)(PageAmount * 1.25);
        }
        public Book(string title, string[] authors) : this(DateTime.Now.Millisecond)
        {
            Title = title;
            Authors = authors;
        }
        public Book(string title, int pageAmount = 240, long cost = 40) : this(DateTime.Now.Millisecond)
        {
            Title = title;
            BindingType = "Without";
        }
        static Book()
        {
            availableBindingTypes = new string[]{ "Бумага", "Картон" };
        }
        public override bool Equals(object obj)
        {
            return (this.Title == ((Book)obj).Title);
        }

        public override string ToString()
        {
            return $"{Title}\t{Authors[0]}\t{PublishingHouse}\t{PublishingYear}\t{PageAmount}\t{Cost}\t{BindingType}";
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }

}
