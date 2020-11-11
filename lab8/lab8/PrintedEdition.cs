using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public struct PrintedEdition
    {
        public string title;
        public short publishingYear;
        public int pageAmount;
        public int cost;

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
                publishingYear = value;
            }
        }

        public PrintedEdition(string title = "Unnamed", short year = 2020, int pages = 32, int cost = 12020)
        {
            this.title = title;
            this.publishingYear = year;
            this.pageAmount = pages;
            this.cost = cost;
        }
        public bool BigSmallBook()
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

        public override string ToString()
        {
            return $"{title}.{publishingYear}.{pageAmount}.{cost}";
        }
    }
}
