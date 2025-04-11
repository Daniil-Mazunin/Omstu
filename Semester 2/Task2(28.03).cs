/*������. ��������� ������� - �����: 0, �������� ������� - �����(����� ��� ��������), 
��� �������, ������ �� ������� ��������������� ������ � ��������� ���������. 
����� �������� � ���������� ������ ������� ��������� ������� � ������� ������� �������� ��������, 
���� = ����� �� ��������. ���������� ������� ������ ������ �� �������� (������ ���������)*/
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
        Console.WriteLine($"\n�������: {player.Name}! ����� �� ������ �� {finishTime} ������(�).");
    }
    static void Main()
    {
        Console.WriteLine("������� ����� ������: ");
        int len = int.Parse(Console.ReadLine());
        Console.WriteLine("������� �������� ������� (� ��������) ����� ������� ���������� ��������: ");
        int interval = int.Parse(Console.ReadLine());
        var players = new List<Player>()
        {
            new Player("����� 1", 12),
            new Player("����� 2", 15),
            new Player("����� 3", 10),
        };
        var racing = new Racing(players, len); ;
        racing.Win += FinishRace;
        Console.WriteLine("��������� ������: ");
        foreach (var player in players)
        {
            Console.WriteLine($"\n{player.Name}. ��������� ��������: {player.Speed} (�/�)");
        }
        racing.Race(interval);
    }
}