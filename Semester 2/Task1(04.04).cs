/*Необходимо с помощью лямбда вычислить сумму произведения в разность и деления между двумя 
переменными*/
using System;
delegate int Lyambda(int x, int y);
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите значение первой переменной: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите значение второй переменной: ");
        int b = int.Parse(Console.ReadLine());
        int result = 0;
        if (b == 0)
        {
            Console.WriteLine("На 0 делить нельзя");
            return;
        }
        Lyambda lyambda = (x, y) => (a + b) * (a / b) - (a * b);
        result = lyambda(a, b);
        Console.WriteLine($"Результат: {result}");
    }
}
