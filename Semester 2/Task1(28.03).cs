/*��� ����� �����, ������� �������� ��� ���������� x � y, ����� ������� ��� ��� int. 
����� �������� ������, ������ ��������� �������. 
���� ������� ���������� ������������� ���������(90 ��������, �������������� x � y), 
����� �������� ������ �����, ��������� ���������� ����� ������ �������� �������. 
���������� �������, ������� ��������� ��� �������� ����� �� ��� ���������� �� x � y, 
��� ���������� - ��������� �������� �������� ������������� ��� x � y. 
������������� ����������� �������������� ����������. ����� �������, ����� �������. 
����� �����(�� � ������ ������� � � ���������), ������� ������ ������� ��� ����� ����� �� �������. 
� ����� ���������� ������� ������� �������� �����.*/
using System;
class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public delegate void Output(Point point);
    public event Output Exit;
    public void Moving(Point point, Rectangle rectangle)
    {
        Random random = new Random();
        int x = X;
        int y = Y;
        x = random.Next(-5, 5);
        y = random.Next(-5, 5);
        X += x;
        Y += y;
        if (rectangle.Contain(X, Y) == false)
        {
            Exit?.Invoke(this);
        }
    }
}
class Rectangle
{
    public int MinX { get; set; }
    public int MaxX { get; set; }
    public int MinY { get; set; }
    public int MaxY { get; set; }
    public Rectangle(int minX, int maxX, int minY, int maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }
    public bool Contain(int x, int y)
    {
        return ((x >= MinX && x <= MaxX) && (y >= MinY && y <= MaxY));
    }
}
class Program
{
    static void Limit(Point point)
    {
        Console.WriteLine($"����� ({point.X}, {point.Y}) ����� �� �������");
    }
    static void Main()
    {
        Rectangle rectangle = new Rectangle(-5, 5, -5, 5);
        Point point = new Point(0, 0);
        point.Exit += Limit;
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"���������� {i}-�� ��������: ({point.X}, {point.Y})");
            point.Moving(point, rectangle);
        }
    }
}
