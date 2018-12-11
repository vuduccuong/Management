(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        
    }
})(angular.module('management.product_categories'));