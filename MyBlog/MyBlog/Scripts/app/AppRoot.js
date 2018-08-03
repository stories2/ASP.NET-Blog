angular.module("appRoot", [])
        .controller('testController', function ($scope, $log, appRootService) {
            appRootService.PrintLogMessage("appRoot", "testController", "say, " + appRootService.SayMsg('Hello'), LOG_LEVEL_DEBUG)
        })
        .config(function ($logProvider) {
            $logProvider.debugEnabled(true);
        })

$(document).ready(function () {
    //bootstrapTargetAppRoot = $("#footer")    

    //angular.bootstrap(bootstrapTargetAppRoot, [
    //    'appRoot'
    //])

    bootstrapTargetMain = $("#main")

    angular.bootstrap(bootstrapTargetMain, [
        'featurePost', 'normalPost', 'pageManager',
        'postManager', 'createPost'
    ])
})

