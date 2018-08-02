angular.module("appRoot", [])
    .controller('testController', function($scope, appRootService){
        $scope.greeting = appRootService.sayMsg('hello')
    })