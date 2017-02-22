using Kattis.IO;
using System;

public class Template
{
    static int thirteen = 1;
    static Scanner io = new Scanner();
    public static void Main(string[] args)
    {
        int N = io.NextInt();
        int fridays;
        int nDays;
        int nMonths;
        int[] nMonthDays;
        int i;
        int j;
        while (--N >= 0)
        {
            fridays = 0;
            nDays = io.NextInt();
            nMonths = io.NextInt();
            nMonthDays = new int[nMonths];
            for (i = 0; i < nMonths; ++i)
            {
                nMonthDays[i] = io.NextInt();
            }
            for(i = 0; i < nMonths; ++i)
            {
                for(j = 1; j <= nMonthDays[i]; ++j)
                {
                    if(nextDay() == 6 && j == 13)
                    {
                        ++fridays;
                    }
                }
            }
            thirteen = 1;
            Console.Write(fridays+"\n");
        }
    }
    public static int nextDay()
    {
        if(thirteen == 7)
        {
            return (thirteen = 1);
        }
        return thirteen++;
    }
}

