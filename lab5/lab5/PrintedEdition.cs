using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public abstract class PrintedEdition
    {
        private string title;
        private short publishingYear;
        private int pageAmount;
        Author author = new Author();

        public string AuthorName
        {
            get { return author.Name; }
            set { author.Name = value; }
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
        public string Title
        {
            get { return title; }
            set { title = value; }
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

        virtual public bool BigSmallBook()
        {
            if (this.PageAmount > 100)
            {
                Console.WriteLine("Эта книга большя!");
                return true;
            }
            else
            {
                Console.WriteLine("Это маленькая книга)");
                return false;
            }
        }
        public abstract void ReadBook();
    }
}
