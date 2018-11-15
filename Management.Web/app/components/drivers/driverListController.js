(function (app) {
    app.controller('driverListController', driverListController);

    driverListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function driverListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.drivers = [];
        $scope.getdrivers = getdrivers;
        $scope.keyword = '';

        $scope.search = search;

        $scope.deletedriver = deletedriver;

        function deletedriver(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/driver/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search() {
            getdrivers();
        }
        function getdrivers() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/driver/getall', config, function (result) {
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                for (var i = 0; i < result.data.length; i++) {
                    result.data[i].CreatedDate = 0;
                }
                $scope.drivers = result.data;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }

        $scope.getdrivers();
    }
})(angular.module('management.drivers'));