using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class PrintedEdition 
    {
        private string title;
        private short publishingYear;
        private int pageAmount;
        Author author;

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
    }
}
