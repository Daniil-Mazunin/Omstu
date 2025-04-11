/*Дан список слов, с помощью лямбда-выражений выбрать те которые начинаются с "а"*/
using System;
delegate List<string> Lyambda(List<string> words);
class Program
{
    static void Main()
    {
        List<string> words = new List<string>()
        {
            "лампа",
            "арбуз",
            "дыня",
            "Асус"
        };
        Lyambda lyambda = list => list.FindAll(word => word[0] == 'а');
        List<string> result = lyambda(words);
        Console.WriteLine($"Слова начинающиеся на 'а': ");
        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
}
