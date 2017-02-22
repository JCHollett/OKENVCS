using Kattis.IO;
using System;
using System.Collections.Generic;
using System.Linq;

public class Template
{
    static Scanner io = new Scanner();
    public static void Main(string[] args)
    {
        int N = io.NextInt();
        List<Number> numbers = new List<Number>();
        for (int i = 0; i < N; i++)
        {
            Number n = new Number(io.NextInt());
            if (!numbers.Any(item => item.Equals(n)))
            {
                numbers.Add(n);
            }

        }
        numbers.Sort();
        foreach (Number n in numbers)
        {
            if(n.getCount() == 1)
            {
               Console.WriteLine(n.getIndex()+1);
                return;
            }
        }
        Console.WriteLine("none");
    }

    public static void wait(bool b)
    {
        if (b)
        {
            Console.ReadKey();
        }
    }
}

public class Number : IComparable<Number> {
    int N;
    static int index = 0;
    int Count;
    int iValue;
    public Number(int n)
    {
        iValue = index++;
        N = n;
        Count = 1;
    }
    public void Inc()
    {
        Count++;
    }
    public int getCount()
    {
        return Count;
    }
    public int getIndex()
    {
        return iValue;
    }
    public int getN()
    {
        return N;
    }
    public override bool Equals(object obj)
    {
        if (obj is Number)
        {
            bool b = ((Number)obj).ToString() == ToString();
            if (b) {
                this.Inc();
            }
            return b;
        }
        else return false;
    }
    public override string ToString()
    {
        return N.ToString();
    }

    public int CompareTo(Number other)
    {
        if (this.getN() == other.getN())
        {
            return 0;
        }
        else if (this.getN() > other.getN())
        {
            return -1;
        }
        else return 1;
    }
}