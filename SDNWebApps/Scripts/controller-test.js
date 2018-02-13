var myApp = angular.module('myModule', []);

myApp.controller('myController', function ($scope) {
    $scope.init = function (JSONGallonsView) {
        $scope.sortType = 'GasDate';
        $scope.sortReverse = true;
        $scope.JSONGallonsView = JSONGallonsView;
    }
});