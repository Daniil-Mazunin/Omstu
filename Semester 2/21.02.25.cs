//���� ������ � ������� ������������ ������������� � ������������� ������� ���������� �������� ������ ��������� ���� ���������� ��������� �� ����������� ������
using System;
class Program
{
    static void Main()
    {
        string input = "{[()]}";
        bool proverka = Skobki(input);
        if (proverka)
        {
            Console.WriteLine("������ ���������� ���������");
        }
        else
        {
            Console.WriteLine("������ ���������� �� ���������");
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
