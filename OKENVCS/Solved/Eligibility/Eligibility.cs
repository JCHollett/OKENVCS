using System;

public class Eligibility {
   private static int k;
   private static string[] input;

   public static void Problem( int Size ) {
      while( --Size >= 0 ) {
         input = Console.ReadLine().Split( ' ' );
         if( Convert.ToInt32( input[ 1 ].Split( '/' )[ 0 ] ) >= 2010 ) {
            Console.WriteLine( input[ 0 ] + " eligible" );
         } else if( Convert.ToInt32( input[ 2 ].Split( '/' )[ 0 ] ) >= 1991 ) {
            Console.WriteLine( input[ 0 ] + " eligible" );
         } else if( Convert.ToInt32( input[ 3 ] ) >= 41 ) {
            Console.WriteLine( input[ 0 ] + " ineligible" );
         } else {
            Console.WriteLine( input[ 0 ] + " coach petitions" );
         }
      }
   }

   public static void Main( string[ ] args ) {
      Problem( k = Convert.ToInt32( Console.ReadLine() ) );
   }
}