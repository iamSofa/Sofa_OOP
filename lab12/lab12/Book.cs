using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Book
    {
        // Поля класса
        private static int objectAmount;
        public readonly long id;
        public string title;
        public string[] authors;
        public const string publishingHouse = "Belarus";
        public short publishingYear;
        public int pageAmount;
        public long cost;
        public string bindingType;

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
        public void GetBook(string str)
        {
            Console.WriteLine("Book: " + str);
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
