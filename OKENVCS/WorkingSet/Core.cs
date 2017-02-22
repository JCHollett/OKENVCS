namespace TheoryLib.IFunction {

   using System;
   using System.Collections.Generic;

   /// <summary>
   /// Two TSource IFunctions, with a common TResult.
   /// </summary>
   /// <typeparam name="TSource">TSource</typeparam>
   /// <typeparam name="TSource2">TSource2</typeparam>
   /// <typeparam name="TResult">TResult</typeparam>
   public static class IFunc<TSource, TSource2, TResult> {

      /// <summary>
      /// Return an IEnumerable by applying Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      public static IEnumerable<TResult> SelectFromBoth( IEnumerable<TSource> A , IEnumerable<TSource2> B , Func<TSource , TSource2 , TResult> Function ) {
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource2> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               yield return Function( AE.Current , BE.Current );
            } else {
               yield return Function( AE.Current , default( TSource2 ) );
            }
         }
         while( BE.MoveNext() ) {
            yield return Function( default( TSource ) , BE.Current );
         }
      }

      /// <summary>
      /// Accumuluate a result by applying Lambda Function parallel to each element in order first to last. Ex: (A,B,C) => (C=A+B)
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>TResult</returns>
      public static TResult AccumulateFromBoth( IEnumerable<TSource> A , IEnumerable<TSource2> B , Func<TSource , TSource2 , TResult , TResult> Function ) {
         TResult result = default(TResult);
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource2> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               result = Function( AE.Current , BE.Current , result );
            } else {
               result = Function( AE.Current , default( TSource2 ) , result );
            }
         }
         while( BE.MoveNext() ) {
            result = Function( default( TSource ) , BE.Current , result );
         }
         return result;
      }
   }

   /// <summary>
   /// One TSource IFunction, with a TResult.
   /// </summary>
   /// <typeparam name="TSource">TSource</typeparam>
   /// <typeparam name="TResult">TResult</typeparam>
   public static class IFunc<TSource, TResult> {

      /// <summary>
      /// Accumuluate a result by applying Lambda Function parallel to each element in order first to last. Ex: (A,B,C) => (C=A+B)
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      public static TResult AccumulateFromBoth( IEnumerable<TSource> A , IEnumerable<TSource> B , Func<TSource , TSource , TResult , TResult> Function ) {
         TResult result = default(TResult);
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               result = Function( AE.Current , BE.Current , result );
            } else {
               result = Function( AE.Current , default( TSource ) , result );
            }
         }
         while( BE.MoveNext() ) {
            result = Function( default( TSource ) , BE.Current , result );
         }
         return result;
      }

      /// <summary>
      /// Apply Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Action">Action</param>
      public static void ApplyBoth( IEnumerable<TSource> A , IEnumerable<TSource> B , Action<TSource , TSource> Action ) {
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               Action( AE.Current , BE.Current );
            } else {
               Action( AE.Current , default( TSource ) );
            }
         }
         while( BE.MoveNext() ) {
            Action( default( TSource ) , BE.Current );
         }
      }

      /// <summary>
      /// Return an IEnumerable by applying Lambda Function parallel to each element in order first to last.
      /// </summary>
      /// <param name="A">IEnumerable</param>
      /// <param name="B">IEnumerable</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      public static IEnumerable<TResult> SelectFromBoth( IEnumerable<TSource> A , IEnumerable<TSource> B , Func<TSource , TSource , TResult> Function ) {
         IEnumerator<TSource> AE = A.GetEnumerator();
         IEnumerator<TSource> BE = B.GetEnumerator();
         while( AE.MoveNext() ) {
            if( BE.MoveNext() ) {
               yield return Function( AE.Current , BE.Current );
            } else {
               yield return Function( AE.Current , default( TSource ) );
            }
         }
         while( BE.MoveNext() ) {
            yield return Function( default( TSource ) , BE.Current );
         }
      }
   }

   /// <summary>
   /// TResult IFunction, Currently only used for simple summation.
   /// </summary>
   /// <typeparam name="TResult">TResult</typeparam>
   public static class IFunc<TResult> {

      /// <summary>
      /// Accumuluate a result by applying Lambda Function parallel to each element in order first to last. Must be equal in size.
      /// </summary>
      /// <param name="A">TResult[ ]</param>
      /// <param name="B">TResult[ ]</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      public static TResult AccumulateFromBoth( TResult[ ] A , TResult[ ] B , Func<TResult , TResult , TResult , TResult> Function ) {
         if( A.Length != B.Length ) throw new Exception( "Asymmetrical Array of Data" );
         TResult result = default(TResult);
         for( int i = 0; i < A.Length; ++i ) {
            result = Function( A[ i ] , B[ i ] , result );
         }
         return result;
      }

      /// <summary>
      /// Accumuluate a result by applying Lambda Function parallel to each element in order first to last. Must be equal in size.
      /// </summary>
      /// <param name="A">List</param>
      /// <param name="B">List</param>
      /// <param name="Function">Func</param>
      /// <returns>IEnumerable</returns>
      public static TResult AccumulateFromBoth( List<TResult> A , List<TResult> B , Func<TResult , TResult , TResult , TResult> Function ) {
         if( A.Count != B.Count ) throw new Exception( "Asymmetrical Array of Data" );
         TResult result = default(TResult);
         for( int i = 0; i < A.Count; ++i ) {
            result = Function( A[ i ] , B[ i ] , result );
         }
         return result;
      }
   }
}