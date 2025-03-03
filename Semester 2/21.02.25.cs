//дана строка в которой присутствует открывающиес€ и закрывающиес€ круглые квадратные фигурные скобки использу€ стек определить правильно ли расставлены скобки
using System;
class Program
{
    static void Main()
    {
        string input = "{[()]}";
        bool proverka = Skobki(input);
        if (proverka)
        {
            Console.WriteLine("—кобки раставлены правильно");
        }
        else
        {
            Console.WriteLine("—кобки раставлены не правильно");
        }
    }
    static bool Skobki(string input)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in input)
        {
            if (c == '{' || c == '[' || c == '(')
            {
                stack.Push(c);
            }
            else if (c == '}' || c == ']' || c == ')')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char elem = stack.Pop();
                if ((elem == '(' && c != ')') || (elem == '{' && c != '}') || (elem == '[' && c != ']'))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
