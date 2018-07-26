using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Controllers
{
    public class LogManager
    {
        public static void PrintLogMessage (
            string className = DefineManager.LOG_DEFAULT_CLASS, 
            string methodName = DefineManager.LOG_DEFAULT_METHOD, 
            string message = DefineManager.LOG_DEFAULT_MESSAGE, 
            int logLevel = DefineManager.LOG_LEVEL_WARN)
        {
            string logLevelStr = DefineManager.LOG_LEVEL_WARN_STR;
            switch(logLevel)
            {
                case DefineManager.LOG_LEVEL_VERBOSE:
                    logLevelStr = DefineManager.LOG_LEVEL_VERBOSE_STR;
                    break;
                case DefineManager.LOG_LEVEL_INFO:
                    logLevelStr = DefineManager.LOG_LEVEL_INFO_STR;
                    break;
                case DefineManager.LOG_LEVEL_DEBUG:
                    logLevelStr = DefineManager.LOG_LEVEL_DEBUG_STR;
                    break;
                case DefineManager.LOG_LEVEL_WARN:
                    logLevelStr = DefineManager.LOG_LEVEL_WARN_STR;
                    break;
                case DefineManager.LOG_LEVEL_ERROR:
                    logLevelStr = DefineManager.LOG_LEVEL_ERROR_STR;
                    break;
                default:
                    break;
            }

            string logMsg = String.Format(DefineManager.LOG_MESSAGE_FORMAT, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), logLevelStr, className, methodName, message);
            System.Diagnostics.Debug.WriteLine(logMsg);
        }
    }
}