using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Book : PrintedEdition, Interface1
    {
        public Book() 
        {
            Title = "Unnamed book";
            PublishingYear = (short)DateTime.Now.Year;
            PageAmount = 125;
        }

        public override string ToString()
        {
            return $"{Title}\t{PublishingYear}\t{PageAmount}\t{AuthorName}";
        }
        public override bool Equals(object obj)
        {
            return (this.Title == ((Book)obj).Title);
        }
        public override int GetHashCode()
        {
            return PageAmount.GetHashCode();
        }
        override public bool BigSmallBook()
        {
            if (this.PageAmount > 100)
            {
                Console.WriteLine("Эта книга хорошая!");
                return true;
            }
            else
            {
                Console.WriteLine("Это маленькая книга, а это хорошо)");
                return false;
            }
        }
        public void First()
        {
            Console.WriteLine("Ты начал читать книги!");
        }
        public void Last()
        {
            Console.WriteLine("Ты закончил читать книги!");
        }
        public override void ReadBook()
        {
            Console.WriteLine("Вы читаете книги в абстрактном классе"); 
        }
        void Interface1.ReadBook()
        {
            Console.WriteLine("Вы читатете книги в интерфейсе");
        }
    }
}
