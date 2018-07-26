using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Controllers
{
    public class DefineManager
    {
        public const int
            LIMIT_OF_SHOW_ARTICLES = 5,
            DEFAULT_SHOW_PAGE_NUMBER = 1,
            PAGE_NAVIGATION_SHOW_SIZE = 5,
            
            DEFAULT_SHOW_ARTICLE = 1,
            
            LOG_LEVEL_VERBOSE = 0,
            LOG_LEVEL_INFO = 1,
            LOG_LEVEL_DEBUG = 2,
            LOG_LEVEL_WARN = 3,
            LOG_LEVEL_ERROR = 4;

        public const string
            LOG_DEFAULT_CLASS = "LogManager",
            LOG_DEFAULT_METHOD = "PrintLogMessage",
            LOG_DEFAULT_MESSAGE = "This is default log message",
            LOG_MESSAGE_FORMAT = "{0} {1}: [{2, -20}] <{3, -20}> ({4})",

            LOG_LEVEL_VERBOSE_STR = "V",
            LOG_LEVEL_INFO_STR = "I",
            LOG_LEVEL_DEBUG_STR = "D",
            LOG_LEVEL_WARN_STR = "W",
            LOG_LEVEL_ERROR_STR = "E",

            DEFAULT_WRITER = "stories2"
            ;
    }
}