using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    sealed class Textbook : PrintedEdition
    {
        public enum TextbookType
        {
            Type1 = 0,
            Type2, Type3
        }
        public struct Description
        {
            public string subject;
            public string description;
            public Description(string subject, string description)
            {
                this.subject = subject;
                this.description = description;
            }
        }
        public TextbookType type;
        public Description descriptionTextbook;
        public Textbook() : base()
        {
            Title = "Unnamed book";
            PublishingYear = 2012;
            PageAmount = 12;
            descriptionTextbook = new Description("Math", "So scary.");
            type = TextbookType.Type2;
        }

        public override string ToString()
        {
            return $"{Title}\t{PublishingYear}\t{PageAmount}\t{AuthorName}\t{descriptionTextbook.subject}\t{descriptionTextbook.description}\t{type}";
        }
        public override void ReadBook()
        {
            Console.WriteLine("Вы читаете книги в абстрактном классе");
        }
    }
}
