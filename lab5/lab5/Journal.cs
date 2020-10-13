using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Journal : PrintedEdition
    {
        public Journal()
        {
            Title = "Unnamed book";
            PublishingYear = 1999;
            PageAmount = 30;
        }
        public override string ToString()
        {
            return $"{Title}\t{PublishingYear}\t{PageAmount}\t{AuthorName}";
        }
        public override void ReadBook()
        {
            Console.WriteLine("Вы читаете книги в абстрактном классе");
        }
        public void Last()
        {
            Console.WriteLine("Ты закончил читать книги!");
        }
    }
}
