using System;

public class FizzBuzz {
    public static string[] print = {"Fizz", "Buzz"};
    public static char[] buf = new char[12];
    public static int[] Data = new int[ 3 ];
    public static int i = -1;
    public static int res = 0;

    public static void GetInt( ref int x ) {
        ++i;
        while( char.IsNumber( buf[ i ] ) ) {
            x = x * 10 + ( buf[ i++ ] - '0' );
        }
    }

    public static void Main( string[ ] args ) {
        Console.In.Read( buf , 0 , 12 );
        GetInt( ref Data[ 0 ] );
        GetInt( ref Data[ 1 ] );
        GetInt( ref Data[ 2 ] );
        for( int i = 1; i <= Data[ 2 ]; ++i ) {
            switch( ( i % Data[ 0 ] == 0 ? 1 : 0 ) | ( i % Data[ 1 ] == 0 ? 2 : 0 ) ) {
                case 1:
                    Console.WriteLine( print[ 0 ] );
                    break;

                case 2:
                    Console.WriteLine( print[ 1 ] );
                    break;

                case 3:
                    Console.Write( print[ 0 ] );
                    Console.WriteLine( print[ 1 ] );
                    break;

                default:
                    Console.WriteLine( i );
                    break;
            }
        }
    }
}