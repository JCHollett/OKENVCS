using System;
using System.Collections.Generic;

public class Template {
	static List<string> nums = new List<string>();
	static void initializeNums() {
		nums.Add( "**** ** ** ****" );//0
		nums.Add( "  *  *  *  *  *" );//1
		nums.Add( "***  *****  ***" );//2   ### ### ### ### ### ### ### ### ### ###
		nums.Add( "***  ****  ****" );//3   ***   * *** *** * * *** *** *** *** ***
		nums.Add( "* ** ****  *  *" );//4   * *   *   *   * * * *   *     * * * * *
		nums.Add( "****  ***  ****" );//5   * *   * *** *** *** *** ***   * *** ***
		nums.Add( "****  **** ****" );//6   * *   * *     *   *   * * *   * * *   *
		nums.Add( "***  *  *  *  *" );//7   ***   * *** ***   * *** ***   * *** ***
		nums.Add( "**** ***** ****" );//8
		nums.Add( "**** ****  ****" );//9
	}
	public static void Main( string[] args ) {
		initializeNums();
		string[] code = { Console.ReadLine() + " ", Console.ReadLine() + " ", Console.ReadLine() + " ", Console.ReadLine() + " ", Console.ReadLine() + " " };
		int digits = code[0].Length / 4;
		int nSum = 0;
		string nStr;
		int n = -1;
		int c;
		int y;
		int x;
		int cap;
		for(c = 0; c < digits; c = c + 1) {
			nStr = "";
			for(y = 0; y < 5; y = y + 1) {
				cap = (c + 1) * 3 + c;
				for(x = c * 4; x < cap; x = x + 1) {
					nStr += code[y][x];
				}
			}
			n = nums.IndexOf( nStr );
			if(n == -1) {
				Console.WriteLine( "BOOM!!" );
				return;
			}
			nSum += n;
		}
		Console.WriteLine( nSum % 3 == 0 && n % 2 == 0 ? "BEER!!" : "BOOM!!" );
		Console.ReadKey();
	}
}

