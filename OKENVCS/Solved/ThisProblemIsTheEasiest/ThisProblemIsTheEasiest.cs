using Kattis.IO;
using System;

public class Template
{
    static Scanner io = new Scanner();
    public static void Main(string[] args)
    {
        while (true)
        {
            int N = io.NextInt();
            char[] digits = N.ToString().ToCharArray();
            int dSum = sumDigits(digits);
            if (dSum == 0)
            {
                return;
            }
            else
            {
                for (int i = 11; i <= 100; i++)
                {
                    if (sumDigits((N * i).ToString().ToCharArray()) == dSum)
                    {
                        Console.WriteLine(i);
                        break;
                    }

                }
            }
        }
    }
    public static int sumDigits(char[] x)
    {
        int sum = 0;
        foreach(char c in x)
        {
            sum += Convert.ToInt32(c+"");
        }
        return sum;
    }
}

