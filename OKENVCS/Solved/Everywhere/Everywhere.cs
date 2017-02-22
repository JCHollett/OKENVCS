using System;
using System.Collections.Generic;

namespace OpenKEnv {

    public class Everywhere {
        private static int i;
        private static int k;

        public static void Problem() {
            for( i = Convert.ToInt32( Console.ReadLine() ); i > 0; --i ) {
                HashSet<string> Cities = new HashSet<string>();
                for( k = Convert.ToInt32( Console.ReadLine() ); k > 0; --k ) {
                    Cities.Add( Console.ReadLine() );
                }
                Console.WriteLine( Cities.Count );
            }
        }

        public static void Main( string[ ] args ) {
            Problem();
        }
    }
}