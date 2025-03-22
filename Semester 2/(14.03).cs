//Работа с делегатом
using System;
class Methods
{
    public int X { get; set; }
    public int Y { get; set; }
    public Methods(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int Addition()
    {
        return X + Y;
    }
    public int Subtraction()
    {
        return X - Y;
    }
    public int Multiplication()
    {
        return X * Y;
    }
    public int Division()
    {
        if (Y == 0)
        {
            Console.WriteLine("Делить на ноль нельзя");
            return 0;
        }
        else
        {
            return X / Y;
        }
    }
}

delegate int Operation();

class Program
{
    static int Add_Sub_Y(Methods obj) { return obj.Addition() - obj.Y; }
    static int Mult_ASY_Y(Methods obj) { return Add_Sub_Y(obj) * obj.Y; }
    static int Del_Add_Y(Methods obj) { return obj.Division() + obj.Y; }
    static int Mult_Add_Y(Methods obj) { return Del_Add_Y(obj) * obj.Y; }
    static void Main()
    {
        Console.WriteLine("Введите числа");
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        Methods object_1 = new Methods(x, y);
        Methods object_2 = new Methods(x, y);

        Operation operation_1 = object_1.Addition;
        operation_1 += () => Add_Sub_Y(object_1);
        operation_1 += () => Mult_ASY_Y(object_1);

        Operation operation_2 = object_2.Division;
        operation_2 += () => Del_Add_Y(object_2);
        operation_2 += () => Mult_Add_Y(object_2);

        Console.WriteLine("Результаты для первого объекта");
        foreach (Operation oper in operation_1.GetInvocationList())
        {
            Console.WriteLine(oper());
        }

        Console.WriteLine("\nРезультаты для второго объекта");
        foreach (Operation oper in operation_2.GetInvocationList())
        {
            Console.WriteLine(oper());
        }
    }
}
