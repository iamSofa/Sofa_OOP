using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Book : PrintedEdition
    {
        public Book() 
        {
            Title = "Unnamed book";
            PublishingYear = (short)DateTime.Now.Year;
            PageAmount = 125;
            Author a = new Author
            {
                Name = new string[] { "Набоков" }
            };
        }
        public override string ToString()
        {
            return $"{Title}\t{PublishingYear}\t{PageAmount}";
        }
    }
}
