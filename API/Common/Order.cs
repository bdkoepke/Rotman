// -----------------------------------------------------------------------
// <copyright file="Order.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Rotman.API
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Object encapsulating order behavior
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// Use this class when you want to parsel out the order manually.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="ticker">
        /// The ticker.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        /// <param name="buySell">
        /// The buy sell.
        /// </param>
        /// <param name="orderType">
        /// The order type.
        /// </param>
        public Order(int id, string ticker, double price, BuySell buySell, OrderType orderType)
        {
            this.ID = id;
            this.Ticker = ticker;
            this.Price = price;
            this.BuySell = buySell;
            this.OrderType = orderType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// Used for the default api
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        public Order(IList<object> order)
        {
            // there should be exactly nine elements in the 
            // order
            Contract.Requires(order.Count == 9);

            this.ID = (int)order[(int)OrderArray.ID];
            this.Ticker = (string)order[(int)OrderArray.Ticker];
            this.BuySell = (BuySell)order[(int)OrderArray.BuySell];
            this.OrderType = (OrderType)order[(int)OrderArray.OrderType];
            this.Price = (double)order[(int)OrderArray.Price];
        }

        /// <summary>
        /// Gets the orders id
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the ticker.
        /// </summary>
        public string Ticker { get; private set; }

        /// <summary>
        /// Gets the buy sell.
        /// </summary>
        public BuySell BuySell { get; private set; }

        /// <summary>
        /// Gets the order type.
        /// </summary>
        public OrderType OrderType { get; private set; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        public double Price { get; private set; }
    }
}
