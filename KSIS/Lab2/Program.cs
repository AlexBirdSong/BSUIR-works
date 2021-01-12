using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2
{
    class Program
    {

        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }

        public class LinkedList<T> : IEnumerable<T>  // односвязный список
        {
            Node<T> head; // головной/первый элемент
            Node<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);

                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;

                count++;
            }
      
            public int Count { get { return count; } }

           
            // добвление в начало
            public void AppendFirst(T data)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head = node;
                if (count == 0)
                    tail = head;
                count++;
            }


      
            // реализация интерфейса IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }

    

        static void Main(string[] args)
        {
            LinkedList<int> linkedList1 = new LinkedList<int>();
            LinkedList<int> linkedList2 = new LinkedList<int>();
            int elemment;

            // добавление элементов
            Console.WriteLine("Введите элементы 1-го списка: ");
            for(int i=0; i<=4; i++)
            {
                elemment = Convert.ToInt32(Console.ReadLine());
                linkedList1.Add(elemment);
            }

            Console.WriteLine("Введите элементы 2-го списка: ");
            for (int i = 0; i <= 4; i++)
            {
                elemment = Convert.ToInt32(Console.ReadLine());
                linkedList2.Add(elemment);
            }


            // выводим элементы

            Console.WriteLine("Исходные списки: ");
            foreach (var item in linkedList1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in linkedList2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // сортировка по возростанию с помощью интерфейса ienumerable
            Console.WriteLine("Сортированные по возрастанию списки: ");
            var sortedList1 = from u in linkedList1  
                              orderby u ascending
                              select u;

            foreach (var u in sortedList1)
                Console.Write(u + " ");

            Console.WriteLine();
            var sortedList2 = from u in linkedList2
                              orderby u ascending
                              select u;

            foreach (var u in sortedList2)
                Console.Write(u + " ");

            Console.WriteLine();

            // создаем третий список      

            LinkedList<int> linkedList3 = new LinkedList<int>();

            // добавлем в него элементы из 1 и 2 списка
            foreach (var u in sortedList1)
                linkedList3.Add(u);
            foreach (var u in sortedList2)
                linkedList3.Add(u);

            // сортировка по убыванию с помощью интерфейса ienumerable

            var sortedList3 = from u in linkedList3
                              orderby u descending
                              select u;

            // вывод нового списка
            Console.WriteLine("Новый список(отсортирован по убыванию): ");
            foreach (var item in sortedList3)
            {
                Console.Write(item + " ");
            }


       
            Console.ReadKey();


        }
    }
}
