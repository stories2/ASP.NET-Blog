angular.module("featurePost", ['appRoot'])
    .controller("featurePostController", function ($scope, $log, appRootService) {
        $scope.testMsg = "test";
        appRootService.PrintLogMessage("featurePost", "featurePostController", "say, " + appRootService.SayMsg('Hi'), LOG_LEVEL_DEBUG)
    })
    .controller("getFeaturePosts", function ($scope, appRootService) {
        
        $scope.getCurrentPageArticles = function (currentPageNumber) {
            appRootService.PrintLogMessage("featurePost", "getFeaturePost", "current page number: " + currentPageNumber, LOG_LEVEL_DEBUG);

            appRootService.GetReqCallback(API_GET_CURRENT_PAGE_LATEST_ARTICLE,
                {
                    "pageNumber": currentPageNumber
                },
                function (resultResponse) {
                    appRootService.PrintLogMessage("featurePost", "getFeaturePost", "successfully get response: " + JSON.stringify(resultResponse), LOG_LEVEL_DEBUG);

                    featureArticle = resultResponse["data"]["latestArticleList"][0]
                    
                    if(featureArticle !== undefined) {
                        $scope.title = featureArticle["title"];
                        $scope.postUploadDateTime = featureArticle["uploadDateTime"]
                        $scope.highlightText = featureArticle["highlightText"]
                        $scope.postID = featureArticle["articleID"]
                        $scope.imgUrl = featureArticle["imgUrl"]
                    }
                },
                function (error) {
                    appRootService.PrintLogMessage("featurePost", "getFeaturePost", "failed to get response: " + error, LOG_LEVEL_ERROR);
                })
        }
    })
    .config(function ($logProvider) {
        $logProvider.debugEnabled(true);
    })