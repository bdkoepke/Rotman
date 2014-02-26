namespace Rotman.API
{
    /// <summary>
    ///     Gets ticker information
    /// </summary>
    public enum TickerInformation
    {
        /// <summary>
        /// Last
        /// </summary>
        Last,

        /// <summary>
        /// Bid
        /// </summary>
        Bid,

        /// <summary>
        /// Ask
        /// </summary>
        Ask,

        /// <summary>
        /// Volume
        /// </summary>
        Volume,

        /// <summary>
        /// Position
        /// </summary>
        Position,

        /// <summary>
        /// VWAP
        /// </summary>
        Cost,

        /// <summary>
        /// Unrealized P/L
        /// </summary>
        Plunr,

        /// <summary>
        /// Realized P/L
        /// </summary>
        Plurel,

        /// <summary>
        /// Book view, bid size
        /// </summary>
        BidBook,

        /// <summary>
        /// Book view, ask side
        /// </summary>
        AskBook,

        /// <summary>
        /// Open personal orders to buy/sell
        /// </summary>
        OpenOrders,

        /// <summary>
        /// All personal orders to buy/sell
        /// </summary>
        AllOrders,

        /// <summary>
        /// The currency interest rate
        /// </summary>
        InterestRate,

        /// <summary>
        /// The number of live limit orders
        /// </summary>
        LimitOrders
    }
}