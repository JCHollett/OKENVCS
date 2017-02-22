using System;
using System.Linq;

public class Spavanac {

    public static void Problem() {
        int[] array = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        if( array[ 1 ] - 45 < 0 ) {
            if( array[ 0 ] == 0 )
                array[ 0 ] = 23;
            else
                array[ 0 ]--;
            array[ 1 ] += 15;
        } else
            array[ 1 ] -= 45;
        Console.WriteLine( array[ 0 ] + " " + array[ 1 ] );
    }

    public static void Main( string[ ] args ) {
        Problem();
    }
}