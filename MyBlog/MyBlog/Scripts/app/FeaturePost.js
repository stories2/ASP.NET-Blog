angular.module("featurePost", ['appRoot'])
    .controller("featurePostController", function ($scope, $log, appRootService) {
        $scope.testMsg = "test";
        appRootService.PrintLogMessage("featurePost", "featurePostController", "say, " + appRootService.SayMsg('Hi'), LOG_LEVEL_DEBUG)
    })
    .config(function ($logProvider) {
        $logProvider.debugEnabled(true);
    })