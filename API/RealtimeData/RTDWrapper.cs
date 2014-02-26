namespace Rotman.API
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Core;

    using TTS;

    public class RTDWrapper
    {
        /// <summary>
        /// The logger implementation
        /// </summary>
        private readonly ILogger logger;

        #region Fields

        /// <summary>
        /// The default prog id
        /// </summary>
        private const string ProgId = "RIT2.RTD";

        /// <summary>
        ///     The underlying rtd server
        /// </summary>
        private readonly IRtdServer server;

        /// <summary>
        /// The set containing the registered topics
        /// </summary>
        private readonly ISet<int> topics;

        /// <summary>
        ///     Gets the topic count (-1 for no topics registered)
        /// </summary>
        private int topicIndex;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RTDWrapper" /> class.
        /// </summary>
        /// <param name="logger">
        /// The logging instance
        /// </param>
        /// <param name="progId">
        ///     The prog id.
        /// </param>
        public RTDWrapper(ILogger logger, string progId = ProgId)
        {
            this.logger = logger;
            Contract.Requires<ArgumentNullException>(progId != null);

            // No topics by default
            this.topicIndex = -1;

            // gets the type for an rtd server
            var type = Type.GetTypeFromProgID(progId);

            // get the server from COM
            this.server = (IRtdServer)Activator.CreateInstance(type);

            // start the server and throw away the callback
            this.server.ServerStart(null);

            // creates a new hashset to contain the registered topics
            this.topics = new HashSet<int>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the heartbeat of the rtd server
        /// </summary>
        public int HeartBeat
        {
            get
            {
                return this.server.Heartbeat();
            }
        }

        /// <summary>
        /// Gets a new topic id
        /// </summary>
        private int GetNewTopicId()
        {
            return this.topicIndex + 1;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets all the server data
        /// </summary>
        /// <param name="topicCount">
        ///     The number of topics that are registered
        /// </param>
        /// <returns>
        ///     The data for the topics we have registered
        /// </returns>
        public Array GetData(out int topicCount)
        {
            // prevent "might not be initialized before accessing"
            topicCount = -1;

            return this.server.RefreshData(ref topicCount);
        }

        /// <summary>
        /// Gets data when we don't care about the topic id
        /// </summary>
        /// <returns>
        /// The data for the topics we have registered
        /// </returns>
        public Array GetData()
        {
            int topicCount;
            return this.GetData(out topicCount);
        }

        /// <summary>
        ///     Registers the specified topic with the wrapper
        /// </summary>
        /// <param name="fields">
        ///     The field parameters to connect to
        /// </param>
        /// <returns>
        ///     The topic number returned by the server
        /// </returns>
        /// <exception cref="TopicNotFoundException">
        ///     Thrown when the specified topic is not found
        /// </exception>
        public int RegisterTopic(params string[] fields)
        {
            Contract.Requires<ArgumentNullException>(fields != null);
            Contract.Requires(Contract.ForAll(fields, x => x != null));
            Contract.Ensures(this.topicIndex >= 0);

            bool refresh = true;
            Array fieldsAsArray = fields;

            // create the new topic id. we could just increment
            // topic id, but then we would have to keep it in a 
            // consistent state in case of an exception, so 
            // instead we just keep it consistent until we are 
            // certain that the topic was actually registered 
            // correctly
            int newTopicId = this.GetNewTopicId();

            // make the connection to the server
            var actual = (string)this.server.ConnectData(newTopicId, ref fieldsAsArray, ref refresh);

            // the server returns a string containing field1|field2|field3
            // so we convert the fields array to the same format
            var expected = fields.ToKey();

            // did the above action succeed
            if (!actual.Equals(expected, StringComparison.InvariantCultureIgnoreCase))
            {
                if (this.logger.IsFatalEnabled)
                {
                    this.logger.Fatal(expected);
                }

                throw new TopicNotFoundException(expected);
            }

            // now save the topic id and return it
            this.topicIndex = newTopicId;

            // add the topic index to our tracked topics
            this.topics.Add(this.topicIndex);

            return this.topicIndex;
        }

        /// <summary>
        /// Checks whether the specified topic id has been
        /// registered or not
        /// </summary>
        /// <param name="topicId">
        /// The topic id to check
        /// </param>
        /// <returns>
        /// True if it is registered, false otherwise
        /// </returns>
        public bool IsRegistered(int topicId)
        {
            return this.topics.Contains(topicId);
        }

        /// <summary>
        ///     Unregisters the specified topic id
        /// </summary>
        /// <param name="topicId">
        ///     The topic id to unregister
        /// </param>
        public void UnregisterTopic(int topicId)
        {
            Contract.Assert(this.IsRegistered(topicId));

            this.server.DisconnectData(topicId);

            // now we can actually remove the topic from our tracked topics
            this.topics.Remove(topicId);
        }

        #endregion
    }
}