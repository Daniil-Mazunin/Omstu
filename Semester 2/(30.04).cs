/* Есть класс описывающий телефон, который включает следующие поля: номер телефона, фио, дата постановки на учет, оператор. 
 * Необходимо сформировать запросы по выборке сведения телефоне по заданному фио и заданному номеру телефона, 
 * а также вывести данные по всем телефонам сгруппированным по году и данные по телефону сгруппированными по оператору связи. */
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
        for(int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nВведите номер телефона {i + 1}-го владельца: ");
            string number = Console.ReadLine();
            Console.WriteLine($"Введите ФИО {i + 1}-го владельца: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Введите дату постановки на учет {i + 1}-го владельца (дд.мм.гггг): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"Введите оператора связи {i + 1}-го владельца: ");
            string oper = Console.ReadLine();
            Phone phone = new Phone(number, name, date, oper);
            phones.Add(phone);
        }
    }
    static void Main()
    {
        bool a = true;
        List<Phone> phones = new List<Phone>();
        while(a)
        {
            Console.WriteLine("\n1. Заполнить данные.");
            Console.WriteLine("2. Выборка по ФИО.");
            Console.WriteLine("3. Выборка по номеру телефона.");
            Console.WriteLine("4. Вывести данные сгруппированные по году.");
            Console.WriteLine("5. Вывести данные сгруппированные по оператору.");
            Console.WriteLine("6. Выход.");
            Console.WriteLine("Введите операцию, которую хотите сделать: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice) 
            {
                case 1:
                    Console.WriteLine("\nВведите количество владельцев.");
                    int count = int.Parse(Console.ReadLine());
                    Completion(phones, count);
                    break;
                case 2:
                    Console.WriteLine("\nВведите ФИО для выборки: ");
                    string name = Console.ReadLine();
                    var selectionName = from phone in phones
                                        where phone.Name == name
                                        select phone;
                    foreach (var phone in selectionName)
                    {
                        Console.WriteLine($"\nНомер: {phone.Number}, ФИО: {phone.Name}, Дата: {phone.Date}, Оператор: {phone.Oper}");
                    }
                    break;
                case 3:
                    Console.WriteLine("\nВведите номер телефона для выборки: ");
                    string number = Console.ReadLine();
                    var selectionNumber = from phone in phones
                                          where phone.Number == number
                                          select phone;
                    foreach (var phone in selectionNumber)
                    {
                        Console.WriteLine($"Номер: {phone.Number}, ФИО: {phone.Name}, Дата: {phone.Date}, Оператор: {phone.Oper}");
                    }
                    break;
                case 4:
                    Console.WriteLine("\nГруппировка по году: ");
                    var groupDate = from phone in phones
                                    group phone by phone.Date.Year into g
                                    orderby g.Key
                                    select g;

                    foreach (var group in groupDate)
                    {
                        Console.WriteLine($"\nГод: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"Номер: {phone.Number}, ФИО: {phone.Name}, Дата: {phone.Date}, Оператор: {phone.Oper}");
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("\nГруппировка по оператору: ");
                    var groupOper = from phone in phones
                                    group phone by phone.Oper into g
                                    orderby g.Key
                                    select g;
                    foreach (var group in groupOper)
                    {
                        Console.WriteLine($"\nОператор: {group.Key}");
                        foreach (var phone in group)
                        {
                            Console.WriteLine($"Номер: {phone.Number}, ФИО: {phone.Name}, Дата: {phone.Date}");
                        }
                    }
                    break;
                case 6:
                    a = false;
                    break;
                default:
                    Console.WriteLine("\nТакой операции не существует.");
                    break;
            }
        }
    }
}
