using NLog;
using NLog.Config;
using NLog.Targets;

using System;

namespace BulletinReport.Common.Utilities
{
    /// <summary>
    /// Serves as a decorator around NLog to log messages to a rolling file
    /// </summary>
    public static class Tracer
    {
        private static Logger _logger;

        static Tracer()
        {
            var fileTarget = new FileTarget();
            fileTarget.FileName = "${basedir}/file.log";
            fileTarget.Layout = "${longdate} ${message}";
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.ArchiveFileName = "${basedir}/Archives/{#}.log";
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Date;
            var logginConfig = new LoggingConfiguration();

            logginConfig.AddTarget("file", fileTarget);
            logginConfig.AddRule(LogLevel.Trace, LogLevel.Error, fileTarget);
            LogManager.Configuration = logginConfig;

            _logger = LogManager.GetLogger("Default");




        }

        /// <summary>
        /// Logs a trace message
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public static void Trace(string message)
        {
            _logger.Trace(message);
        }

        /// <summary>
        /// Logs a warning message
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public static void Warning(string message)
        {
            _logger.Warn(message);
        }

        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public static void Error(Exception exp)
        {
            var innerExp = exp;
            while (innerExp != null)
            {
                _logger.Error(innerExp.Message);

                innerExp = innerExp.InnerException;
            }
        }

        /// <summary>
        /// Logs an information message
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public static void Information(string message)
        {
            _logger.Info(message);
        }
    }
}
