(function (app) {
    app.controller('bookAddController', bookAddController);

    bookAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'authData'];

    function bookAddController(apiService, $scope, notificationService, $state, authData) {
        var userName = authData.authenticationData.userName;
        $scope.ShowCar = ShowCar;
        $scope.Booking = Booking;
        $scope.LoadStatus = LoadStatus;
        $scope.GetStatus = GetStatus;

        $scope.cars = [];
        $scope.rows = [];
        $scope.status = [];
        function ShowCar() {
            
            var id = $scope.book.IDRoute;
            var timeStart = $('#time').val();
            console.log(timeStart);
            var config = {
                param: {
                    idSeat : id,
                    startTime : timeStart
                }
            };
            apiService.get('/api/car/getallbyroute?id=' + config.param.idSeat + '&timeStart=' + config.param.startTime , null, function (result) {
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
            return a;
        }


        function Booking() {
            CkeckData()
            if (a) {
                notificationService.displayError("Nhập Tên hành khásdsadsach");
            }
            else {

            }
            
        }

        

        //Load route
        //Load tất cả lộ trình
        function loadRoutes() {
            var keyword = '';
            var config = {
                params: {
                    keyword
                }
            };
            apiService.get('api/route/getall', config, function (result) {
                console.log(result.data);
                $scope.routes = result.data;
            }, function () {
                console.log("Không load được lộ trình nào!");
            });
        }

        //Load danh sách xe theo ID Ruter and Time Start

        //LoadStatus

        function LoadStatus() {
            var id = $scope.book.IDCar;
            var config = {
                param: {
                    idSeat: id,
                }
            };
            apiService.get('/api/car/getrowbycar?id=' + config.param.idSeat , null, function (result) {
                $scope.rows = result.data;
                if (result.data = null || result.data == 0) {
                    //notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
            }, function () {
                console.log('Lỗi load danh sách xe.');
            });
        }

        function GetStatus() {
            var id = $scope.book.IDSeat;
            var config = {
                param: {
                    idSeat: id,
                    dateBook :'11/28/2018'
                }
            };
            apiService.get('/api/car/getstatusbyrow?id=' + config.param.idSeat + '&dateBook=' + config.param.dateBook, null, function (result) {
                for (var i = 0; i < result.data.length; i++) {
                    if (result.data[i].Status == false) {
                        console.log(result.data[i]);
                        $scope.status.push(result.data[i]);
                        
                    }

                }
                if (result.data = null || result.data == 0) {
                    //notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
            }, function () {
                console.log('Lỗi load danh sách xe.');
            });
        }

        loadRoutes();
    }
})(angular.module('management.booking'));