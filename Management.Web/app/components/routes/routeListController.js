(function (app) {
    app.controller('routeListController', routeListController);

    routeListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function routeListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.routes = [];
        $scope.getroutes = getroutes;
        $scope.keyword = '';

        $scope.search = search;

        $scope.deleteroute = deleteroute;

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
                    notificationService.displayError('Xóa không thành công');
                })
            });
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
                for (var i = 0; i < result.data.length; i++) {
                    result.data[i].CreatedDate = 0;
                }
                $scope.routes = result.data;
            }, function () {
                console.log('Load route failed.');
            });
        }

        $scope.getroutes();
    }
})(angular.module('management.routes'));