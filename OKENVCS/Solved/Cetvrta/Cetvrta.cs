using System;

public class Cetvrta {
    public static int indice = -1;
    public static int x,y;
    public static int[] dz = new int[6];
    public static string line = null;
    public static string Answer = "{0} {1}";

    public static void GetIntPair( ref int dzx , ref int dzy ) {
        x = 0; y = 0;
        line = Console.In.ReadLine() + '\0';
        ++indice;
        while( char.IsNumber( line[ indice ] ) ) {
            x = x * 10 + ( line[ indice++ ] - '0' );
        }
        dzx += x;
        ++indice;
        while( char.IsNumber( line[ indice ] ) ) {
            y = y * 10 + ( line[ indice++ ] - '0' );
        }
        dzy += y;
        indice = -1;
    }

    public static void Main( params string[ ] args ) {
        GetIntPair( ref dz[ 0 ] , ref dz[ 1 ] );
        dz[ 2 ] = x;
        dz[ 3 ] = y;
        GetIntPair( ref dz[ 0 ] , ref dz[ 1 ] );
        dz[ 4 ] = x != dz[ 2 ] ? x : dz[ 4 ];
        dz[ 5 ] = y != dz[ 3 ] ? y : dz[ 5 ];
        GetIntPair( ref dz[ 0 ] , ref dz[ 1 ] );
        dz[ 4 ] = x != dz[ 2 ] ? x : dz[ 4 ];
        dz[ 5 ] = y != dz[ 3 ] ? y : dz[ 5 ];
        Console.WriteLine( string.Format( Answer , 2 * ( dz[ 2 ] + dz[ 4 ] ) - dz[ 0 ] , 2 * ( dz[ 3 ] + dz[ 5 ] ) - dz[ 1 ] ) );
    }
}