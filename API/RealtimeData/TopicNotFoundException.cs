namespace Rotman.API
{
    using System;

    public class TopicNotFoundException : Exception
    {
        /// <summary>
        /// Thrown when the specified topic is not found
        /// </summary>
        /// <param name="fields">
        /// The topic that wasn't found
        /// </param>
        public TopicNotFoundException(string fields) : base(fields)
        {
        }
    }
}