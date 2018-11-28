(function (app) {
    app.controller('customerListController', customerListController);

    customerListController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'authData'];

    function customerListController(apiService, $scope, notificationService, $state, authData) {
        var userName = authData.authenticationData.userName;
        $scope.customers = [];
        $scope.keyword = '';
        $scope.getCustomer = getCustomer;
        $scope.search = search;

        var historyAction = {
            "ActionName": "Xoá tài xế",
            "Status": 1,
            "UserName": userName,
        };

        function deletecustomer(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                //Xoá khách hàng
                apiService.del('api/customer/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    historyAction["Status"] = 0;
                    notificationService.displayError('Xóa không thành công');
                    });
            });
            
            //Lưu lịch sử tác động
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
            getCustomer();
        }
        function getCustomer() {
            var config = {
                params: {
                    keyword: $scope.keyword
                }
            };
            apiService.get('/api/customer/getall', config, function (result) {
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.customers = result.data;
            }, function () {
                console.log('Load Customer failed.');
            });
        };
        $scope.getCustomer();
    }
})(angular.module('management.customers'));