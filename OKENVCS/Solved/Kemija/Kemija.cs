using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner();
    public static void Main(string[] args)
    {
        string x = Console.ReadLine();
        string vowels = "aeiou";
        string y = "";
        int index = -1;
        while(index++ < x.Length - 1)
        {
            y = y + x[index];
            if (vowels.Contains(x[index].ToString())) {
                index += 2;
            }
        }
        Console.Write(y);
    }
}

