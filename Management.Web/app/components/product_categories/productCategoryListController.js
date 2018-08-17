(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.getProductCagories = getProductCagories;
        $scope.keyword = '';

        $scope.search = search;

        function search() {
            getProductCagories();
        }
        function getProductCagories() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                console.log(result.data);
                for (var i = 0; i < result.data.length; i++) {
                    result.data[i].CreatedDate = 0;
                }
                $scope.productCategories = result.data;

            }, function () {
                console.log('Load productcategory failed.');
            });
        }

        $scope.getProductCagories();
    }
})(angular.module('management.product_categories'));