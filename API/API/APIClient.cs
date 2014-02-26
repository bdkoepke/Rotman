// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="">
//   
// </copyright>
// <summary>
//   Enhanced Rotman Client
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Rotman.API
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Core;

    using TTS;

    /// <summary>
    /// Enhanced Rotman Client
    /// </summary>
    public class APIClient : IClient
    {
        #region Fields

        /// <summary>
        /// The underlying rotman api object
        /// </summary>
        private readonly IAPI api;

        /// <summary>
        /// Logger class
        /// </summary>
        private readonly ILogger logger;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="APIClient"/> class. 
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public APIClient(ILogger logger)
        {
            this.api = new API();
            this.logger = logger;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the tickers.
        /// </summary>
        public IList<string> Tickers
        {
            get
            {
                return this.api.GetTickers();
            }
        }

        /// <summary>
        /// Gets the basis point
        /// A unit that is equal to 1/100th of
        /// 1%, and is used to denote the change
        /// in a financial instrument. The basis
        /// point is commonly used for calculating
        /// changes in interest rates, equity indexes
        /// and the yield of a fixed-income security. 
        /// </summary>
        public double BasisPoint
        {
            get
            {
                return this.api.GetBP();
            }
        }

        /// <summary>
        /// Gets the current cash amount.
        /// </summary>
        public double Cash
        {
            get
            {
                return this.api.GetCash();
            }
        }

        /// <summary>
        /// Gets the net liquidated value of the portfolio
        /// </summary>
        public double NetLiquidatedValue
        {
            get
            {
                return this.api.GetNLV();
            }
        }

        /// <summary>
        /// Gets the current period.
        /// </summary>
        public double CurrentPeriod
        {
            get
            {
                return this.api.GetCurrentPeriod();
            }
        }

        /// <summary>
        /// Gets the time remaining.
        /// </summary>
        public int TimeRemaining
        {
            get
            {
                return this.api.GetTimeRemaining();
            }
        }

        /// <summary>
        /// Gets the total time.
        /// </summary>
        public int TotalTime
        {
            get
            {
                return this.api.GetTotalTime();
            }
        }

        /// <summary>
        /// Gets a value indicating whether is game running.
        /// </summary>
        public bool IsGameRunning
        {
            get
            {
                return this.ElapsedTime != 0;
            }
        }

        /// <summary>
        /// Gets the elapsed time.
        /// </summary>
        public int ElapsedTime
        {
            get
            {
                return this.TotalTime - this.TimeRemaining;
            }
        }

        /// <summary>
        /// Gets the year time.
        /// </summary>
        public int YearTime
        {
            get
            {
                return this.api.GetYearTime();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Executes a limit market order
        /// </summary>
        /// <param name="ticker">
        /// The ticker to buy or sell
        /// </param>
        /// <param name="volume">
        /// The volume of the limit order. Positive is buy, negative is sell.
        /// </param>
        /// <param name="price">
        /// The price to issue the limit order at
        /// </param>
        public void AddLimitOrder(string ticker, int volume, double price)
        {
            this.AddOrder(ticker, volume, price, OrderType.Limit);
        }

        /// <summary>
        /// Executes a market add order
        /// </summary>
        /// <param name="ticker">
        /// The ticker to buy or sell
        /// </param>
        /// <param name="volume">
        /// The volume of the market order. Positive is buy, negative is sell
        /// </param>
        public void AddMarketOrder(string ticker, int volume)
        {
            this.AddOrder(ticker, volume, 0, OrderType.Market);
        }

        /// <summary>
        /// Executes a queued limit market order
        /// </summary>
        /// <param name="ticker">
        /// The ticker to buy or sell
        /// </param>
        /// <param name="volume">
        /// The volume of the limit order. Positive is buy, negative is sell.
        /// </param>
        /// <param name="price">
        /// The price to issue the limit order at
        /// </param>
        /// <returns>
        /// The queued order id.
        /// </returns>
        public int AddQueuedLimitOrder(string ticker, int volume, double price)
        {
            return this.AddQueuedOrder(ticker, volume, price, OrderType.Limit);
        }

        /// <summary>
        /// Executes a queued market add order
        /// </summary>
        /// <param name="ticker">
        /// The ticker to buy or sell
        /// </param>
        /// <param name="volume">
        /// The volume of the market order. Positive is buy, negative is sell
        /// </param>
        /// <returns>
        /// The queued market order id.
        /// </returns>
        public int AddQueuedMarketOrder(string ticker, int volume)
        {
            return this.AddQueuedOrder(ticker, volume, 0, OrderType.Market);
        }

        /// <summary>
        /// The cancel order.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void CancelOrder(int id)
        {
            this.api.CancelOrder(id);
        }

        /// <summary>
        /// The cancel queued order.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void CancelQueuedOrder(int id)
        {
            this.api.CancelQueuedOrder(id);
        }

        /// <summary>
        /// Clears the queued orders
        /// </summary>
        public void ClearQueuedOrders()
        {
            this.api.ClearQueuedOrders();
        }

        /// <summary>
        /// Gets the order information
        /// </summary>
        /// <param name="id">
        /// The order id
        /// </param>
        /// <returns>
        /// The order
        /// </returns>
        public Order GetOrderInfo(int id)
        {
            return new Order(this.api.GetOrderInfo(id));
        }

        /// <summary>
        /// Gets the orders
        /// </summary>
        /// <returns></returns>
        public IList<Order> Orders
        {
            get
            {
                return this.api.GetOrders().Select(this.GetOrderInfo).ToArray();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an order
        /// </summary>
        /// <param name="ticker">
        /// The ticker to buy or sell
        /// </param>
        /// <param name="volume">
        /// The volume of the ticker to buy or sell
        /// </param>
        /// <param name="price">
        /// The price to purchase the ticker at
        /// </param>
        /// <param name="orderType">
        /// The order type.
        /// </param>
        private void AddOrder(string ticker, int volume, double price, OrderType orderType)
        {
            Contract.Requires(volume != 0);
            Contract.Requires(this.Tickers.Contains(ticker));
            Contract.Requires(price >= 0);

            var buySell = (BuySell)Math.Sign(volume);

            switch (buySell)
            {
                case BuySell.Buy:
                    break;
                case BuySell.Sell:
                    volume = -volume;
                    break;
            }

            var message = string.Format(
                "{0} ticker {1} volume {2} price {3} orderType {4}", buySell, ticker, volume, price, orderType);

            if (this.api.AddOrder(ticker, volume, price, (int)buySell, (int)orderType))
            {
                this.logger.Info(message);
            }
            else
            {
                message = "Failed to submit " + message;
                this.logger.Warn(message);
                throw new OrderException(message);
            }
        }

        /// <summary>
        /// Adds a queued order
        /// </summary>
        /// <param name="ticker">
        /// The ticker to buy or sell
        /// </param>
        /// <param name="volume">
        /// The volume of the ticker to buy or sell
        /// </param>
        /// <param name="price">
        /// The price to purchase the ticker at
        /// </param>
        /// <param name="orderType">
        /// The order type.
        /// </param>
        /// <returns>
        /// The order id
        /// </returns>
        private int AddQueuedOrder(string ticker, int volume, double price, OrderType orderType)
        {
            Contract.Requires(volume != 0);
            Contract.Requires(this.Tickers.Contains(ticker));
            Contract.Requires(price >= 0);

            var buySell = (BuySell)Math.Sign(volume);

            switch (buySell)
            {
                case BuySell.Buy:
                    break;
                case BuySell.Sell:
                    volume = -volume;
                    break;
            }

            var message = string.Format(
                "{0} ticker {1} volume {2} price {3} orderType {4}", buySell, ticker, volume, price, orderType);

            var orderID = this.api.AddQueuedOrder(ticker, volume, price, (int)buySell, (int)orderType);

            if (orderID >= 0)
            {
                this.logger.Info(message);
            }
            else
            {
                message = "Failed to submit " + message;
                this.logger.Warn(message);
                throw new OrderException(message);
            }

            return orderID;
        }

        #endregion
    }
}