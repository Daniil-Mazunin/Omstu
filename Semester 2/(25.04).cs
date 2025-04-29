/* имеется входной файл в котором расположены строки необходимо сформировать выходной файл,
 в котором будут присутствовать только те строки из входного, где есть хотя бы одно четное число */
using System;
using System.IO;
class Program
{
    static void Main()
    {
        string input = @"C:\Users\DaniilMS\Desktop\input.txt";
        string output = @"C:\Users\DaniilMS\Desktop\output.txt";

        string[] lines = File.ReadAllLines(input);
        List<string> new_lines = new List<string>();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string num = "";

            for (int j = 0; j < line.Length; j++)
            {
                char c = line[j];

                if (char.IsDigit(c))
                {
                    num += c;
                }
                else
                {
                    if (num.Length != 0)
                    {
                        if (int.Parse(num) % 2 == 0)
                        {
                            new_lines.Add(line);
                            num = "";
                            break;
                        }
                        num = "";
                    }
                }
            }

            if (num.Length != 0)
            {
                if (int.Parse(num) % 2 == 0)
                {
                    new_lines.Add(line);
                }
            }
        }
        File.WriteAllLines(output, new_lines);
    }
}