using lab3;
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
            Book book = new Book("Вино из одуванчиков", new string[2]{ "Sofiya Kuskova", "Khudnitskiy Dmitriy"});
            book.PageAmount = 120;
            book.Cost = (long)(book.PageAmount * 1.43);
            Console.WriteLine(book.ToString());
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
            get { return authors; }
            set { authors = value; }
        }

        public string PublishingHouse
        {
            get { return publishingHouse; }
        }

        public short PublishingYear
        {
            get { return publishingYear; }
            private set
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
                if (value < 0) return;
                else pageAmount = value;
            }
        }

        public long Cost
        {
            get { return cost; }
            set
            {
                if (value < 0) return;
                else cost = value;
            }
        }

        public string BindingType
        {
            get
            {
                if (bindingType.Length == 0) return "Без переплёта";
                else return bindingType;
            }
            set { bindingType = value; }
        }
        
        // Методы класса
        public static int GetObjectAmount()
        {
            return objectAmount;
        }

        // Конструкторы класса
        Book()
        {
            objectAmount++;
            id = DateTime.Now.GetHashCode();
            title = "Unnamed";
            bindingType = "Без переплёта";
        }
        static Book()
        {

        }

        public Book(string title, string[] authors)
        {
            Title = title;
            Authors = authors;
        }

        public Book(string publishingHouse, short publishingYear = 2020, string bindingType = "С переплётом")
        {

        }

        public Book(int pageAmount, ref long cost)
        {
            cost = (long)(pageAmount * 1.3);
        }

        public override bool Equals(object obj)
        {
            return (this.Title == ((Book)obj).Title);
        }

        public override string ToString()
        {
            return $"{Title} [{PageAmount}] {Cost}";
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }

}
