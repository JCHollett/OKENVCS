using System;
using System.Collections.Generic;
using System.Linq;

public class RollCall {
   public static List<Person> Persons = new List<Person>();
   public static Dictionary<string,bool> FirstNames = new Dictionary<string,bool>();

   public class Person {
      public string[] Name;

      public Person( string[ ] s ) {
         Name = s;
         try {
            FirstNames.Add( s[ 0 ] , true );
         } catch( ArgumentException ) {
            FirstNames[ s[ 0 ] ] = false;
         }
      }

      public override string ToString() {
         if( FirstNames[ Name[ 0 ] ] ) return Name[ 0 ];
         else return Name[ 0 ] + ' ' + Name[ 1 ];
      }
   }

   public static void Main( string[ ] args ) {
      Person P = null;
      string Name = Console.ReadLine();
      while( Name != null && Name.Length != 0 ) {
         P = new Person( Name.Split( ' ' ) );
         Persons.Add( P );
         Name = Console.ReadLine();
      }

      Console.WriteLine( string.Join( "\n" , ( from p in Persons
                                               orderby p.Name[ 1 ], p.Name[ 0 ]
                                               select p ) ) );

      Console.ReadKey();
   }
}