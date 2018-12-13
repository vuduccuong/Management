(function (app) {
    app.controller('billListController', billListController);

    billListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function billListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.bills = [];
        $scope.getBills = getBills;
        $scope.keyword = '';

        $scope.search = search;

        function search() {
            getBills();
        }
        function getBills() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/booking/getallbill', config, function (result) {
                console.log(result.data);
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.bills = result.data;
            }, function () {
                console.log('Lỗi load lịch sử tác động.');
            });
        }

        $scope.getBills();
    }
})(angular.module('management.bills'));