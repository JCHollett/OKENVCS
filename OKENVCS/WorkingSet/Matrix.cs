namespace TheoryLib.LinearAlgebra {

   using Exceptions;
   using IFunction;
   using System;
   using System.Collections.Generic;
   using System.Linq;

   public struct Row {
      private int y;

      public Row( int y ) {
         this.y = y;
      }

      public static Row operator ++( Row R ) {
         R.y++;
         return R;
      }

      public static implicit operator int( Row R ) {
         return R.y;
      }

      public static implicit operator Row( int Y ) {
         return new Row( Y );
      }
   }

   public struct Column {
      private int x;

      public Column( int x ) {
         this.x = x;
      }

      public static Column operator ++( Column C ) {
         C.x++;
         return C;
      }

      public static implicit operator int( Column C ) {
         return C.x;
      }

      public static implicit operator Column( int X ) {
         return new Column( X );
      }
   }

   public class Matrix<T> {
      #region Instance Variables and Properties

      protected internal  int c;
      protected internal T[][] matrix;
      protected internal  int r;
      /**
      public virtual Func<T , T , T> Addition {
         get { return Addition; }
         set { Addition = value; }
      }

      public virtual Func<T , T , T> Subtraction {
         get { return Subtraction; }
         set { Subtraction = value; }
      }

      public virtual Func<T , T> DivideConstant {
         get { return DivideConstant; }
         set { DivideConstant = value; }
      }

      public virtual Func<T , T> MultiplyConstant {
         get { return MultiplyConstant; }
         set { MultiplyConstant = value; }
      }

      public virtual Func<T , T , T , T> Multiply {
         get { return Multiply; }
         set { Multiply = value; }
      }
     **/

      public IEnumerable<T[ ]> ElementsX() {
         return this.GetColumns();
      }

      public IEnumerable<T[ ]> ElementsY() {
         return this.GetRows();
      }

      public int Columns { get { return this.c; } }
      public int Rows { get { return this.r; } }

      public Func<T , T , T> Addition;
      public Func<T , T , T> Subtraction;
      public Func<T , T , T> DivideConstant;
      public Func<T , T , T> MultiplyConstant;
      public Func<T , T , T , T> Multiply;

      public T[ ] this[ Row Y ] {
         get { return this.GetRow( Y ).ToArray(); }
         set {
            for( int x = 0; x < this.Columns; ++x ) {
               this[ Y , x ] = value[ x ];
            }
         }
      }

      public T[ ][ ] TMatrix { get { return this.matrix; } set { this.matrix = value; } }

      public T[ ] this[ Column X ] {
         get { return this.matrix[ X ]; }
         set {
            this.matrix[ X ] = value;
         }
      }

      public T this[ int Row , int Column ] { get { return this.matrix[ Row ][ Column ]; } set { this.matrix[ Row ][ Column ] = value; } }

      #endregion Instance Variables and Properties

      #region Row/Column Manipulation

      public IEnumerable<T> GetAll() {
         foreach( T[ ] Y in this.matrix ) {
            foreach( T X in Y ) {
               yield return X;
            }
         }
      }

      //Columns
      public IEnumerable<T> GetColumn( int Column ) {
         for( int Row = 0; Row < this.Rows; ++Row ) {
            yield return this[ Row , Column ];
         }
      }

      public IEnumerable<T[ ]> GetColumns() {
         for( int Column = 0; Column < this.Columns; ++Column ) {
            yield return this.GetColumn( Column ).ToArray();
         }
      }

      public IEnumerable<T> GetColumn( int Column , int IgnoreY ) {
         for( int Row = 0; Row < this.Rows; ++Row ) {
            if( Row != IgnoreY )
               yield return this[ Row , Column ];
         }
      }

      public IEnumerable<T[ ]> GetColumns( int IgnoreX , int IgnoreY ) {
         for( int Column = 0; Column < this.Columns; ++Column ) {
            if( Column != IgnoreX )
               yield return this.GetColumn( Column , IgnoreY ).ToArray();
         }
      }

      //Rows
      public IEnumerable<T> GetRow( int Row ) {
         for( int Column = 0; Column < this.Columns; ++Column ) {
            yield return this[ Row , Column ];
         }
      }

      public IEnumerable<T[ ]> GetRows() {
         for( int Row = 0; Row < this.Rows; ++Row ) {
            yield return GetRow( Row ).ToArray();
         }
      }

      public IEnumerable<T> GetRow( int Row , int IgnoreX ) {
         for( int Column = 0; Column < this.Columns; ++Column ) {
            if( Column != IgnoreX )
               yield return this[ Row , Column ];
         }
      }

      public IEnumerable<T[ ]> GetRows( int IgnoreX , int IgnoreY ) {
         for( int Row = 0; Row <= this.Rows; ++Row ) {
            if( Row != IgnoreY )
               yield return GetRow( Row , IgnoreX ).ToArray();
         }
      }

      #endregion Row/Column Manipulation

      #region Constructors

      public Matrix() {
         this.matrix = null;
         this.c = -1;
         this.r = -1;
      }

      public Matrix( Column Columns , Row Rows ) {
         this.matrix = new T[ this.r = Rows ][ ];
         this.c = Columns;
         for( int i = 0; i < this.r; ++i ) {
            this.matrix[ i ] = new T[ this.c ];
         }
      }

      public Matrix( int Columns , int Rows , T Identity ) {
         this.matrix = new T[ this.r = Rows ][ ];
         this.c = Columns;
         for( int i = 0; i < this.Columns && i < this.Rows; ++i ) {
            this.matrix[ i ] = new T[ this.c ];
            this[ i , i ] = Identity;
         }
      }

      public Matrix( params T[ ][ ] array ) {
         this.c = array[ 0 ].Length;
         this.r = array.Length;
         this.matrix = new T[ this.c ][ ];
         for( int Row = 0; Row < array.Length; ++Row )
            this.matrix[ Row ] = array[ Row ];
      }

      #endregion Constructors

      public override string ToString() {
         List<string> str = new List<string>();
         foreach( T[ ] x in this.GetRows() ) {
            str.Add( "|" + string.Join( "," , x ) + "|" );
         }
         return string.Format( "{0}\n" , string.Join( "\n" , str ) );
      }

      #region Overloaded Operators

      public static Matrix<T> operator -( Matrix<T> A , Matrix<T> B ) {
         if( A.Columns == B.Columns && A.Rows == B.Rows ) {
            return new Matrix<T>( IFunc<T[ ] , T[ ]>.SelectFromBoth( A.ElementsX() , B.ElementsX() , ( FromA , FromB ) => IFunc<T , T>.SelectFromBoth( FromA , FromB , A.Subtraction ).ToArray() ).ToArray() );
         } else {
            throw new MatrixDimensionException( "Incompatible MxN Matrices" );
         }
      }

      public static Matrix<T> operator *( Matrix<T> A , T B ) {
         //X => X * B
         return new Matrix<T>( A.ElementsX().Select( FromA => FromA.Select( a => A.MultiplyConstant( a , B ) ).ToArray() ).ToArray() );
      }

      public static Matrix<T> operator *( Matrix<T> A , Matrix<T> B ) {
         #region Theory

         //|123| |A   D|     |(1*A+2*B+3*C)(1*D+2*E+3*F)|
         //|(A)| |B(B)E|   = |                          |
         //|456| |C   F|     |(4*A+5*B+6*C)(4*D+5*E+6*F)|
         //
         //A=[MxN]=[2x3]
         //B=[MxN]=[3x2]
         //C=AxB=[2x3][3x2]
         //D=BxA=[3x2][2x3]
         //( Sum , Column , Row ) => Sum + (Column * Row)
         #endregion Theory
         if( A.Rows == B.Columns && A.Columns == B.Rows ) {
            var x = B.ElementsX().Select( FromB => A.ElementsY().Select( FromA => IFunc<T , T>.AccumulateFromBoth( FromB , FromA , A.Multiply ) ).ToArray() ).ToArray();
            return new Matrix<T>( x );
         } else {
            throw new MatrixDimensionException( "Incompatible MxN Matrices" );
         }
      }

      public static Matrix<T> operator /( Matrix<T> A , T B ) {
         return new Matrix<T>( A.ElementsX().Select( FromA => FromA.Select( a => A.DivideConstant( a , B ) ).ToArray() ).ToArray() );
      }

      public static Matrix<T> operator +( Matrix<T> A , Matrix<T> B ) {
         //( X , Y ) => X + Y
         if( A.Columns == B.Columns && A.Rows == B.Rows ) {
            return new Matrix<T>( IFunc<T[ ] , T[ ]>.SelectFromBoth( A.ElementsX() , B.ElementsX() , ( FromA , FromB ) => IFunc<T , T>.SelectFromBoth( FromA , FromB , A.Addition ).ToArray() ).ToArray() );
         } else {
            throw new MatrixDimensionException( "Incompatible MxN Matrices" );
         }
      }

      #endregion Overloaded Operators

      internal virtual void InitOps() {
         return;
      }

      public Matrix<T> SubMatrix( ref int RemoveX , ref int RemoveY ) {
         return new Matrix<T>( this.GetColumns( RemoveX , RemoveY ).ToArray() );
      }
   }
}