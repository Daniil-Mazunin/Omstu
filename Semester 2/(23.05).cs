/*����� ������, ��������� �� ��������� ������ ���� �� ������� ������ ������ �� ��������, ������� �������� ������������
������ � ������� ���������, � ������� ���� ������ ������ �������� ������*/
using System;
using System.Runtime.Serialization.Formatters;
class Program
{
    static bool Palindrom(int x)
    {
        int original = x;
        int reverse = 0;
        while (x > 0)
        {
            reverse = reverse * 10 + x % 10;
            x /= 10;
        }
        return reverse == original;
    }
    static unsafe void Main()
    {
        int size = 6;
        int* array = stackalloc int[size];
        array[0] = 121;
        array[1] = 1221;
        array[2] = 23;
        array[3] = 1;
        array[4] = 555;
        array[5] = 566;

        for (int i = 0; i < size; i++)
        {
            if (Palindrom(array[i]))
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}