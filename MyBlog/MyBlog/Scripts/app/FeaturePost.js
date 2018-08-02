angular.module("featurePost", ['appRoot'])
    .controller("featurePostController", function ($scope, $log, appRootService) {
        $scope.testMsg = "test";
        appRootService.PrintLogMessage("featurePost", "featurePostController", "say, " + appRootService.SayMsg('Hi'), LOG_LEVEL_DEBUG)
    })
    .controller("getFeaturePost", function ($scope, appRootService) {
        $scope.title = "test title";
        $scope.postUploadDateTime = "2018-08-02T07:50:18.280Z"
        $scope.highlightText = "This is highlight text"
        $scope.postID = 1
        $scope.imgUrl = "this is img url"
    })
    .config(function ($logProvider) {
        $logProvider.debugEnabled(true);
    })