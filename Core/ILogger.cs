// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="">
//   
// </copyright>
// <summary>
//   Logger interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Core
{
    /// <summary>
    /// Logger interface
    /// </summary>
    public interface ILogger
    {
        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the Debug level is enabled.
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the Error level is enabled.
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the Fatal level is enabled.
        /// </summary>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the Info level is enabled.
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the Trace level is enabled.
        /// </summary>
        bool IsTraceEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether the Warn level is enabled.
        /// </summary>
        bool IsWarnEnabled { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        void Debug(string message);

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        void Error(string message);

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        void Fatal(string message);

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        void Info(string message);

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        void Trace(string message);

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">
        /// A string to be written
        /// </param>
        void Warn(string message);

        #endregion
    }
}