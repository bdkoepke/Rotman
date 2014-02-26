// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderType.cs" company="">
//   
// </copyright>
// <summary>
//   An order in a market such as a stock market, bond market,
//   commodity market or financial derivative market is an
//   instruction from customers to brokers to buy or sell on
//   the exchange. These instructions can be simple or
//   complicated. There are some standard instructions for such
//   orders.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rotman.API
{
    /// <summary>
    /// An order in a market such as a stock market, bond market,
    /// commodity market or financial derivative market is an
    /// instruction from customers to brokers to buy or sell on
    /// the exchange. These instructions can be simple or
    /// complicated. There are some standard instructions for such
    /// orders.
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// A market order is a buy or sell order to be executed immediately
        /// at current market prices. As long as there are willing sellers
        /// and buyers, market orders are filled. Market orders are therefore
        /// used when certainty of execution is a priority over price of
        /// execution.
        /// </summary>
        Market = 0,

        /// <summary>
        /// A limit order is an order to buy a security at no more than a
        /// specific price, or to sell a security at no less than a specific
        /// price (called "or better" for either direction). This gives the
        /// trader (customer) control over the price at which the trade is
        /// executed; however, the order may never be executed ("filled").
        /// [2] Limit orders are used when the trader wishes to control
        /// price rather than certainty of execution.
        /// </summary>
        Limit = 1
    }
}