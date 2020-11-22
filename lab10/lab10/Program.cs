using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
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
            Console.WriteLine();
            if (hash.Contains(Convert.ToChar(Console.ReadLine())))
            {
                Console.WriteLine("Этот элемент присутствует в коллекции\n");
            }
            else
            {
                Console.WriteLine("В коллекции нет такого элемента\n");
            }
        }
    }
}
