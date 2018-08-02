angular.module("appRoot")
    .service('appRootService', function ($http) {
    	var sayMsg = function (msg) {
    		return msg;
    	}

    	var postReqCallback = function (transferData, successCallback, failCallback) {

    	}

    	var getReqCallback = function (transferData, successCallback, failCallback) {
            
    	}

    	var printLogMessage = function (className, methodName, message, logLevel) {
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

    	return {
    		SayMsg: sayMsg,
    		PostReqCallback: postReqCallback,
    		GetReqCallback: getReqCallback,
    		PrintLogMessage: printLogMessage
    	};
    })