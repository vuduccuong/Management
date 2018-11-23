(function (app) {
    app.controller('driverListController', driverListController);

    driverListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','authData'];

    function driverListController($scope, apiService, notificationService, $ngBootbox, authData) {
        $scope.drivers = [];
        $scope.getdrivers = getdrivers;
        $scope.keyword = '';

        $scope.search = search;

        $scope.deletedriver = deletedriver;

        var historyAction = {
            "ActionName": "Xoá tài xế",
            "Status": 1,
            "UserName": authData.authenticationData.userName,
        };

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
                    historyAction["Status"] = 0;
                    notificationService.displayError('Xóa không thành công');
                })
            });
            apiService.post('api/historyaction/create', JSON.stringify(historyAction),
                function () {
                    console.log("Lưu lịch sử thành công");
                },
                function () {
                    console.log("Không lưu lịch sử thành công");
                }
            )
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