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
        
        $scope.book = {
            CreatedBy: userName,
            StatusSeatNo:true,
        };
        
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


        function Booking() {
            CkeckData()
            if (a) {
                
                console.log($scope.book);
                var historyAction = {
                    "ActionName": "Đặt vé xe",
                    "Status": 1,
                    "UserName": userName,
                };
 
                    apiService.post('api/booking/create', $scope.book,function (result) {
                            debugger;
                            notificationService.displaySuccess(result.data.Name + ' đã đặt vé thành công!');
                            $state.go('booking');
                        }, function (error) {
                            historyAction["Status"] = 0;
                            notificationService.displayError('Đặt không thành công.');
                        });
                    apiService.post('api/historyaction/create', JSON.stringify(historyAction),
                        function () {
                            debugger;
                            console.log("Lưu lịch sử thành công");
                        },
                        function () {
                            console.log("Không lưu lịch sử thành công");
                        }
                    )
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
                var arr = [];
                for (var i = 0; i < result.data.length; i++) {
                    
                    if (result.data[i].Status == false) { 
                        arr.push(result.data[i]);
                    }

                }
                $scope.status = arr;
                console.log($scope.status);
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