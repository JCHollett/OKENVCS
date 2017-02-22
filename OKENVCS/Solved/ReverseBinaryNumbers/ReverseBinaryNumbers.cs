using Kattis.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReverseBinaryNumbers
{
	static Scanner io = new Scanner();
	public static void Main(string[] args)
	{
		int x = io.NextInt();
		char[] binary = Convert.ToString(x, 2).ToCharArray();
		Array.Reverse(binary);
		int y = Convert.ToInt32(new string(binary),2);
		Console.WriteLine(y);
	}
}

