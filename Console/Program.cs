// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rotman.Console
{
    using System;
    using System.Threading;

    using Core.Collections;

    using Rotman.API;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        public static void Main()
        {
            var wrapper = new RTDWrapper();

            IClient client = new RTDClient(wrapper);

            while (true)
            {
                client.Tickers.ForEach(Console.WriteLine);
                Thread.Sleep(wrapper.HeartBeat * 1000);
            }

            /*
            var client = new RTDWrapper("RIT2.RTD");

            IList<int> topics = new List<int>();

            IList<string> generalTopics = new List<string>();
            Array.ForEach(Enum.GetNames(typeof(General)), generalTopics.Add);
            Array.ForEach(Enum.GetNames(typeof(AssetInformation)), generalTopics.Add);
            Array.ForEach(Enum.GetNames(typeof(SecurityInformation)), generalTopics.Add);
            Array.ForEach(Enum.GetNames(typeof(NewsInformation)), generalTopics.Add);
                
            generalTopics.ForEach(x => topics.Add(client.RegisterTopic(x)));

            client.RegisterTopic("CRZY", "LAST");

            client.RegisterTopic("Invalid");

            client.UnregisterTopic(9);

            // var timeRemaining = client.GetData<int>(Enum.GetName(typeof(General), General.TimeRemaining));
            while (true)
            {
                var previousTimeRemaining = timeRemaining;
                timeRemaining = client.GetData<int>(Enum.GetName(typeof(General), General.TimeRemaining));

                Console.WriteLine(timeRemaining < previousTimeRemaining ? "running" : "not running");

                int topicCount;
                var array = client.GetData(out topicCount);

                var result = array.ToArray2<object>().Transpose();

                foreach (var items in result)
                {
                    Console.WriteLine("[{0}]", string.Join(",", items));
                }

                Thread.Sleep(1000);
            }
            */
        } 
    }
}