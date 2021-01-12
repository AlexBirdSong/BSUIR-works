using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class Program
    {
      

        // описание прошитого бинарного дерева
        public class ThreadedBinaryTree
        {
            public ThreadedBinaryTree left, right;

            // значение ключа узла
            public int info;

            // левый предшественник
            public bool lthread;

            // правый предшественник
            public bool rthread;
        }

        // добавление узла в прошитое дерево
        public static ThreadedBinaryTree insert(ThreadedBinaryTree root, int ikey)
        {
            // поиск нужного узла
            ThreadedBinaryTree ptr = root;
            // ключ родительского элемента
            ThreadedBinaryTree par = null;
            while (ptr != null)
            {
                // если ключи дублируются 
                if (ikey == (ptr.info))
                {
                    Console.Write("Ключ дублируется!\n");
                    return root;
                }

                // обновление указателя родительского элемента
                par = ptr;

                // проходим левую часть дерева  
                if (ikey < ptr.info)
                {
                    if (ptr.lthread == false)
                    {
                        ptr = ptr.left;
                    }
                    else
                    {
                        break;
                    }
                }

                // проходим правую часть дерева 
                else
                {
                    if (ptr.rthread == false)
                    {
                        ptr = ptr.right;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // создаём новое дерево    
            ThreadedBinaryTree tmp = new ThreadedBinaryTree();
            tmp.info = ikey;
            tmp.lthread = true;
            tmp.rthread = true;

            if (par == null)
            {
                root = tmp;
                tmp.left = null;
                tmp.right = null;
            }
            else if (ikey < (par.info))
            {
                tmp.left = par.left;
                tmp.right = par;
                par.lthread = false;
                par.left = tmp;
            }
            else
            {
                tmp.left = par;
                tmp.right = par.right;
                par.rthread = false;
                par.right = tmp;
            }

            return root;
        }

        // возвращаем узел родитель элемента
        public static ThreadedBinaryTree inorderSuccessor(ThreadedBinaryTree ptr)
        {
            // если элемент справа, то выведем его
            if (ptr.rthread == true)
            {
                return ptr.right;
            }

            // иначе выдаём самый левый результат
            ptr = ptr.right;
            while (ptr.lthread == false)
            {
                ptr = ptr.left;
            }
            return ptr;
        }


        // функция обхода прошитого дерева
        public static void printInOrder(ThreadedBinaryTree root)
        {
            if (root == null)
            {
                Console.Write("Дерево пустое!");
            }

            // проходим до самого левого элемента.   
            ThreadedBinaryTree ptr = root;
            while (ptr.lthread == false)
            {
                ptr = ptr.left;
            }

            // выводим на экран предков узла один за одним
            while (ptr != null)
            {
                Console.Write("{0:D} ", ptr.info);
                ptr = inorderSuccessor(ptr);
            }
        }

        public static void Main()
        {
            // создаём экземпляр прошитого дерева
            ThreadedBinaryTree threadedBinaryTree = null;

      
                Random random = new Random();
                for (int n = 1; n < 16; n++)
                {
                    threadedBinaryTree = insert(threadedBinaryTree, random.Next(0, 100));
                }



            // вызов функции обход дерева
            Console.WriteLine("Обход прошитого дерева:");
            printInOrder(threadedBinaryTree);

            Console.ReadLine();
        }

    }
}

