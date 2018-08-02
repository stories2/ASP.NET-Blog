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

                    $scope.latestArticleList = resultResponse["data"]["latestArticleList"]
                },
                function (error) {
                    appRootService.PrintLogMessage("normalPost", "getNormalPosts", "failed to get response: " + error, LOG_LEVEL_ERROR);
                })
        }
    })