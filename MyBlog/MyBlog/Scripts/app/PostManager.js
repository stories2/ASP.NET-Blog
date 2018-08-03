angular.module("postManager", ['appRoot'])
    .controller("getSelectedPostDetail", function ($scope, appRootService) {
        $scope.getSelectedPostDetailFromServer = function (articleID) {
            
            articleInfo = {
                "articleID": articleID
            }
            appRootService.PrintLogMessage("postManager", "getSelectedPostDetail", "get article info: " + JSON.stringify(articleInfo), LOG_LEVEL_DEBUG)

            appRootService.GetReqCallback(
                API_GET_SHOW_SELECTED_ARTICLE,
                articleInfo,
                function (resultResponse) {
                    appRootService.PrintLogMessage("postManager", "getSelectedPostDetail", "response accepted: " + JSON.stringify(resultResponse), LOG_LEVEL_DEBUG)
                    articleInfoData = resultResponse["data"]["article"]

                    $scope.articleInfoData = articleInfoData
                },
                function (error) {
                    appRootService.PrintLogMessage("postManager", "getSelectedPostDetail", "error accrued: " + error, LOG_LEVEL_ERROR)
                }, undefined)
        }
    })
    .config(function ($logProvider) {
        $logProvider.debugEnabled(true);
    })