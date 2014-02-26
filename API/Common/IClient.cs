namespace Rotman.API
{
    using System.Collections.Generic;

    /// <summary>
    /// Client interface
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Gets the tickers.
        /// </summary>
        IList<string> Tickers { get; }

        /// <summary>
        /// Gets the basis point
        /// A unit that is equal to 1/100th of
        /// 1%, and is used to denote the change
        /// in a financial instrument. The basis
        /// point is commonly used for calculating
        /// changes in interest rates, equity indexes
        /// and the yield of a fixed-income security. 
        /// </summary>
        double BasisPoint { get; }

        /// <summary>
        /// Gets the current cash amount.
        /// </summary>
        double Cash { get; }

        /// <summary>
        /// Gets the net liquidated value of the portfolio.
        /// </summary>
        double NetLiquidatedValue { get; }

        /// <summary>
        /// Gets the current period.
        /// </summary>
        double CurrentPeriod { get; }

        /// <summary>
        /// Gets the time remaining.
        /// </summary>
        int TimeRemaining { get; }

        /// <summary>
        /// Gets the total time.
        /// </summary>
        int TotalTime { get; }

        /// <summary>
        /// Gets a value indicating whether is game running.
        /// </summary>
        bool IsGameRunning { get; }

        /// <summary>
        /// Gets the elapsed time.
        /// </summary>
        int ElapsedTime { get; }

        /// <summary>
        /// Gets the year time.
        /// </summary>
        int YearTime { get; }

        /// <summary>
        /// Gets the orders
        /// </summary>
        /// <returns></returns>
        IList<Order> Orders { get; }
    }
}