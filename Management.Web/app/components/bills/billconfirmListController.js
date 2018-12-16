(function (app) {
    app.controller('billconfirmListController', billconfirmListController);

    billconfirmListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function billconfirmListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.bills = [];
        $scope.getBills = getBills;
        $scope.keyword = '';

        $scope.search = search;

        function search() {
            var time = $scope.keyword;
            
            console.log(time);
            getBills();
        }
        function getBills() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/booking/getallbilltrue', config, function (result) {
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