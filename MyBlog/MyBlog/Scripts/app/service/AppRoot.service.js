angular.module("appRoot")
    .service('appRootService', function ($http) {
    	var sayMsg = function (msg) {
    		return msg;
    	}

    	var postReqCallback = function (url, data, successCallback, failCallback, token) {
    		$http({
    			type: "POST",
    			dataType: 'json',
    			url: url,
    			cache: false,
    			contentType: 'application/x-www-form-urlencoded',
    			data: data,
    			crossDomain: true,
    			// headers: {
    			//     "Authorization": token
    			// },
    			xhrFields: {
    				withCredentials: false
    			},
    			beforeSend: function (xhr) {
    				if (typeof token != 'undefined') {
    					printLogMessage("appRootService", "postReqCallback", "auth: " + token, LOG_LEVEL_DEBUG)
    					xhr.setRequestHeader("Authorization", token);
    				}
    				else {
    					printLogMessage("appRootService", "postReqCallback", "no token sending", LOG_LEVEL_WARN)
    				}
    			}
    		})
            .then(function (receivedData) {
            	printLogMessage("appRootService", "postReqCallback", "data received successfully", LOG_LEVEL_INFO)
            	successCallback(receivedData)
            })
            .catch(function (xhr, textStatus, errorThrown) {
            	printLogMessage("appRootService", "postReqCallback", "something has problem: " + textStatus, LOG_LEVEL_ERROR)
            	failCallback(xhr.responseText, textStatus)
            });
    	}

    	var getReqCallback = function (url, data, successCallback, failCallback, token) {
    		$http({
    			type: "GET",
    			dataType: 'json',
    			url: url,
    			cache: false,
    			contentType: 'application/x-www-form-urlencoded',
    			params: data,
    			async: false,
    			crossDomain: true,
    			// headers: {
    			//     "Authorization": token
    			// },
    			xhrFields: {
    				withCredentials: false
    			},
    			beforeSend: function (xhr) {
    				if (typeof token != 'undefined') {
    					PrintLogMessage("appRootService", "getReqCallback", "auth: " + token, LOG_LEVEL_DEBUG)
    					xhr.setRequestHeader("Authorization", token);
    				}
    				else {
    					PrintLogMessage("appRootService", "getReqCallback", "no token sending", LOG_LEVEL_WARN)
    				}
    			}
    		})
            .then(function (receivedData) {
            	PrintLogMessage("appRootService", "getReqCallback", "data received successfully", LOG_LEVEL_INFO)
            	successCallback(receivedData)
            })
            .catch(function (xhr, textStatus, errorThrown) {
            	PrintLogMessage("appRootService", "getReqCallback", "something has problem: " + textStatus, LOG_LEVEL_ERROR)
            	failCallback(xhr.responseText, textStatus)
            });
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