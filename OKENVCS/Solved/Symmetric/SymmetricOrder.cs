using System;
using System.Collections.Generic;

public class Symmetric {
    private static int i;
    private static int k;
    private static bool flipflop;

    public static void Problem( int N ) {
        List<object> A = new List<object>();
        List<object> B = new List<object>();
        flipflop = true;
        for( i = N; i > 0; --i ) {
            if( flipflop ) {
                A.Add( Console.ReadLine() );
                flipflop = false;
            } else {
                flipflop = true;
                B.Insert( 0 , Console.ReadLine() );
            }
        }
        A.ForEach( a => Console.WriteLine( a ) );
        B.ForEach( b => Console.WriteLine( b ) );
    }

    public static void Main( string[ ] args ) {
        int set = 0;
        while( ( k = Convert.ToInt32( Console.ReadLine() ) ) != 0 ) {
            Console.WriteLine( "SET " + ++set );
            Problem( k );
        }
    }
}