angular.module("createPost", ['appRoot'])
    .controller("uploadNewPost", function ($scope, $timeout, appRootService) {

        $scope.title = ''
        $scope.highlightText = ''
        $scope.imgUrl = ''
        $scope.articleContent = ''
        $scope.token = ''

        $scope.uploadNewPost = function () {

            $scope.token = $("#clientToken").val()

            appRootService.PrintLogMessage("createPost", "uploadNewPost", "form data-> title: " + $scope.title + " highlightText: " + 
                $scope.highlightText + " imgUrl: " + $scope.imgUrl + " articleContent: " + $scope.articleContent, LOG_LEVEL_DEBUG)

            appRootService.PrintLogMessage("createPost", "uploadNewPost", "check token val: " + $scope.token, LOG_LEVEL_DEBUG)

            newArticleInfo = {
                "title": $scope.title,
                "highlightText": $scope.highlightText,
                "imgUrl": $scope.imgUrl,
                "articleContent": $scope.articleContent,
                "clientToken": $scope.token
            }

            appRootService.PrintLogMessage("createPost", "uploadNewPost", "new article info: " + JSON.stringify(newArticleInfo), LOG_LEVEL_DEBUG)

            appRootService.PostReqCallback(
                API_POST_UPLOAD_NEW_ARTICLE,
                newArticleInfo,
                function (responseResult) {
                    appRootService.PrintLogMessage("createPost", "uploadNewPost", "upload success: " + JSON.stringify(responseResult), LOG_LEVEL_DEBUG)
                    resultMsg = responseResult["data"]["result"]
                    alert(resultMsg)
                    location.href="/Blog/Index"
                },
                function (error) {
                    appRootService.PrintLogMessage("createPost", "uploadNewPost", "failed to upload: " + error, LOG_LEVEL_ERROR) 
                }, undefined)
        }

        $scope.tokenGenerated = function ($event) {
            $scope.token = $event.target.value
            appRootService.PrintLogMessage("createPost", "tokenGenerated", "token val changed: " + $scope.token, LOG_LEVEL_DEBUG)
        }

        //$scope.$watch('token', function (newValue, oldValue) {
        //    // ...
        //    appRootService.PrintLogMessage("createPost", "watchToken", "token val change watcher -> new: " + newValue + " old: " + oldValue, LOG_LEVEL_DEBUG)
        //});

        $timeout(function () {
            $scope.$watch('token', function (newValue, oldValue) {
                // ...
                appRootService.PrintLogMessage("createPost", "watchToken", "token val change watcher -> new: " + newValue + " old: " + oldValue, LOG_LEVEL_DEBUG)
            });
        }, 1000, true)
    })