public class CryptographerConundrum {

   public static void Main( string[ ] args ) {
      int k;
      string input = System.Console.ReadLine();
      int sum = 0;
      char[] indice = new char[] {'P','E','R'};

      for( k = 0; k < input.Length; ++k ) {
         if( !input[ k ].Equals( indice[ k % 3 ] ) ) {
            ++sum;
         }
      }
      System.Console.Write( sum );
   }
}