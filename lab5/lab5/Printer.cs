using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Printer
    {
        public string IAmPrinting(PrintedEdition obj)
        {
            if (obj is Book) return (obj as Book).ToString();
            else if (obj is Textbook) return (obj as Textbook).ToString();
            else if (obj is Journal) return (obj as Journal).ToString();
            else return "no";
        }
    }
}
