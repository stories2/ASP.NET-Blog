angular.module("appRoot", [])
    .controller('testController', ['$scope', function($scope) {
        $scope.greeting = 'Hello';
    }]);