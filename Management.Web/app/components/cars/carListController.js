(function (app) {
    app.controller('carListController', carListController);

    carListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','authData'];

    function carListController($scope, apiService, notificationService, $ngBootbox, authData) {
        $scope.cars = [];
        $scope.getcars = getcars;
        $scope.keyword = '';

        $scope.search = search;

        $scope.deletecar = deletecar;

        var historyAction = {
            "ActionName": "Xoá xe",
            "Status": 1,
            "UserName": authData.authenticationData.userName,
        };

        function deletecar(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/car/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    historyAction["Status"] = 0;
                    notificationService.displayError('Xóa không thành công');
                    }
                )
            });
            apiService.post('api/historyaction/create', JSON.stringify(historyAction),
                function () {
                    debugger;
                    console.log("Lưu lịch sử thành công");
                },
                function () {
                    console.log("Không lưu lịch sử thành công");
                }
            )
        }

        function search() {
            getcars();
        }
        function getcars() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/car/getall', config, function (result) {
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                for (var i = 0; i < result.data.length; i++) {
                    result.data[i].CreatedDate = 0;
                }
                $scope.cars = result.data;
            }, function () {
                console.log('Lỗi load danh sách xe.');
            });
        }

        $scope.getcars();
    }
})(angular.module('management.cars'));