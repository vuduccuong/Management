(function (app) {
    app.controller('routeListController', routeListController);

    routeListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','authData'];

    function routeListController($scope, apiService, notificationService, $ngBootbox, authData) {
        $scope.routes = [];
        $scope.getroutes = getroutes;
        $scope.keyword = '';

        $scope.search = search;

        $scope.deleteroute = deleteroute;

        var historyAction = {
            "ActionName": "Xoá lộ trình",
            "Status": 1,
            "UserName": authData.authenticationData.userName,
        };

        function deleteroute(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/route/delete', config, function () {
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
            getroutes();
        }
        function getroutes() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/route/getall', config, function (result) {
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.routes = result.data;
            }, function () {
                console.log('Load route failed.');
            });
        }

        $scope.getroutes();
    }
})(angular.module('management.routes'));