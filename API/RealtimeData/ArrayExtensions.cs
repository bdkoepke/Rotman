// -----------------------------------------------------------------------
// <copyright file="ArrayExtensions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Rotman.API
{
    /// <summary>
    /// Array extensions
    /// </summary>
    internal static class ArrayExtensions
    {
        /// <summary>
        /// Creates a key representation of a string array
        /// </summary>
        /// <param name="array">
        /// The array to convert
        /// </param>
        /// <param name="separator">
        /// The separator to use
        /// </param>
        /// <returns>
        /// A string representation of the array suitable for use
        /// as a dictionary key
        /// </returns>
        public static string ToKey(this string[] array, string separator = "|")
        {
            return string.Join(separator, array);
        }
    }
}
