using System.Linq;

public class ColdputerScience {

   public static void Main( string[ ] args ) {
      System.Console.ReadLine();
      System.Console.Write( System.Console.ReadLine().Count( ( x ) => x.Equals( '-' ) ) );
   }
}