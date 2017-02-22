using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner();
    public static void Main(string[] args)
    {
        int height = io.NextInt();
        int angle = io.NextInt();
        Console.WriteLine(Math.Ceiling((height) / Math.Sin(angle * (Math.PI / 180))));
        wait(false);
    }



    public static void wait(bool b)
    {
        if (b)
        {
            Console.ReadKey();
        }
    }
}

