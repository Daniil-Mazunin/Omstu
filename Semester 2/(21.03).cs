using System;
class Car
{
    public int Year { get; set; }
    public string Mark { get; set; }
    public bool Clean { get; set; }
    public Car(int year, string mark, bool clean)
    {
        Year = year;
        Mark = mark;
        Clean = clean;
    }
}

class Garage
{
    public List<Car> Cars { get; set; }
}

class Washing
{
    public static void Wash(Car car)
    {
        if (car.Clean == true)
        {
            Console.WriteLine($"Машина {car.Mark} итак чистая!");
            return;
        }
        else
        {
            Console.WriteLine($"Машина {car.Mark} помыта!");
            return;
        }
    }
}

delegate void Washing_Car(Car car);

class Program
{
    static void Main()
    {
        Garage garage = new Garage();
        garage.Cars = new List<Car>();

        Console.WriteLine("Введите количество машин:");
        int count = int.Parse(Console.ReadLine());

        for(int i = 0; i < count; i++)
        {
            Console.WriteLine("Введите марку машины:");
            string mark = Console.ReadLine();
            Console.WriteLine("Введите год выпуска этой машины:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Чистая ли эта машина? Если чистая введите '1', если грязна введите '0'");
            int clean = int.Parse(Console.ReadLine());
            bool clean1 = Convert.ToBoolean(clean);
            
            Car car = new Car(year, mark, clean1);
            garage.Cars.Add(car);
        }

        Washing_Car wash = new Washing_Car(Washing.Wash);

        for(int i = 0;i < count; i++)
        {
            wash(garage.Cars[i]);
        }
    }
}
