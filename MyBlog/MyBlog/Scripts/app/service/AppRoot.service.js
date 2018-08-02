angular.module("appRoot")
    .service('appRootService', function ($http) {
    	var sayMsg = function (msg) {
    		return msg;
    	}

    	var postReqCallback = function (transferData, successCallback, failCallback) {

    	}

    	var getReqCallback = function (transferData, successCallback, failCallback) {

    	}

    	return {
    		sayMsg: sayMsg,
    		postReqCallback: postReqCallback,
    		getReqCallback: getReqCallback
    	};
    })