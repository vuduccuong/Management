(function (app) {
    'use strict';

    app.controller('applicationUserListController', applicationUserListController);

    applicationUserListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function applicationUserListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.data = [];

        $scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.deleteItem = deleteItem;

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/applicationUser/delete', config, function () {
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công.');
                    });
                });
        }
        function search() {

            $scope.loading = true;
            apiService.get('api/applicationUser/getlistall', null, function (result) {
                $scope.loading = false;
                console.log(result);
                $scope.data = result.data;
            }, function () {
                console.log("Không load được User nào");
                });
        }

        function clearSearch() {
            $scope.filterExpression = '';
            search();
        }

        $scope.search();
    }
})(angular.module('management.application_users'));