using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Library
    {
        PrintedEdition[] m_items;
        
        public int Length { get => m_items.Length; }
        
        public PrintedEdition this[int i]
        {
            get
            {
                return m_items[i];
            }
            set
            {
                m_items[i] = value;
            }
        }

        public Library(PrintedEdition[] items)
        {
            m_items = items;
        }

        public void AddEdition(PrintedEdition item)
        {
            PrintedEdition[] buff = new PrintedEdition[m_items.Length + 1];
            for (int i = 0; i < m_items.Length; i++)
            {
                buff[i] = m_items[i];
            }
            buff[buff.Length - 1] = item;
            m_items = buff;
        }
        public void DeleteEdition(int j)
        {
            PrintedEdition[] buff = new PrintedEdition[m_items.Length - 1];
            for (int i = 0, y = 0; i < m_items.Length; i++, y++)
            {
                if (i == j)
                {
                    if (i == m_items.Length - 1)
                    {
                        break;
                    }
                    buff[y] = m_items[i + 1];
                    i++;
                }
                else
                {
                    buff[y] = m_items[i];
                }
            }
            m_items = buff;
        }
        public void PrintEditions()
        {
            for (int i = 0; i < m_items.Length; i++)
            {
                Console.WriteLine(m_items[i]);
            }
        }
        public class LibraryController
        {
            public Library library;
            public LibraryController(Library lib)
            {
                library = lib;
            }

            public void OutputByYear(int year)
            {
                for (int i = 0; i < library.Length; i++)
                {
                    if (library[i].publishingYear > year)
                    {
                        Console.WriteLine(library[i]);
                    }
                }
            }

            public int AmountTextbooks()
            {
                int amount = 0;
                for (int i = 0; i < library.Length; i++)
                {
                    if (library[i] is Textbook)
                    {
                        amount++;
                    }    
                }
                return amount;
            }

            public long TotalCost()
            {
                long cost = 0;
                for (int i = 0; i < library.Length; i++)
                {
                    cost += library[i].cost;
                }
                return cost;
            } 
        }
    }
}
