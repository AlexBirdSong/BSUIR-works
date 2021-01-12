using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PriorityQueue
{
    public class ListItem
    {
        public int Priority { get; set; }
        public string Text { get; set; }

        public ListItem(int priority, string item)
        {
            Priority = priority;
            Text = item;
        }
    }

    private List<ListItem> list = new List<ListItem>();

    // Функция добавления элементов
    public void Enqueue(string newItem, int priority)
    {
        ListItem li = new ListItem(priority, newItem);

        list.Add(li);


        // сортировка список по приоритету
        list = list.OrderBy(a => a.Priority).ToList();

        // вывод добавленного элемента
        Console.WriteLine("Добавлен эдемент с названием: " + newItem + " с приоритетом: " + priority);
    }

    // Функция удаления элементов
    public string Dequeue()
    {
        // сортировка по приоретету 
        ListItem entry = list.OrderBy(a => a.Priority).FirstOrDefault();


        // вывод сообщения если очередь пустая
        if (entry == null)
        {
            throw new InvalidOperationException("В очереди больше нет элементов");
        }

        list.Remove(entry);

        return entry.Text;
    }

    // Функция поиска элементов
    public ListItem Search(string searchElement)
    {
        // Поиск элемента по названию
        ListItem result = list.ToList().Find(item => item.Text == searchElement);

        if (result == null)
        {
            throw new InvalidOperationException("Элемент не найден");
        }

        return result;
    }

    // Функция для вывода элементов
    public void DisplayList()
    {
        Console.WriteLine("Элементы в очереди: ");
        list.ForEach(item => {
            Console.WriteLine(item.Text);
        });
    }
}

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем экземпляр приорететной очереди
            var list = new PriorityQueue();

            // добавляем элементы
            list.Enqueue("Первый", 2);
            list.Enqueue("Второй", 5);
            list.Enqueue("Третий", 1);
            list.Enqueue("Четвертый", 4);
            list.Enqueue("Пятый", 3);

            // выводим список
            list.DisplayList();

            // удаление элемента
            Console.WriteLine("Удаляем элемент, с наименьшим приоритетом, удален: " + list.Dequeue());

            // выводим список для проверки удаления элемента
            list.DisplayList();

            //поиск жлемента
            Console.WriteLine("Элемент 'Пятый' найден, его приоритет: " + list.Search("Пятый").Priority);

            Console.ReadKey();
        }
    }
}
