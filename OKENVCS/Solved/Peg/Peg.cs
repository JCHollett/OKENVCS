using System;
using System.Collections.Generic;
using System.Linq;

public class Peg {

   public static char[ ][ ] Board() {
      return BoardY().ToArray();
   }

   public static IEnumerable<char[ ]> BoardY() {
      for( int i = 0; i < 7; ++i ) {
         yield return BoardX().ToArray();
      }
   }

   public static char[ ] BoardX() {
      return Console.ReadLine().ToArray();
   }

   public static void Main( string[ ] args ) {
      var B = Board();
      int Moves = 0;
      int Check = 'o'-'.';
      int y;
      int x;

      for( y = 0; y < 7; ++y ) {
         for( x = 0; x < 7; ++x ) {
            if( B[ y ][ x ] == 'o' ) {
               try {
                  if( ( B[ y + 1 ][ x ] - B[ y + 2 ][ x ] ) == Check ) Moves++;
               } catch( Exception ) {
               }
               try {
                  if( ( B[ y - 1 ][ x ] - B[ y - 2 ][ x ] ) == Check ) Moves++;
               } catch( Exception ) {
               }
               try {
                  if( ( B[ y ][ x + 1 ] - B[ y ][ x + 2 ] ) == Check ) Moves++;
               } catch( Exception ) {
               }
               try {
                  if( ( B[ y ][ x - 1 ] - B[ y ][ x - 2 ] ) == Check ) Moves++;
               } catch( Exception ) {
               }
            }
         }
      }
      Console.WriteLine( Moves );
   }
}