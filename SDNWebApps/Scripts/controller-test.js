var myApp = angular.module('myModule', []);

myApp.controller('myController', function ($scope) {
    $scope.init = function (Gallons) {
        $scope.sortType = 'GasDate';
        $scope.sortReverse = true;
        $scope.Gallons = Gallons;
    };
});