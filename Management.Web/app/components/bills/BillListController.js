(function (app) {
    app.controller('billListController', billListController);

    billListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function billListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.bills = [];
        $scope.getBills = getBills; //get list
        $scope.keyword = '';

        $scope.search = search; //search

        $scope.SentMail = SentMail; // sent mail

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

        function SentMail(item) {
            apiService.post('api/booking/sentmail', JSON.stringify(item), function (result) {
                debugger;
                notificationService.displaySuccess(result.data.Name + ' đã đặt vé thành công!');
                
            }, function (error) {
                notificationService.displayError('Có lỗi khi gửi mail thành công.');
            });
        }

        $scope.getBills();
    }
})(angular.module('management.bills'));