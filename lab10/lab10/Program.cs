using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Задание 1\n");
            ArrayList arrList = new ArrayList();
            Random rand = new Random();
            for (int i = 0; i < 7; i++)
            {
                arrList.Add(Convert.ToString(rand.Next(-15, 15)));
            }
            arrList.Add("Hello");
            Student person = new Student("Sofa Kuskova");
            arrList.Add(person);
            foreach (object i in arrList)
            {
                Console.Write(i + "   ");
            }
            Console.Write("\nВведите элемент для удаления: ");
            arrList.Remove(Console.ReadLine());
            foreach (object i in arrList)
            {
                Console.Write(i + "   ");
            }
            Console.WriteLine("\nКоличество элементов: " + arrList.Count);
            Console.Write("Введите элемент, который надо найти: ");
            if (arrList.Contains(Console.ReadLine()))
            {
                Console.WriteLine("Этот элемент присутствует в коллекции\n");
            }
            else
            {
                Console.WriteLine("В коллекции нет такого элемента\n");
            }

            //2
            Console.WriteLine("\nЗадание 2\n");
            LinkedList<char> LinkList = new LinkedList<char>();
            LinkList.AddLast('a');
            LinkList.AddFirst('c');
            LinkList.AddAfter(LinkList.Last, 't');
            LinkList.AddAfter(LinkList.Last, 's');
            LinkList.AddAfter(LinkList.Last, 'y');
            foreach (char i in LinkList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("\nВведите количство элементов для удаления: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                LinkList.RemoveLast();
            }
            foreach (char i in LinkList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            LinkedListNode<char> node = LinkList.First;
            LinkList.AddAfter(node, 'e');
            LinkList.AddBefore(node, 'p');
            foreach (char i in LinkList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            HashSet<char> hash = new HashSet<char>();
            node = LinkList.First;
            while (node != null)
            {
                hash.Add(node.Value);
                node = node.Next;
            }
            foreach (char i in hash)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nВведите символ: ");
            if (hash.Contains(Convert.ToChar(Console.ReadLine())))
            {
                Console.WriteLine("Этот элемент присутствует в коллекции\n");
            }
            else
            {
                Console.WriteLine("В коллекции нет такого элемента\n");
            }
            Console.WriteLine();

            //3
            Console.WriteLine("\nЗадание 3\n");
            LinkedList<PrintedEdition> book = new LinkedList<PrintedEdition>();
            LinkedListNode<PrintedEdition> book1 = book.AddLast(new PrintedEdition() { Title = "Book2", PublishingYear = 1879});
            book.AddLast(new PrintedEdition() { Title = "Book3", PublishingYear = 2009 });
            book.AddFirst(new PrintedEdition() { Title = "Book1", PublishingYear = 2019 });
            book.AddLast(new PrintedEdition() { Title = "Book5", PublishingYear = 1908, PageAmount = 123 });
            foreach (PrintedEdition i in book)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine("\nВведите количство элементов для удаления: ");
            int m = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                book.RemoveLast();
            }
            foreach (PrintedEdition i in book)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            PrintedEdition book2 = new PrintedEdition
            {
                PageAmount = 123
            };
            LinkedListNode<PrintedEdition> node1 = book.First;
            book.AddAfter(node1, book2);
            foreach (PrintedEdition i in book)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            HashSet<PrintedEdition> hash2 = new HashSet<PrintedEdition>();
            node1 = book.First;
            while (node1 != null)
            {
                hash2.Add(node1.Value);
                node1 = node1.Next;
            }
            Console.WriteLine("Вывод элементов из коллекции HashSet");
            foreach (PrintedEdition i in hash2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            if (hash2.Contains(book2))
            {
                Console.WriteLine("Этот элемент присутствует в коллекции\n");
            }
            else
            {
                Console.WriteLine("В коллекции нет такого элемента\n");
            }

            //4
            Console.WriteLine("\nЗадание 4\n");
            ObservableCollection<PrintedEdition> books = new ObservableCollection<PrintedEdition>
            {
                new PrintedEdition { Title = "Book11"},
                new PrintedEdition { Title = "Book12"},
                new PrintedEdition { Title = "Book13"}
            };
            foreach (PrintedEdition i in books)
            {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine();
            books.CollectionChanged += Books_CollectionChanged;

            books.Add(new PrintedEdition { Title = "Book14" });
            books.RemoveAt(1);
            books[0] = new PrintedEdition { Title = "Book15" };

            foreach (PrintedEdition i in books)
            {
                Console.WriteLine(i.Title);
            }

            Console.ReadKey();
        }
        private static void Books_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // добавление
                    PrintedEdition newBook = e.NewItems[0] as PrintedEdition;
                    Console.WriteLine($"Добавлен новый объект: {newBook.Title}");
                    break;
                case NotifyCollectionChangedAction.Remove: // удаление
                    PrintedEdition oldBook = e.OldItems[0] as PrintedEdition;
                    Console.WriteLine($"Удален объект: {oldBook.Title}");
                    break;
                case NotifyCollectionChangedAction.Replace: // замена
                    PrintedEdition replacedBook = e.OldItems[0] as PrintedEdition;
                    PrintedEdition replacingBook = e.NewItems[0] as PrintedEdition;
                    Console.WriteLine($"Объект {replacedBook.Title} заменен объектом {replacingBook.Title}");
                    break;
            }
        }
    }
}
