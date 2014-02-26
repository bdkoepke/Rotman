namespace Rotman.API
{
    using System;

    public class TickerNotFoundException : Exception
    {
        /// <summary>
        /// Thrown when the specified ticker was not found
        /// </summary>
        /// <param name="ticker"></param>
        public TickerNotFoundException(string ticker) : base(ticker)
        {
        }
    }
}