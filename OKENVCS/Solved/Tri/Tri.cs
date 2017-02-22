using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner();
    public static void Main(string[] args)
    {
        int[] N = { io.NextInt(), io.NextInt(), io.NextInt() };
        if (add(N[0], N[1], N[2]))
        {
            Console.WriteLine("{0}+{1}={2}", N[0], N[1], N[2]);
            return;
        }
        if(add(N[1],N[2],N[0]))
        {
            Console.WriteLine("{0}={1}+{2}", N[0], N[1], N[2]);
            return;
        }

        if (subtract(N[0], N[1], N[2]))
        {
            Console.WriteLine("{0}-{1}={2}", N[0], N[1], N[2]);
            return;
        }
        if (subtract(N[1], N[2], N[0]))
        {
            Console.WriteLine("{0}={1}-{2}", N[0], N[1], N[2]);
            return;
        }
        if (multiply(N[0], N[1], N[2]))
        {
            Console.WriteLine("{0}*{1}={2}", N[0], N[1], N[2]);
            return;
        }
        if (multiply(N[1], N[2], N[0]))
        {
            Console.WriteLine("{0}={1}*{2}", N[0], N[1], N[2]);
            return;
        }
        if (divide(N[0], N[1], N[2]))
        {
            Console.WriteLine("{0}/{1}={2}", N[0], N[1], N[2]);
            return;
        }
        if (divide(N[1], N[2], N[0]))
        {
            Console.WriteLine("{0}={1}/{2}", N[0], N[1], N[2]);
            return;
        }
        //wait(true);
    }

    public static bool add(int x, int y , int z)
    {
        return x + y == z;
    }
    public static bool subtract(int x, int y, int z)
    {
        return x - y == z;
    }
    public static bool multiply(int x, int y, int z)
    {
        return x * y == z;
    }
    public static bool divide(int x, int y, int z)
    {
        return x / y == z;
    }
    public static void wait(bool b)
    {
        if (b)
        {
            Console.ReadKey();
        }
    }
}