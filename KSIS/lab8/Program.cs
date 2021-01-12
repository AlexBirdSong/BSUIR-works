using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    // описание узла дерева
    public class TreeNode
    {
        //поле для зранения значения узла
        private int data;
        public int Data
        {
            get { return data; }
        }

        //поле для хранения адреса правого узла потомка
        private TreeNode rightNode;
        
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        //поле для хранения адреса левого узла потомка
        private TreeNode leftNode;

        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        //поле для хранения состояния узла
        private bool isDeleted;
        public bool IsDeleted
        {
            get { return isDeleted; }
        }

        public TreeNode(int value)
        {
            data = value;
        }

        public void Delete()
        {
            isDeleted = true;
        }

        //функция поиска 
        public TreeNode Find(int value)
        {
            TreeNode currentNode = this;

            //перебираем элементы, пока не дойдем до конца дерева
            while (currentNode != null)
            {
                // если элемент не удален и его значение равно искомому, возвращаем текущий узел
                if (value == currentNode.data && isDeleted == false)
                {
                   return currentNode;
                }
                // если значение меньше искомого, возвращаем узел правого потомка
                else if (value > currentNode.data)
                {
                    currentNode = currentNode.rightNode;
                }
                // иначе, возвращаем узел левого потомка
                else
                {
                    currentNode = currentNode.leftNode;
                }
            }

            return null;
        }

        //функция вставки 
        public void Insert(int value)
        {
            // если значение больше или равно значению текущего узла, добавляем узел вправо 
            if (value >= data)
            {
                //если есть место для узла лобавляем его
                if (rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                //иначе вызываем функцию рекурсивно для правого потомка
                else
                {
                    rightNode.Insert(value);
                }
            }
            // иначе, добавляем узел влево
            else
            {
                //если есть место для узла лобавляем его
                if (leftNode == null)
                {
                    leftNode = new TreeNode(value);
                }
                //иначе вызываем функцию рекурсивно для левого потомка
                else
                {
                    leftNode.Insert(value);
                }
            }
        }




  
        //Обход прямым способом
        public void InOrderTraversal()
        {
            // если левый узел не пустой рекурсивно вызывай функцию
            if (leftNode != null)
                leftNode.InOrderTraversal();

            // вывод элемента
            Console.Write(data + " ");

            // если правый узел не пустой рекурсивно вызывай функцию
            if (rightNode != null)
                rightNode.InOrderTraversal();
        }

        //Обход симметричным способом
        public void PreOrderTraversal()
        {
            // вывод элемента
            Console.Write(data + " ");

            // если левый узел не пустой рекурсивно вызывай функцию
            if (leftNode != null)
                leftNode.PreOrderTraversal();

            // если правый узел не пустой рекурсивно вызывай функцию
            if (rightNode != null)
                rightNode.PreOrderTraversal();
        }

        //Обход обратным способом
        public void PostorderTraversal()
        {
            // если левый узел не пустой рекурсивно вызывай функцию
            if (leftNode != null)
                leftNode.PostorderTraversal();

            // если правый узел не пустой рекурсивно вызывай функцию
            if (rightNode != null)
                rightNode.PostorderTraversal();

            // вывод элемента
            Console.Write(data + " ");
        }
    }

    // описание дерева
    public class BinaryTree
    {
        // корневой элемент
        private TreeNode root;

        public TreeNode Root
        {
            get { return root; }
        }


        // функция поиска узла
        public TreeNode Find(int data)
        {
            // если корневой элемент не пустой, вызывай функцию рекурсивно
            if (root != null)
            {
                return root.Find(data);
            }

            // иначе, верни пустое значение
            else
            {
                return null;
            }
        }

        // функция вставки узла
        public void Insert(int data)
        {
            // если корневой элемент не пустой, вызывай функцию рекурсивно
            if (root != null)
            {
                root.Insert(data);
            }

            // иначе, создай новый узел
            else
            {
                root = new TreeNode(data);
            }
        }

        // функция удаления узла
        public void Remove(int data)
        {
            // текущий узел
            TreeNode current = root;
            // узел родитель
            TreeNode parent = root;
            //  состояние узла
            bool isLeftChild = false;

            // если текущий элемент пустой, ничего не удаляем
            if (current == null)
            {
                return;
            }

            // поиск узла с заданным значением
            while (current != null && current.Data != data)
            {
                // меняем текущий узел
                parent = current;

                // если значение удалемого узла меньше значения текущего
                if (data < current.Data)
                {
                    // движемся в сторону левого потомка
                    current = current.LeftNode;
                    isLeftChild = true;
                }
                // иначе, в сторону правого
                else
                {
                    current = current.RightNode;
                    isLeftChild = false;
                }
            }

            // если текущий элемент пустой, ничего не удаляем
            if (current == null)
            {
                return;
            }

            // если оба потомка пустые
            if (current.RightNode == null && current.LeftNode == null)
            {
                // если текущий элемент - корневой, удаляем его
                if (current == root)
                {
                    root = null;
                }
                // иначе
                else
                {
                    if (isLeftChild)
                    {
                        // удаляем у узла родителя ссылку на левого потомка
                        parent.LeftNode = null;
                    }
                    else
                    {
                        // удаляем у узла родителя ссылку на правого потомка
                        parent.RightNode = null;
                    }
                }
            }
            // пустой только правый потомок
            else if (current.RightNode == null)
            {
                // если текущий элемент - корневой, задаем его как левого потомка корневого узла
                if (current == root)
                {
                    root = current.LeftNode;
                }
                else
                {

                    if (isLeftChild)
                    {
                       // задаем левого потомка текущего узла, как левого потомка родителю 
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                        // задаем правого потомка текущего узла, как правого потомка родителю 
                        parent.RightNode = current.LeftNode;
                    }
                }
            
            // пустой только левый потомок
            else if (current.LeftNode == null)
            {
                // если текущий элемент - корневой, задаем его как правого потомка корневого узла
                if (current == root)
                {
                    root = current.RightNode;
                }
                else
                {

                    if (isLeftChild)
                    {
                        // задаем левого потомка текущего узла, как правого потомка родителю 
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {
                        // задаем правого потомка текущего узла, как левого потомка родителю 
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            // иначе создаем узел "наследник"
            else
            {
                TreeNode successor = GetSuccessor(current);
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftNode = successor;
                }
                else
                {
                    parent.RightNode = successor;
                }

            }

        }
        
        // функция задания узла "наследника"
        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightNode;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;
            }
            if (successor != node.RightNode)
            {
                parentOfSuccessor.LeftNode = successor.RightNode;
                successor.RightNode = node.RightNode;
            }
            successor.LeftNode = node.LeftNode;

            return successor;
        }

        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }


        public void PreorderTraversal()
        {
            if (root != null)
                root.PreOrderTraversal();
        }

        public void PostorderTraversal()
        {
            if (root != null)
                root.PostorderTraversal();
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            // создаем новый экземпляр бинарного дерева
            BinaryTree binaryTree = new BinaryTree();

            // случайным образом задаем узлы дерава
            Random random = new Random();
            for (int n = 1; n < 10; n++)
            {
                binaryTree.Insert(random.Next(0, 100));
            }

            // вызываем написанные функции для работы с бинарным деревом
            Console.WriteLine("Обход бинарного дерева прямым способом: ");
            binaryTree.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine("Обход бинарного дерева обратным способом: ");
            binaryTree.PostorderTraversal();
            Console.WriteLine();
            Console.WriteLine("Обход бинарного дерева симметричным способом: ");
            binaryTree.PreorderTraversal();
            Console.WriteLine();
            Console.WriteLine("Поиск узла в бинарном дереве: ");
            Console.WriteLine("Введите значение узла: ");
            int findValue = Convert.ToInt32(Console.ReadLine());

            if (binaryTree.Find(findValue) != null)
            {
                Console.WriteLine($"Результат поиска: {binaryTree.Find(findValue).Data}");
            }
            else
            {
                Console.WriteLine($"Значение не найдено!");
            }

            Console.Write("Удалить узел со значением: ");
            int removeValue = Convert.ToInt32(Console.ReadLine());
            binaryTree.Remove(removeValue);

            Console.WriteLine("Результат удадения: ");
            binaryTree.InOrderTraversal();

            Console.ReadLine();
        }

    }
}

