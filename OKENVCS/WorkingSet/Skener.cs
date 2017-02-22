using System;
using System.Text;

public class Skener {
    public static string buffer = null;

    public static void init( string[ ] str , ref int R , ref int C , ref int Zr , ref int Zc ) {
        R = int.Parse( str[ 0 ] );
        C = int.Parse( str[ 1 ] );
        Zr = int.Parse( str[ 2 ] );
        Zc = int.Parse( str[ 3 ] );
    }

    public static void Main( string[ ] args ) {
        int R = 0, C  = 0, Zr = 0 , Zc = 0, i, j;
        StringBuilder sb;
        string line = null;
        init( Console.ReadLine().Split( ' ' ) , ref R , ref C , ref Zr , ref Zc );

        for( i = 0; i < R; ++i ) {
            line = Console.ReadLine();
            sb = new StringBuilder();
            foreach( char x in line ) {
                sb.Append( new string( x , Zc ) );
            }
            for( j = 0; j < Zr; ++j ) {
                Console.WriteLine( sb );
            }
        }
        Console.ReadKey();
    }
}