angular.module("appRoot", [])
        .controller('testController', function ($scope, $log, appRootService) {
            //$scope.greeting = appRootService.sayMsg('hello')
            $log.debug("say, " + appRootService.sayMsg('hello'));
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
        'featurePost'
        ])
})

