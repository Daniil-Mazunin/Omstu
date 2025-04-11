/*��� ������ ����, � ������� ������-��������� ������� �� ������� ���������� � "�"*/
using System;
delegate List<string> Lyambda(List<string> words);
class Program
{
    static void Main()
    {
        List<string> words = new List<string>()
        {
            "�����",
            "�����",
            "����",
            "����"
        };
        Lyambda lyambda = list => list.FindAll(word => word[0] == '�');
        List<string> result = lyambda(words);
        Console.WriteLine($"����� ������������ �� '�': ");
        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
}
