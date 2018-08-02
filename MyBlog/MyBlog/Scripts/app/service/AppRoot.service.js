angular.module("appRoot")
    .service('appRootService', function () {
    	this.sayMsg = function (msg) {
    		return msg;
    	}
    })