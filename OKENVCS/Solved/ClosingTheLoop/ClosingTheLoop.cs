using Kattis.IO;
using System;
using System.Collections.Generic;

public class Template
{
    public static void Main(string[] args)
    {
        Scanner io = new Scanner();
        int nTests = io.NextInt();
        int maxTests = nTests;
        while (--nTests >= 0)
        {
            int nSegs = io.NextInt();
            if (nSegs == 1)
            {
                io.Next();
                Console.Write("Case #" + (maxTests - nTests) + ": 0\n");
            }
            else
            {
                List<RopeSegment> redSegs = new List<RopeSegment>();
                List<RopeSegment> blueSegs = new List<RopeSegment>();
                while (--nSegs >= 0)
                {
                    string x = io.Next();
                    RopeSegment seg = new RopeSegment(ref x);
                    if (seg.getType() == 'B')
                    {
                        blueSegs.Add(seg);
                    }
                    else
                    {
                        redSegs.Add(seg);
                    }
                }
                blueSegs.Sort();
                redSegs.Sort();
                double totalLen = 0;
                while (blueSegs.Count != 0 && redSegs.Count != 0)
                {
                    totalLen = totalLen + (redSegs[0].length() + blueSegs[0].length() - 2);
                    redSegs.RemoveAt(0);
                    blueSegs.RemoveAt(0);
                }
                Console.Write("Case #" + (maxTests - nTests) + ": " + (int)totalLen + "\n");
            }
        }
        //io.wait();
    }

}
public class RopeSegment : IComparable
{
    char type;
    int len;
    public RopeSegment(ref string x)
    {

        type = x.ToCharArray()[x.Length - 1];
        len = Convert.ToInt32(x.Substring(0, x.Length - 1));
    }
    public char getType()
    {
        return type;
    }

    public int length()
    {
        return len;
    }
    public override string ToString()
    {
        return len + "" + type;
    }

    public int CompareTo(object obj)
    {
        if (obj.GetType() == this.GetType())
        {
            RopeSegment seg = (RopeSegment)obj;
            if (seg.len > this.len)
            {
                return 1;
            }
            else if (seg.len == this.len)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        return 0;
    }
}

