using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    sealed class Textbook : PrintedEdition
    {
        public Textbook()
        {
            Title = "Unnamed book";
            PublishingYear = 2012;
            PageAmount = 12;
        }

        public override string ToString()
        {
            return $"{Title}\t{PublishingYear}\t{PageAmount}\t{AuthorName}";
        }
        public override void ReadBook()
        {
            Console.WriteLine("Вы читаете книги в абстрактном классе");
        }
    }
}
