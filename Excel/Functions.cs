// -----------------------------------------------------------------------
// <copyright file="Functions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Rotman.Excel
{
    using System;

    using ExcelDna.Integration;

    using Rotman.API;

    /// <summary>
    ///     User defined functions
    /// </summary>
    public class Functions
    {
        #region Constants

        private const string Category = "Rotman";

        #endregion

        #region Static Fields

        private static readonly RTDWrapper RTDWrapper = new RTDWrapper("RIT2.RTD");

        #endregion

        #region Public Methods and Operators

        [ExcelFunction(Description = "RIT2 Wrapper", Category = Category)]
        public static string RIT(string fields)
        {
            var topic = RTDWrapper.RegisterTopic(fields);

            int topicCount;
            var array = RTDWrapper.GetData(out topicCount);
            
            string result = array.GetValue(1, topic).ToString();

            return result;
        }

        [ExcelFunction]
        public static double Mul(double x, double y)
        {
            return x * y;
        }

        #endregion
    }
}