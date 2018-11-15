(function (app) {
    app.controller('historyActionListController', historyActionListController);

    historyActionListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function historyActionListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.cars = [];
        $scope.getHistoryActions = getHistoryActions;
        $scope.keyword = '';

        $scope.search = search;

        function search() {
            getcars();
        }
        function getHistoryActions() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/historyaction/getall', config, function (result) {
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.history_actions = result.data;
            }, function () {
                console.log('Lỗi load lịch sử tác động.');
            });
        }

        $scope.getHistoryActions();
    }
})(angular.module('management.history_actions'));