// -----------------------------------------------------------------------
// <copyright file="Class1.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Core.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Foreach syntactic sugar
        /// </summary>
        /// <typeparam name="T">
        /// The type of items in the enumerable
        /// </typeparam>
        /// <param name="enumerable">
        /// The enumerable to foreach over
        /// </param>
        /// <param name="action">
        /// The action to perform on each item in the enumerable
        /// </param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action.Invoke(item);
            }
        }
    }
}
