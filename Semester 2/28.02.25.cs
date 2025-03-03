//1. на вход подаётся число, пробел, число, пробел, знак, 1 2 +, найти результат 1+2 или невозможность
using System;
class Program
{
    static void Main()
    {
        int res = 0;
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');
        Stack<int> stack = new Stack<int>();
        int num1 = int.Parse(parts[0]);
        int num2 = int.Parse(parts[1]);
        stack.Push(num1);
        stack.Push(num2);
        string operation = parts[2];
        if (operation == "+")
        {
            res = stack.Pop() + stack.Pop();
            Console.WriteLine(res);
        }
        else if (operation == "-")
        {
            int secondNum = stack.Pop();
            int firstNum = stack.Pop();
            res = firstNum - secondNum;
            Console.WriteLine(res);
        }
        else if (operation == "*")
        {
            res = stack.Pop() * stack.Pop();
            Console.WriteLine(res);
        }
        else if (operation == "/")
        {
            int secondNum = stack.Pop();
            int firstNum = stack.Pop();
            if (secondNum == 0)
            {
                Console.WriteLine("Операция невозможна, т.к. в знаменателе ноль");
            }
            else
            {
                res = firstNum / secondNum;
                Console.WriteLine(res);
            }
        }
        else
        {
            Console.WriteLine("Операции не существует");
        }
    }
}

//2. на вход подаётся список, выдать сет списка и частоту появления каждого символа
using System;
class Program
{
    static void Main()
    {
        List<char> list = new List<char> { 'a', 'b', 'c', 'a', 'c' };
        HashSet<char> set = new HashSet<char>(list);
        Console.WriteLine("Сет списка");
        foreach (char current in set)
        {
            Console.WriteLine(current);
        }

        Dictionary<char, int> symbols = new Dictionary<char, int>();
        foreach (char current in list)
        {
            if (symbols.ContainsKey(current))
            {
                symbols[current]++;
            }
            else
            {
                symbols.Add(current, 1);
            }
        }
        Console.WriteLine("\nЧастота появление каждого символа");
        foreach (var symbol in symbols)
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value}");
        }
    }
}
