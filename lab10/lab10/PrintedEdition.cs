using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class PrintedEdition
    {
        public string title;
        public short publishingYear;
        public int pageAmount;

        public PrintedEdition ()
        {
            Title = "No name";
            PublishingYear = 2018;
            PageAmount = 23;
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
                publishingYear = value;
            }
        }
        public override string ToString()
        {
            return $"{Title}    {PublishingYear}    {PageAmount}";
        }
    }
}
