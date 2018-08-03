angular.module("normalPost", ['appRoot'])
    .controller("getNormalPosts", function ($scope, appRootService) {
        $scope.getCurrentPageArticles = function (currentPageNumber) {
            appRootService.PrintLogMessage("normalPost", "getNormalPosts", "current page number: " + currentPageNumber, LOG_LEVEL_DEBUG);

            appRootService.GetReqCallback(API_GET_CURRENT_PAGE_LATEST_ARTICLE,
                {
                    "pageNumber": currentPageNumber
                },
                function (resultResponse) {
                    appRootService.PrintLogMessage("normalPost", "getNormalPosts", "successfully get response: " + JSON.stringify(resultResponse), LOG_LEVEL_DEBUG);

                    //$scope.latestArticleList = resultResponse["data"]["latestArticleList"].shift();
                    articleList = resultResponse["data"]["latestArticleList"]
                    $scope.latestArticleList = articleList.slice(1);

                    appRootService.PrintLogMessage("normalPost", "getNormalPosts", "normal article list: " + JSON.stringify($scope.latestArticleList), LOG_LEVEL_DEBUG);
                },
                function (error) {
                    appRootService.PrintLogMessage("normalPost", "getNormalPosts", "failed to get response: " + error, LOG_LEVEL_ERROR);
                })
        }
    })