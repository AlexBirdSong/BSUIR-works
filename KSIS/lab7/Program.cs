using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Program
    {
        // функция преобразования строки из инфиксной формы в постфиксную
        private static bool ConvertToPostfix(string infix, out string postfix)
        {
            postfix = String.Empty;
            var stack = new Stack<char>();

            // анализируем каждый символ строки
            for (var i = 0; i < infix.Length; i++)
            {        
                var symbol = infix[i];  
                switch (symbol)
                {
                    //если получаем скобку(приоритетное выражение)
                    case '(':
                        {
                            //находим индекс окончание этой скобки
                            var charIndexOfCloseSymbol = infix.IndexOf(')');
                            //выделяем подстроку с приоритетом
                            var substring = infix.Substring(i + 1, charIndexOfCloseSymbol - 1);
                            //рекурсивно вызываем данную функцию для обработки подстроки
                            ConvertToPostfix(substring, out string subPostfix);
                            //добавляем полученную подстроку в результирующее выражение
                            postfix += subPostfix;
                            i = charIndexOfCloseSymbol;
                            break;
                        }
                    // если получили знак операции
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        {
                            //проверка стэка на пустоту, если пустой то
                            if (stack.Count <= 0)
                            {
                                //добавляем знак операции в стек
                                stack.Push(symbol);
                            }
                            //если в стэке уже есть что-то
                            else
                            {
                                //если элемент деление или умножение
                                if (stack.Peek() == '/' || stack.Peek() == '*')
                                {
                                    //добавляем его в запись и удаляем элемент из стека
                                    postfix += stack.Pop();
                                    i--;
                                }
                                //если элемент стека сложение или вычитание
                                else
                                {
                                    if (symbol == '+' || symbol == '-')
                                    {
                                        //добавляем его в запись и удаляем элемент из стека
                                        postfix += stack.Pop();
                                    }
                                    //добавляем знак в стек
                                    stack.Push(symbol);
                                }
                            }
                            break;
                        }
                    default:
                        //если символ переменная, то просто добавляем ее в стек
                        postfix += symbol;
                        break;
                }
            }
            //добавляем оставшиеся элементы в стеке в постфиксную запись
            for (var j = 0; j < stack.Count; j++)
            {
                postfix += stack.Pop();
            }
            return true;

        }

static void Main(string[] args)
        {
            //вводим запись в инфиксной форме
            Console.WriteLine("Введите запись в инфиксной форме(разрешенные символы '+,-,*,/,(,)'): ");
            var infix = Console.ReadLine();
            //вызываем функцию преобразования строки из инфиксной формы в постфиксную
            ConvertToPostfix(infix, out string postfix);
            var arrPostfix = postfix.ToCharArray();
            //преобразуем строку из постфиксной формы в префиксную
            Array.Reverse(arrPostfix);
            var prefix = new string(arrPostfix);
            //выводим результаты
            Console.WriteLine("Иcходная инфиксная запись: " + infix);
            Console.WriteLine("Постфиксная запись:" + postfix);
            Console.WriteLine("Префиксная запись:" + prefix);
            Console.ReadKey();
        }
    }
}
