/*� ��� ������� ���� ������ �������. � ������� ���� �������� � �����������, � ������� � �������� ������ � ��������. 
���� � ����� ������ ���������� �� ������, ����������� ��������� ������
������������, ���������� �������, �����, ������������� 
� ������ �������� �������, ������������. 
�������� ������ � ��� ������� ������, ����� ����������, ����, ����������� ��� �������.
������ � ��� ����� ���������� � ������ � ��� ����� ��������� (��������� ����� �������). � ������� ����� �������� ���������� ���������� 
1.  ���������� �������� ������ � �������� 
2. ������������� �������� ������ �� ����
3. ������������� �������� ������ �� ����������
4. ������ �������� ������ ���������������� �� ��������*/
using System;
using System.Linq;
class Provider(int id, string name, string number, string city)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Number { get; set; } = number;
    public string City { get; set; } = city;
}
class Product(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}
class Movement(int prodictId, int providerId, int kolvo, int price, string data, bool isConing)
{
    public int ProductId { get; set; } = prodictId;
    public int ProviderId { get; set; } = providerId;
    public int Kolvo { get; set; } = kolvo;
    public int Price { get; set; } = price;
    public string Data { get; set; } = data;
    public bool IsComing { get; set; } = isConing;
}
class Program
{
    static void Main()
    {
        List<Provider> providers = new List<Provider>();
        Provider provider1 = new Provider(1, "provider1", "+7904", "Omsk");
        Provider provider2 = new Provider(2, "provider2", "+7950", "Moscow");
        providers.Add(provider1);
        providers.Add(provider2);

        List<Product> products = new List<Product>();
        Product product1 = new Product(1, "product1");
        Product product2 = new Product(2, "product2");
        products.Add(product1);
        products.Add(product2);

        List<Movement> movements = new List<Movement>();
        Movement movement1 = new Movement(product1.Id, provider1.Id, 5, 200, "20.05.2025", true);
        Movement movement2 = new Movement(product2.Id, provider2.Id, 12, 2000, "20.06.2025", true);
        Movement movement3 = new Movement(product1.Id, provider2.Id, 3, 12, "29.05.2025", false);
        Movement movement4 = new Movement(product2.Id, provider1.Id, 27, 512, "20.04.2025", true);
        movements.Add(movement1);
        movements.Add(movement2);
        movements.Add(movement3);
        movements.Add(movement4);

        bool a = true;
        while (a)
        {
            Console.WriteLine("\t����");
            Console.WriteLine("1. ���������� �������� ������ � ��������");
            Console.WriteLine("2. ������������� �������� ������ �� ����");
            Console.WriteLine("3. ������������� �������� ������ �� ����������");
            Console.WriteLine("4. ������ �������� ������ ���������������� �� ��������");
            Console.WriteLine("5. �����");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    var productBalances = from m in movements
                                          group m by m.ProductId into g
                                          join p in products on g.Key equals p.Id
                                          select new
                                          {
                                              ProductId = g.Key,
                                              ProductName = p.Name,
                                              Balance = g.Sum(x => x.IsComing ? x.Kolvo : -x.Kolvo)
                                          };
                    Console.WriteLine("\n������� �������:");
                    foreach (var item in productBalances)
                    {
                        Console.WriteLine($"{item.ProductName}: {item.Balance} ����");
                    }
                    break;
                case 2:
                    var productByData = from m in movements
                                        where m.IsComing
                                        group m by m.Data into g
                                        orderby g.Key
                                        select g;

                    Console.WriteLine("\n�������� ������� �� �����:");
                    foreach (var group in productByData)
                    {
                        Console.WriteLine($"����: {group.Key}");
                        foreach (var movement in group)
                        {
                            var product = products.First(p => p.Id == movement.ProductId);
                            Console.WriteLine($"�����: {product.Name}, ����������: {movement.Kolvo}, ����: {movement.Price}");
                        }
                    }
                    break;
                case 3:
                    var movementsByProvider = from m in movements
                                              where m.IsComing
                                              group m by m.ProviderId into g
                                              join p in providers on g.Key equals p.Id
                                              select new
                                              {
                                                  ProviderName = p.Name,
                                                  Movements = g
                                              };
                    Console.WriteLine("\n�������� ������� �� �����������:");
                    foreach (var group in movementsByProvider)
                    {
                        Console.WriteLine($"���������: {group.ProviderName}");
                        foreach (var movement in group.Movements)
                        {
                            var product = products.First(p => p.Id == movement.ProductId);
                            Console.WriteLine($"�����: {product.Name}, ����: {movement.Data}, ����������: {movement.Kolvo}, ����: {movement.Price}");
                        }
                    }
                    break;
                case 4:
                    var movementsByProduct = from m in movements
                                             group m by m.ProductId into g
                                             join p in products on g.Key equals p.Id
                                             orderby p.Id
                                             select new
                                             {
                                                 ProductName = p.Name,
                                                 Movements = g
                                             };
                    Console.WriteLine("\n�������� �������:");
                    foreach (var group in movementsByProduct)
                    {
                        Console.WriteLine($"�����: {group.ProductName}");
                        foreach (var movement in group.Movements)
                        {
                            var provider = providers.First(p => p.Id == movement.ProviderId);
                            string operation = movement.IsComing ? "�����������" : "�������";
                            Console.WriteLine($"{operation}, ���������: {provider.Name}, ����: {movement.Data}, ����������: {movement.Kolvo}, ����: {movement.Price}");
                        }
                    }
                    break;
                case 5:
                    a = false;
                    break;
                default:
                    Console.WriteLine("�������� ����. ������� ����� �� 1 �� 5.");
                    break;
            }
        }
    }
}