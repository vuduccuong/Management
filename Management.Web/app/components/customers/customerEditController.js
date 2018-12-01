(function (app) {
    app.controller('customerEditController', customerEditController);

    customerEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService', 'authData'];

    function customerEditController(apiService, $scope, notificationService, $state, $stateParams, commonService, authData) {
        var userName = authData.authenticationData.userName;
        $scope.customer = [];

        function LoadCustomerByID() {
            apiService.get('api/booking/getall?id=' + $stateParams.id, null, function (result) {
                debugger;
                var IDBook = result.data[0].ID;
                apiService.get('api/customer/getbyid/' + IDBook, null, function (result) {
                    debugger;
                    $scope.customer = result.data[0];
                    console.log($scope.customer);
                },
                    function () {
                    })

            }, function () {
                console.log("Không load được dữ liệu");
                })
        }

        function ShowCar() {

            var id = $scope.book.IDRoute;
            var timeStart = $('#time').val();
            console.log(timeStart);
            var config = {
                param: {
                    idSeat: id,
                    startTime: timeStart
                }
            };
            apiService.get('/api/car/getallbyroute?id=' + config.param.idSeat + '&timeStart=' + config.param.startTime, null, function (result) {
                $scope.cars = result.data;
                if (result.data = null || result.data == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
            }, function () {
                console.log('Lỗi load danh sách xe.');
            });
        }
        var a = true;
        $('#datepicker-autoclose').datepicker({
            autoclose: true,
            todayHighlight: true
        })
        function CkeckData() {
            var nameCustomer = $('#nameCustomer').val();
            var phoneCustomer = $('#phoneCustomer').val();
            var mailCustomer = $('#mailCustomer').val();

            var idRoute = $('#IDRoute').val();
            var dateBook = $('#datepicker-autoclose').val();
            var time = $('#time').val();

            var idCar = $('#IDCar').val();
            var idSeat = $('#IDSeat').val();
            var idSeatNo = $('#IDSeatNo').val();

            if (nameCustomer == "" || nameCustomer == null) {
                notificationService.displayError("Nhập tên hành khách");
                a = false;
            }
            if (phoneCustomer == "" || phoneCustomer == null) {
                notificationService.displayError("Nhập số điện thoại khách hàng");
                a = false;
            }
            if (mailCustomer == "" || mailCustomer == null) {
                notificationService.displayError("Nhập email khách hàng");
                a = false;
            }
            if (idRoute == "" || idRoute == null) {
                notificationService.displayError("Chưa chọn lộ trình");
                a = false;
            }
            if (dateBook == "" || dateBook == null) {
                notificationService.displayError("Chưa chọn ngày đi");
                a = false;
            }
            if (dateBook == "" || dateBook == null) {
                notificationService.displayError("Chưa chọn ngày đi");
                a = false;
            }
            if (time == "" || time == null) {
                notificationService.displayError("Chưa chọn thời gian đi");
                a = false;
            }
            if (idCar == "" || idCar == null) {
                notificationService.displayError("Chưa chọn xe");
                a = false;
            }
            if (idSeat == "" || idSeat == null) {
                notificationService.displayError("Chưa chọn ghế");
                a = false;
            }
            if (idSeatNo == "" || idSeatNo == null) {
                notificationService.displayError("Chưa chọn vị trí ngồi");
                a = false;
            }
            return a;
        }

        LoadCustomerByID();
    }
})(angular.module('management.cars'));