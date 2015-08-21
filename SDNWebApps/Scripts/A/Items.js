var ItemApp = angular.module('ItemApp', []);


ItemApp.controller('ItemController', function ($scope, ItemService) {

    getItems();
    function getItems() {
        ItemService.getItems()
            .success(function (studs) {
                $scope.items = studs;
                console.log($scope.items);
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                console.log($scope.status);
            });
    }
});


ItemApp.factory('ItemService', ['$http', function ($http) {

    var ItemService = {};
    ItemService.getItems = function () {
        return $http.get('/GroceryList/Home/GetItems');
    };
    return ItemService;

}]);
