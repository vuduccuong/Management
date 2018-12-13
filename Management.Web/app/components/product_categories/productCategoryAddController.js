(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function productCategoryAddController(apiService, $scope, notificationService, $state) {
        
    }
})(angular.module('management.product_categories'));