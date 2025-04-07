using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string formula = File.ReadAllText("1.txt");
            if (string.IsNullOrWhiteSpace(formula))
            {
                Console.WriteLine("Ошибка. Файл пустой!");
            }
                var operation = new Stack<char>(); // будет хранить операции M (max) и m (min)
                var num = new Stack<int>(); // будет хранить числа
            //обрабатываем каждый символ формулы
            foreach (char c in formula)
            {
                switch (c)
                {
                    
                    case 'M':
                    case 'm':
                        operation.Push(c);
                        break;
                    case ')':
                        char op = operation.Pop();//достаём последнюю операцию из стека
                       //достаём сначала второе число, а потом первое число из стека
                        int num2 = num.Pop();
                        int num1 = num.Pop();
                        //вычисляем резултат
                        int res;
                        if (op == 'M')
                        {
                            res = Math.Max(num1, num2);
                        }
                        else
                        {
                            res = Math.Min(num1, num2);
                        }
                        //кладём результат обратно в стек
                        num.Push(res);
                        break;
                        //если это цифpа
                    case char digit:
                        if (char.IsDigit(digit))
                        {
                            num.Push(int.Parse(digit.ToString()));
                        }
                        break;
                }
            }
            //в стеке остался один элемент, и это ответ
            int otvet = num.Pop();
            Console.WriteLine($"Ответ: {formula} = {otvet}");
            Console.ReadLine(); 
        }
    }
}
