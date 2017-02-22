using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner(false);
    public static void Main(string[] args)
    {
        int N = Math.Abs( io.NextInt() );
        while(N-- > 0)
        {
            int x = io.NextInt();
            if(Math.Abs(x) % 2 == 0)
            {
                Console.WriteLine("{0} is even", x);
            }
            else
            {
                Console.WriteLine("{0} is odd", x);
            }
        }
        io.wait();
    }
}

