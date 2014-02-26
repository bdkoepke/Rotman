// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderException.cs" company="">
//   
// </copyright>
// <summary>
//   Exception thrown when an order cannot be completed
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rotman.API
{
    using System;

    /// <summary>
    /// Exception thrown when an order cannot be completed
    /// </summary>
    public class OrderException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderException"/> class. 
        /// Thrown when an order was unable to complete
        /// </summary>
        /// <param name="message">
        /// The reason the order could not be completed
        /// </param>
        public OrderException(string message)
            : base(message)
        {
        }

        #endregion
    }
}