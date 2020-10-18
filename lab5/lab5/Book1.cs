using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public partial class Book
    {
        public enum BookType
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
    }
}
