public class StuckInATimeLoop {
    public static char[] Abra = { ' ','A','b','r','a','c','a','d','a','b','r','a','\n' };
    public static int N = 0;
    public static int i = 1;
    public static int indice = -1;
    public static char[] buf = new char[4];

    public static void GetInt( ref int n ) {
        ++indice;
        while( char.IsNumber( buf[ indice ] ) ) {
            n = n * 10 + ( buf[ indice++ ] - '0' );
        }
    }

    public static void Main( string[ ] args ) {
        System.Console.In.Read( buf , 0 , 4 );
        GetInt( ref N );
        for( ; i <= N; ++i ) {
            System.Console.Out.WriteAsync( i.ToString() );
            System.Console.Out.WriteAsync( Abra );
        }
    }
}