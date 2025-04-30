/* ���� ����� ����������� �������, ������� �������� ��������� ����: ����� ��������, ���, ���� ���������� �� ����, ��������. 
 * ���������� ������������ ������� �� ������� �������� �������� �� ��������� ��� � ��������� ������ ��������, 
 * � ����� ������� ������ �� ���� ��������� ��������������� �� ���� � ������ �� �������� ���������������� �� ��������� �����. */
using System;
using System.Linq;
class Phone
{
    public string Number { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Oper { get; set; }
    public Phone(string number, string name, DateTime date, string oper)
    {
        Number = number;
        Name = name;
        Date = date;
        Oper = oper;
    }
}
class Program
{
    static void Completion(List<Phone> phones, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n������� ����� �������� {i + 1}-�� ���������: ");
            string number = Console.ReadLine();
            Console.WriteLine($"������� ��� {i + 1}-�� ���������: ");
            string name = Console.ReadLine();
            Console.WriteLine($"������� ���� ���������� �� ���� {i + 1}-�� ��������� (��.��.����): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"������� ��������� ����� {i + 1}-�� ���������: ");
            string oper = Console.ReadLine();
            Phone phone = new Phone(number, name, date, oper);
            phones.Add(phone);
        }
    }
    static void Main()
    {
        bool a = true;
        List<Phone> phones = new List<Phone>();
        while (a)
        {
            Console.WriteLine("\n1. ��������� ������.");
            Console.WriteLine("2. ������� �� ���.");
            Console.WriteLine("3. ������� �� ������ ��������.");
            Console.WriteLine("4. ������� ������ ��������������� �� ����.");
            Console.WriteLine("5. ������� ������ ��������������� �� ���������.");
            Console.WriteLine("6. �����.");
            Console.WriteLine("������� ��������, ������� ������ �������: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n������� ���������� ����������.");
                    int count = int.Parse(Console.ReadLine());
                    Completion(phones, count);
                    break;
                case 2:
                    Console.WriteLine("\n������� ��� ��� �������: ");
                    string name = Console.ReadLine();
                    var selectionName = from phone in phones
                                        where phone.Name == name
                                        select phone;
                    foreach (var phone in selectionName)
                    {
                        Console.WriteLine($"\n�����: {phone.Number}, ���: {phone.Name}, ����: {phone.Date}, ��������: {phone.Oper}");
                    }
                    break;
                case 3:
                    Console.WriteLine("\n������� ����� �������� ��� �������: ");
                    string number = Console.ReadLine();
                    var selectionNumber = from phone in phones
                                          where phone.Number == number
                                          select phone;
                    foreach (var phone in selectionNumber)
                    {
                        Console.WriteLine($"�����: {phone.Number}, ���: {phone.Name}, ����: {phone.Date}, ��������: {phone.Oper}");
                    }
                    break;
                case 4:
                    Console.WriteLine("\n����������� �� ����: ");
                    var groupDate = from phone in phones
                                    group phone by phone.Date.Year into g
                                    orderby g.Key
                                    select g;

                    foreach (var group in groupDate)
                    {
                        Console.WriteLine($"\n���: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"�����: {phone.Number}, ���: {phone.Name}, ����: {phone.Date}, ��������: {phone.Oper}");
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("\n����������� �� ���������: ");
                    var groupOper = from phone in phones
                                    group phone by phone.Oper into g
                                    orderby g.Key
                                    select g;
                    foreach (var group in groupOper)
                    {
                        Console.WriteLine($"\n��������: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"�����: {phone.Number}, ���: {phone.Name}, ����: {phone.Date}");
                        }
                    }
                    break;
                case 6:
                    a = false;
                    break;
                default:
                    Console.WriteLine("\n����� �������� �� ����������.");
                    break;
            }
        }
    }
}