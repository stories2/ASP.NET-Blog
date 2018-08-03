angular.module("pageManager", ['appRoot'])
    .controller("PageManagerController", function ($scope, appRootService) {
        $scope.initPageNavigation = function (pageNum, pageStartPoint, pageNavigationSize) {
            appRootService.PrintLogMessage("pageManager", "initPageNavigation", "can u see me?", LOG_LEVEL_INFO)
            $scope.maxNaviPage = (pageNum < pageStartPoint + pageNavigationSize ? pageNum : pageStartPoint + pageNavigationSize)
        }
        $scope.range = function (min, max, step) {
            step = step || 1;
            var input = [];
            for (var i = min; i <= max; i += step) {
                input.push(i);
            }
            return input;
        };
    })
    .config(function ($logProvider) {
        $logProvider.debugEnabled(true);
    })