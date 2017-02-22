using System;
using System.Collections.Generic;
using System.Linq;

public class ACM {

   public static void Main( string[ ] args ) {
      string k;
      HashSet<char> Key = new HashSet<char>();
      Dictionary<char,int> KV = new Dictionary<char, int>();
      string[] entry;
      bool right = false;
      while( !( k = Console.ReadLine() ).Equals( "-1" ) ) {
         entry = k.Split( ' ' );
         try {
            if( ( right = entry[ 2 ][ 0 ] == 'r' ) ) {
               Key.Add( entry[ 1 ][ 0 ] );
               KV[ entry[ 1 ][ 0 ] ] += Convert.ToInt32( entry[ 0 ] );
            } else {
               KV[ entry[ 1 ][ 0 ] ] += 20;
            }
         } catch( KeyNotFoundException ) {
            if( right )
               KV.Add( entry[ 1 ][ 0 ] , Convert.ToInt32( entry[ 0 ] ) );
            else {
               KV.Add( entry[ 1 ][ 0 ] , 20 );
            }
         }
      }
      Console.WriteLine( Key.Count + " " + KV.Sum( ( x ) => {
         if( Key.Contains( x.Key ) ) {
            return x.Value;
         } else {
            return 0;
         }
      } ) );
   }
}