// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContainer.cs" company="">
//   
// </copyright>
// <summary>
//   Inversion of Control container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Core
{
    /// <summary>
    /// Inversion of Control container.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Resolves the specified type from the
        /// container
        /// </summary>
        /// <typeparam name="T">The type to resolve</typeparam>
        /// <returns>The resolved type</returns>
        T Resolve<T>();
    }
}
