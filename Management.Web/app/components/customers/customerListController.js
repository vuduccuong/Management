(function (app) {
    app.controller('customerListController', customerListController);

    customerListController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$ngBootbox', 'authData'];

    function customerListController(apiService, $scope, notificationService, $state, $ngBootbox, authData) {
        var userName = authData.authenticationData.userName;
        $scope.customers = [];
        $scope.books = [];
        $scope.keyword = '';
        $scope.getCustomer = getCustomer;
        $scope.search = search;
        $scope.deletecustomer = deletecustomer;

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
                };
                apiService.get('api/booking/getall', config, function (result) {
                    debugger;
                    var idSeatNo = result.data[0].IDSeatNo;
                    var IDBook = result.data[0].ID;
                    

                    //Xoá khách hàng
                    apiService.del('api/customer/delete', config, function (result) {
                        debugger;
                        console.log("Xoá customer thành công");
                        //Cập nhật lại status
                        apiService.post('api/seat/updatestatus?idSeatNo='+idSeatNo,null, function () {
                            debugger;
                            console.log("Update Status thành công");
                            apiService.del('api/booking/delete?id=' + IDBook, null, function () {
                                console.log("xoá book thành công");
                                notificationService.displaySuccess('Xóa thành công');
                                search();
                            }, function () {
                                console.log("Update không thành công");
                            })
                            
                        }, function () {
                            console.log("Update không thành công")
                        });
                        
                    }, function () {
                        historyAction["Status"] = 0;
                        notificationService.displayError('Xóa không thành công');
                    });
                }, function () {
                    console.log("ádsad");
                })

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
            apiService.get('api/customer/getall', config, function (result) {
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