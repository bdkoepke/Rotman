namespace Core.Collections
{
    using System;
    using System.Linq;

    public static class ArrayExtensions
    {
        /// <summary>
        /// Converts a one dimensional array to a jagged array
        /// </summary>
        /// <typeparam name="T">
        /// The type of items in the array
        /// </typeparam>
        /// <param name="array">
        /// The array to convert
        /// </param>
        /// <returns>
        /// A jagged array containing the contents of the array
        /// </returns>
        public static T[] ToArray<T>(this Array array)
        {
            if (array.Rank != 1)
            {
                throw new InvalidCastException("array");
            }

            return (T[])array;
            // return (from object t in array select (T)t).ToArray();
        }

        /// <summary>
        /// Converts a two dimensional array to a jagged array
        /// </summary>
        /// <typeparam name="T">
        /// The type of items in the array
        /// </typeparam>
        /// <param name="array">
        /// The array to convert
        /// </param>
        /// <returns>
        /// A jagged array containing the contents of the array
        /// </returns>
        public static T[][] ToArray2<T>(this Array array)
        {
            if (array.Rank != 2)
            {
                throw new InvalidCastException("array");
            }

            var dimensional = (T[,])array;

            var dimension0 = dimensional.GetLength(0);
            var dimension1 = dimensional.GetLength(1);

            var jagged = new T[dimension0][];

            for (var i = 0; i < dimension0; i++)
            {
                jagged[i] = new T[dimension1];
                for (var j = 0; j < dimension1; j++)
                {
                    jagged[i][j] = dimensional[i, j];
                }
            }

            return jagged;
        }

        /// <summary>
        /// Transposes a two dimensional array
        /// </summary>
        /// <typeparam name="T">
        /// The type of items in the array
        /// </typeparam>
        /// <param name="array">
        /// The array to transpose
        /// </param>
        /// <returns>
        /// A transposed array
        /// </returns>
        public static T[][] Transpose<T>(this T[][] array)
        {
            var length = array.First().Length;

            // skip the first element and make sure their lengths match
            if (array.Skip(0).Any(x => length != x.Length))
            {
                throw new ArgumentException("array");
            }

            var transposed = new T[length][];

            for (var i = 0; i < length; i++)
            {
                transposed[i] = new T[array.Length];
                for (var j = 0; j < array.Length; j++)
                {
                    transposed[i][j] = array[j][i];
                }
            }

            return transposed;
        }

        /// <summary>
        /// Converts a three dimensional array to a jagged array
        /// </summary>
        /// <typeparam name="T">
        /// The type of items in the array
        /// </typeparam>
        /// <param name="array">
        /// The array to convert
        /// </param>
        /// <returns>
        /// A jagged array containing the contents of the array
        /// </returns>
        public static T[][][] ToArray3<T>(this Array array)
        {
            if (array.Rank != 3)
            {
                throw new InvalidCastException("array");
            }

            var dimensional = (T[,,])array;

            var dimension0 = dimensional.GetLength(0);
            var dimension1 = dimensional.GetLength(1);
            var dimension2 = dimensional.GetLength(2);

            var jagged = new T[dimension0][][];

            for (var i = 0; i < dimension0; i++)
            {
                jagged[i] = new T[dimension1][];
                for (var j = 0; j < dimension1; j++)
                {
                    jagged[i][j] = new T[dimension2];
                    for (var k = 0; k < dimension2; k++)
                    {
                        jagged[i][j][k] = dimensional[i, j, k];
                    }
                }
            }

            return jagged;
        }
    }
}
