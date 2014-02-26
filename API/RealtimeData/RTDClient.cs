namespace Rotman.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core;
    using Core.Collections;

    public class RTDClient : IClient
    {
        /// <summary>
        /// The logger to use
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The rtd wrapper
        /// </summary>
        private readonly RTDWrapper rtdWrapper;

        /// <summary>
        /// The dictionary containing the keys for obtaining the rtd data
        /// </summary>
        private readonly IDictionary<string, int> topics = new Dictionary<string, int>();

        /// <summary>
        /// Instantiates a new instance of the <see cref="RTDClient"/> class.
        /// </summary>
        /// <param name="logger">
        /// The injected logger
        /// </param>
        /// <param name="rtdWrapper">
        /// The rtd wrapper to use
        /// </param>
        public RTDClient(ILogger logger, RTDWrapper rtdWrapper)
        {
            this.logger = logger;
            this.rtdWrapper = rtdWrapper;
            this.Initialize();
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="RTDClient"/> class.
        /// Use this one if you don't know what you are doing...
        /// </summary>
        public RTDClient(ILogger logger) : this(logger, new RTDWrapper(logger))
        {
        }

        /// <summary>
        /// Initializes the rtd client and subscribes to the necessary data streams
        /// </summary>
        private void Initialize()
        {
            IList<string> topics = new List<string>();
            Array.ForEach(Enum.GetNames(typeof(General)), topics.Add);
            Array.ForEach(Enum.GetNames(typeof(AssetInformation)), topics.Add);
            Array.ForEach(Enum.GetNames(typeof(SecurityInformation)), topics.Add);
            Array.ForEach(Enum.GetNames(typeof(TickerInformation)), topics.Add);
            // Array.ForEach(Enum.GetNames(typeof(NewsInformation)), topics.Add);

            topics.ForEach(fields => this.RegisterTopic(fields));

            foreach (var ticker in this.Tickers)
            {
                foreach (var field in Enum.GetNames(typeof(TickerInformation)))
                {
                    this.RegisterTopic(ticker, field);
                }
            }
        }

        /// <summary>
        /// Registers the specified topic
        /// </summary>
        /// <param name="fields">
        /// The fields to register
        /// </param>
        private void RegisterTopic(params string[] fields)
        {
            this.topics.Add(fields.ToKey(), this.rtdWrapper.RegisterTopic(fields));
        }

        /// <summary>
        /// Gets the specified key from the data
        /// </summary>
        /// <typeparam name="T">
        /// The type of data we expect
        /// </typeparam>
        /// <param name="key">
        /// The key for the data
        /// </param>
        /// <returns>
        /// The value for the key as the specified data type
        /// </returns>
        private T GetData<T>(string key)
        {
            int topicId;
            if (! this.topics.TryGetValue(key, out topicId))
            {
                throw new TopicNotFoundException(key);
            }

            return (T)this.rtdWrapper.GetData().ToArray2<object>().Transpose().First(x => ((int)x[0]).Equals(topicId))[1];
        }

        /// <summary>
        /// Gets the tickers
        /// </summary>
        public IList<string> Tickers
        {
           get
           {
               return this.GetData<string>(SecurityInformation.AllTickers.ToString()).Split(new[] { ',' });
           }
        }

        /// <summary>
        /// Gets the specified ticker
        /// </summary>
        public Ticker GetTicker(string ticker)
        {
            if (! this.Tickers.Contains(ticker))
            {
                throw new TickerNotFoundException(ticker);
            }

            throw new NotImplementedException();
        }

        public double BasisPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double Cash
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double NetLiquidatedValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double CurrentPeriod
        {
            get
            {
                return this.GetData<int>(General.Period.ToString());
            }
        }

        public int TimeRemaining
        {
            get
            {
                return this.GetData<int>(General.TimeRemaining.ToString());
            }
        }

        public int TotalTime { get; private set; }

        public bool IsGameRunning
        {
            get
            {
                return this.ElapsedTime != 0;
            }
        }

        public int ElapsedTime
        {
            get; private set;
        }

        public int YearTime
        {
            get; private set;
        }

        public IList<Order> Orders { get; private set; }

        public IList<string> News { get; private set; }
    }
}
