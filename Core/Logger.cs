// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="">
//   
// </copyright>
// <summary>
//   The logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Core
{
    using System;

    /// <summary>
    /// Logger implementation.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Gets a value indicating whether the Debug level is enabled.
        /// </summary>
        public bool IsDebugEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Error level is enabled.
        /// </summary>
        public bool IsErrorEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Fatal level is enabled.
        /// </summary>
        public bool IsFatalEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Info level is enabled.
        /// </summary>
        public bool IsInfoEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Trace level is enabled.
        /// </summary>
        public bool IsTraceEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Warn level is enabled.
        /// </summary>
        public bool IsWarnEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        public void Debug(string message)
        {
            Console.WriteLine("Debug: {0}", message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        public void Error(string message)
        {
            Console.WriteLine("Error: {0}", message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        public void Fatal(string message)
        {
            Console.WriteLine("Fatal: {0}", message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        public void Info(string message)
        {
            Console.WriteLine("Info: {0}", message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        public void Trace(string message)
        {
            Console.WriteLine("Trace: {0}", message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        public void Warn(string message)
        {
            Console.WriteLine("Warn: {0}", message);
        }
    }
}