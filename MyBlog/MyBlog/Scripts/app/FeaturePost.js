angular.module("featurePost", ['appRoot'])
    .controller("featurePostController", function ($scope, $log, appRootService) {
        $scope.testMsg = "test";
        //console.log("can you see me?");
        $log.info("child -> say, " + appRootService.sayMsg('Hi'));
    })
    .config(function ($logProvider) {
        $logProvider.debugEnabled(true);
    })