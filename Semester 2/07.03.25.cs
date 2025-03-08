using System;
class Telephon
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Operator { get; set; }
    public Telephon(string number, string name, string oper)
    {
        Number = number;
        Name = name;
        Operator = oper;
    }
}
class Program
{
    static void Main()
    {
        List<Telephon> telephons = new List<Telephon>
        {
            new Telephon("89990001122", "Ivan", "tele2"),
            new Telephon("88005553535", "Daniil", "tele2"),
            new Telephon("89007775522", "Messi", "MTS"),
            new Telephon("88009090909", "Ksenia", "Yota"),
            new Telephon("88888888888", "Ivan", "MTS")
        };
        Dictionary<string, int> operators = new Dictionary<string, int>();
        foreach (var tel in telephons)
        {
            if (operators.ContainsKey(tel.Operator))
            {
                operators[tel.Operator]++;
            }
            else
            {
                operators[tel.Operator] = 1;
            }
        }
        Console.WriteLine("Количество операторов связи");
        foreach (var oper in operators)
        {
            Console.WriteLine(oper);
        }
    }
}
