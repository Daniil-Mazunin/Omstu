/*���������� � ������� ������ ��������� ����� ������������ � �������� � ������� ����� ����� 
�����������*/
using System;
delegate int Lyambda(int x, int y);
class Program
{
    static void Main()
    {
        Console.WriteLine("������� �������� ������ ����������: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("������� �������� ������ ����������: ");
        int b = int.Parse(Console.ReadLine());
        int result = 0;
        if (b == 0)
        {
            Console.WriteLine("�� 0 ������ ������");
            return;
        }
        Lyambda lyambda = (x, y) => (a + b) * (a / b) - (a * b);
        result = lyambda(a, b);
        Console.WriteLine($"���������: {result}");
    }
}