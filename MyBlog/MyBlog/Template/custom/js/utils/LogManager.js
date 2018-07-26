function PrintLogMessage(className, methodName, message, logLevel) 
{
    logLevelStr = LOG_LEVEL_WARN_STR
    switch (logLevel) {
        case LOG_LEVEL_VERBOSE:
            logLevelStr = LOG_LEVEL_VERBOSE_STR
            break;
        case LOG_LEVEL_INFO:
            logLevelStr = LOG_LEVEL_INFO_STR
            break;
        case LOG_LEVEL_DEBUG:
            logLevelStr = LOG_LEVEL_DEBUG_STR
            break;
        case LOG_LEVEL_WARN:
            logLevelStr = LOG_LEVEL_WARN_STR
            break;
        case LOG_LEVEL_ERROR:
            logLevelStr = LOG_LEVEL_ERROR_STR
            break;
        default:
            break;
    }
    date = new Date()
    console.log("", date.toISOString(), logLevelStr, "[" + className + "]", "{" + methodName + "}", "(" + message + ")")
}