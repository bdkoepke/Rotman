namespace Rotman.API
{
    using System.Collections.Generic;

    /// <summary>
    /// Gets instantaneous ticker information
    /// </summary>
    public class Ticker
    {
        public Ticker(int last, int bid, int ask, int volume, int position, int cost, int unrealizedProfitLoss,
            int realizedProfitLoss, int bidBook, int askBook, int interestRate, int limitOrders)
        {
        }

        /// <summary>
        /// Gets the last price
        /// </summary>
        public int Last { get; private set; }

        /// <summary>
        /// Gets the bid price
        /// </summary>
        public int Bid { get; private set; }

        /// <summary>
        /// Gets the ask price
        /// </summary>
        public int Ask { get; private set; }

        /// <summary>
        /// Gets the volume
        /// </summary>
        public int Volume { get; private set; }

        /// <summary>
        /// Gets the position
        /// </summary>
        public int Position { get; private set; }

        /// <summary>
        /// Gets the volume weighted average price of the security
        /// </summary>
        public int Cost { get; private set; }

        /// <summary>
        /// Gets the unrealized profit loss on the ticker
        /// </summary>
        public int UnrealizedProfitLoss { get; private set; }

        /// <summary>
        /// Gets the realized profit loss on the ticker
        /// </summary>
        public int RealizedProfitLoss { get; private set; }

        /// <summary>
        /// Gets the book view, bid side
        /// </summary>
        public IList<Order> BidBook { get; private set; }

        /// <summary>
        /// Gets the book view, ask side
        /// </summary>
        public IList<Order> AskBook { get; private set; }

        /// <summary>
        /// Gets open personal orders to buy/sell
        /// </summary>
        public IList<Order> OpenOrders { get; private set; }

        /// <summary>
        /// Gets all personal orders to buy/sell
        /// </summary>
        public IList<Order> AllOrders { get; private set; }

        /// <summary>
        /// Gets the currency interest rate
        /// </summary>
        public int InterestRate { get; private set; }

        /// <summary>
        /// Gets the number of live limit orders
        /// </summary>
        public int LimitOrders { get; private set; }
    }
}