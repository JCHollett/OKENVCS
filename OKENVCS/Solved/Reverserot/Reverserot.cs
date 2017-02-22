using System;
using System.Linq;

public class Reverserot {

   public static void Main( string[ ] args ) {
      int N = -1;
      char k = 'A';
      string[] x = null;
      char[] y = null;

      while( ( x = Console.ReadLine().Split( ' ' ) )[ 0 ][ 0 ] != '0' ) {
         N = Convert.ToInt32( x[ 0 ] );
         y = x[ 1 ].Select( ( c ) => {
            if( c == '_' ) {
               return 26;
            } else if( c == '.' ) {
               return 27;
            } else {
               return c - k;
            }
         } ).Select( ( c ) => {
            c += N;
            c %= 28;
            if( c == 26 ) {
               return '_';
            } else if( c == 27 ) {
               return '.';
            } else {
               return ( char )( k + c );
            }
         } ).Reverse().ToArray();
         Console.WriteLine( new string( y ) );
      }
   }
}