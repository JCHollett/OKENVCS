using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner();
    static void Press(ref int A, ref int B)
    {
        int b = A;
        int a = B;  
        A = a;
        B = B + b;
    }
    public static void Main(string[] args)
    {
        int A = 1;
        int B = 0;
        int n = io.NextInt();
        while (n-- > 0)
        {
            Press(ref A, ref B);
        }
        Console.WriteLine(A + " " + B);
    }
}

