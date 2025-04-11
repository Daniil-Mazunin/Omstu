/*скачки. начальная позиция - старт: 0, конечная позиция - финиш(длина или значение), 
три объекта, каждый из которых характеризуется именем и начальной скоростью. 
через заданный с клавиатуры момент времени случайным образом у каждого объекта меняется скорость, 
путь = время на скорость. обработать событие победы одного из объектов (выдать сообщение)*/
using System;
class Player
{
    public string Name { get; set; }
    public int Speed { get; set; }
    public int Position { get; set; }
    public Player(string name, int speed)
    {
        Name = name;
        Speed = speed;
        Position = 0;
    }
}
class Racing
{
    public List<Player> Players { get; set; }
    public int Finish { get; set; }
    public Racing(List<Player> players, int len)
    {
        Players = players;
        Finish = len;
    }
    public delegate void Winner(Player player, int finishTime);
    public event Winner Win;
    public void Race(int interval)
    {
        Random random = new Random();
        int currentTime = 0;
        bool end = false;
        while (!end)
        {
            if (currentTime % interval == 0)
            {
                foreach (Player player in Players)
                {
                    player.Speed = Math.Max(0, player.Speed + random.Next(-5, 5));
                }
            }
            currentTime++;
            foreach (Player player in Players)
            {
                player.Position += player.Speed;
                if (player.Position >= Finish && !end)
                {
                    Win(player, currentTime);
                    end = true;
                    break;
                }
            }
        }
    }
}
class Program
{
    static void FinishRace(Player player, int finishTime)
    {
        Console.WriteLine($"\nПобедил: {player.Name}! Дошел до финиша за {finishTime} секунд(ы).");
    }
    static void Main()
    {
        Console.WriteLine("Введите длину трассы: ");
        int len = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите интервал времени (в секундах) через который изменяется скорость: ");
        int interval = int.Parse(Console.ReadLine());
        var players = new List<Player>()
        {
            new Player("Игрок 1", 12),
            new Player("Игрок 2", 15),
            new Player("Игрок 3", 10),
        };
        var racing = new Racing(players, len); ;
        racing.Win += FinishRace;
        Console.WriteLine("Участники скачек: ");
        foreach (var player in players)
        {
            Console.WriteLine($"\n{player.Name}. Начальная скорость: {player.Speed} (м/с)");
        }
        racing.Race(interval);
    }
}