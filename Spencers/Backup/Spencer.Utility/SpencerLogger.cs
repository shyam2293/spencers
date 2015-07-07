using System;
using System.Collections.Generic;
//Microsoft enterprise Service 4.0
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Spencer.Utility
{
    /// <summary>
    /// Created by: Anandhan S
    /// Created on: 23/12/2010
    /// </summary>
    public static class SpencerLogger
    {        
        /// <summary>
        /// To Log exception informations
        /// Stream witer is replaced with enterprise library
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex)
        {
            LogEntry logEntry = null;
            try
            {
                logEntry = new LogEntry();

                logEntry.Categories.Clear();
                logEntry.TimeStamp = DateTime.Now;
                logEntry.Severity = System.Diagnostics.TraceEventType.Error;
                logEntry.Message = message;
                logEntry.Categories.Add("General Category");
                Logger.Write(logEntry);
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                Logger.Write("Method: " + trace.GetFrame(trace.FrameCount - 1).GetMethod().Name);
                Logger.Write("Line: " + trace.GetFrame(trace.FrameCount - 1).GetFileLineNumber());
                Logger.Write("Column: " + trace.GetFrame(trace.FrameCount - 1).GetFileColumnNumber());
            }
            catch
            {
                throw;
            }
            finally
            {
                logEntry = null;
            }
        }

        /// <summary>
        /// To log error informations
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            LogEntry logEntry = null;
            try
            {
                logEntry = new LogEntry();
                logEntry.Categories.Clear();
                logEntry.TimeStamp = DateTime.Now;
                logEntry.Severity = System.Diagnostics.TraceEventType.Error;
                logEntry.Message = message;
                logEntry.Categories.Add("General Category");
                Logger.Write(logEntry);
            }
            catch
            {
                throw;
            }
            finally
            {
                logEntry = null;
            }
        }

        /// <summary>
        /// Method to log the Error message into the log file and event viewer.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="extendedProperties">Dictionary of key/value pairs to log.</param>
        public static void Error(string message, IDictionary<string, object> extendedProperties)
        {
            LogEntry logEntry = null;
            try
            {
                logEntry = new LogEntry();

                logEntry.Categories.Clear();
                logEntry.TimeStamp = DateTime.Now;
                logEntry.Severity = System.Diagnostics.TraceEventType.Error;
                logEntry.Message = message;
                logEntry.ExtendedProperties = extendedProperties;
                logEntry.Categories.Add("General Category");
                Logger.Write(logEntry);
            }
            catch
            {
                throw;
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// To Log informations & dictionary object
        /// Stream witer is replaced with enterprise library
        /// </summary>
        /// <param name="message"></param>
        /// <param name="extendedProperties"></param>
        public static void Info(string message, IDictionary<string, object> extendedProperties)
        {
            LogEntry logEntry = null;
            try
            {
                logEntry = new LogEntry();

                logEntry.TimeStamp = DateTime.Now;
                logEntry.Message = message;
                logEntry.Severity = System.Diagnostics.TraceEventType.Information; ;                
                logEntry.ExtendedProperties = extendedProperties;
                logEntry.Categories.Add("General Category");
                Logger.Write(logEntry);
            }
            catch
            {
                throw;
            }
            finally
            {
                logEntry = null;
            }
        }

        /// <summary>
        /// To log information
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            LogEntry logEntry = null;
            try
            {
                logEntry = new LogEntry();

                logEntry.TimeStamp = DateTime.Now;
                logEntry.Severity = System.Diagnostics.TraceEventType.Information;
                logEntry.Message = message;
                logEntry.Categories.Add("General Category");
                Logger.Write(logEntry);
            }
            catch
            {
                throw;
            }
            finally
            {
                logEntry = null;
            }
        }
    }
}
