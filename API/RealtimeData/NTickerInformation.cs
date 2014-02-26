namespace Rotman.API
{
    /// <summary>
    /// Ticker information requiring N parameter
    /// </summary>
    public enum NTickerInformation
    {
        /// <summary>
        /// The VWAP that would occur if you send an order to market sell N volume
        /// </summary>
        MktSell,

        /// <summary>
        /// The VWAP that would occur if you send an order to market buy N volume
        /// </summary>
        MktBuy,

        /// <summary>
        /// The Nth bid in the book
        /// </summary>
        Bid,

        /// <summary>
        /// The size of the Nth bid in the bok
        /// </summary>
        Bsz,

        /// <summary>
        /// The Nth ask in the book
        /// </summary>
        Ask,

        /// <summary>
        /// The size of the Nth ask in the book
        /// </summary>
        Asz,

        /// <summary>
        /// The aggregate (by price) Nth bid in the book
        /// </summary>
        Agbid,

        /// <summary>
        /// The size of the aggregate (by price) Nth bid in the book
        /// </summary>
        Agbsz,

        /// <summary>
        /// The aggregate (by price) Nth ask in the book
        /// </summary>
        Agask,

        /// <summary>
        /// The size of the aggregate (by price) Nth ask in the book
        /// </summary>
        Agasz,
    }
}