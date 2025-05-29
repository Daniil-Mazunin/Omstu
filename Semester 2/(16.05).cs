/*���� ���� ������, ��������� �� ���������� ��������������� ����� ����� ������. ������ �������: ����� ������ ���������� � ������ ���������� �����,
������������ (����� ��������), ������ ������ �������: ������� ������������ ������� ��������������� ���� � ������������ ������������ �������
������ �������: ������������ ���� ����� ������������, ���, ���� ��� ��� ��������� (�������). ���� ���, �� ����, ���������� �� ������������
� ������������ ������� ����� ������ (���� ��� ����). ���� ����, �� ���� ��������� ������� �� ������� ��������� � ������ ���� �� ������� ������������ �������
� �������������� ����� �������� ��������� ��������� �������: ������ ������������� ��� ��������, ��������������� �� ��������, ������ �������������,
�������������� �� ������������ ������������ �������, ������ �������������, �������������� �� ������������� ��������, ��������������� �� �������� (�������������)*/
using System;
using System.Linq;
class Computer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string System { get; set; }
}
class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isOwner { get; set; }
    public Computer Computer { get; set; }
    public override string ToString()
    {
        string str = "";
        if (!isOwner)
        {
            str += $"������������: {Name}, ���������: O����������";
        }
        else
        {
            str += $"������������: {Name}, ���������: {Computer.Name}, ������: {Computer.Model}, ��: {Computer.System}";
        }
        return str;
    }
}
class Program
{
    static void UserNotComputer(List<User> users)
    {
        var owner = users.Where(x => x.isOwner == false).OrderBy(x => x.Name).ToList();
        foreach (var user in owner)
        {
            Console.WriteLine(user.ToString());
        }
    }
    static void UserOS(List<User> users)
    {
        Console.WriteLine("������� ��, �� ������� ������ ������� �����������: ");
        string os = Console.ReadLine();
        var owner = users.Where(x => x.isOwner == true).Where(x => x.Computer.System == os).ToList();
        if (owner.Count == 0)
        {
            Console.WriteLine("������������ �� �������.");
        }
        else
        {
            Console.WriteLine($"������������ � ��:{os}");
            foreach (var user in owner)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
    static void UserComputer(List<User> users)
    {
        Console.WriteLine("������� �������� ��������, �� �������� ������ ������� �����������: ");
        string name = Console.ReadLine();
        var owner = users.Where(x => x.isOwner == true).Where(x => x.Computer.Name == name).OrderBy(x => x.Computer.Name).ToList();
        if (owner.Count == 0)
        {
            Console.WriteLine("������������ �� �������.");
        }
        else
        {
            Console.WriteLine($"������������ � �����������: {name}");
            foreach (var user in owner)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
    static void Main()
    {
        List<User> users = new List<User>();
        users.Add(new User { Id = 1, Name = "Daniil", isOwner = true, Computer = new Computer() { Id = 1, Name = "Asus", Model = "TUF", System = "Windows 11" } });
        users.Add(new User { Id = 2, Name = "Dima", isOwner = true, Computer = new Computer() { Id = 2, Name = "Asus", Model = "Vivo", System = "Windows 10" } });
        users.Add(new User { Id = 3, Name = "Matvey", isOwner = false, Computer = null });
        users.Add(new User { Id = 4, Name = "Egor", isOwner = true, Computer = new Computer() { Id = 3, Name = "Acer", Model = "Nitro", System = "Windows 11" } });
        users.Add(new User { Id = 5, Name = "Artem", isOwner = true, Computer = new Computer() { Id = 4, Name = "MSI", Model = "Pro", System = "Linux" } });
        users.Add(new User { Id = 6, Name = "Nikita", isOwner = false, Computer = null });
        bool a = true;
        while (a)
        {
            Console.WriteLine("\t����");
            Console.WriteLine("1. ������ ������������� ��� ��������, ��������������� �� ��������");
            Console.WriteLine("2. ������ �������������, ��������������� �� ��");
            Console.WriteLine("3. ������ �������������, ��������������� �� ��������, �� ��������");
            Console.WriteLine("4. �����");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    UserNotComputer(users);
                    break;
                case 2:
                    UserOS(users);
                    break;
                case 3:
                    UserComputer(users);
                    break;
                case 4:
                    a = false;
                    break;
                default:
                    Console.WriteLine("�������� ����. ������� ����� �� 1 �� 4.");
                    break;
            }
        }
    }
}
