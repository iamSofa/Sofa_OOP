using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Journal : PrintedEdition
    {
        public enum JournalType
        {
            Type1 = 0,
            Type2, Type3
        }
        public struct Description
        {
            public string genre;
            public string theme;
            public string description;
            public Description(string genre, string theme, string description)
            {
                this.genre = genre;
                this.theme = theme;
                this.description = description;
            }
        }
        public JournalType type;
        public Description descriptionJournal;
        public Journal() : base()
        {
            Title = "Unnamed book";
            PublishingYear = 1999;
            PageAmount = 30;
            descriptionJournal = new Description("Child", "Flowers", "Good");
            type = JournalType.Type3;
        }
        public override string ToString()
        {
            return $"{Title}\t{PublishingYear}\t{PageAmount}\t{AuthorName}\t{descriptionJournal.genre}\t{descriptionJournal.theme}\t{descriptionJournal.description}\t{type}";
        }
        public override void ReadBook()
        {
            Console.WriteLine("Вы читаете книги в абстрактном классе");
        }
    }
}
