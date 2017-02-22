using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner();
    public static void Main(string[] args)
    {
        int one = io.NextInt() + io.NextInt() + io.NextInt() + io.NextInt();
        int two = io.NextInt() + io.NextInt() + io.NextInt() + io.NextInt();
        if(one > two)
        {
            Console.Write("Gunnar");
        }
        else if(one < two)
        {
            Console.Write("Emma");
        }
        else
        {
            Console.Write("Tie");
        }
    }
}
