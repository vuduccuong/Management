(function (app) {
    app.controller('customerEditController', customerEditController);

    customerEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService', 'authData'];

    function customerEditController(apiService, $scope, notificationService, $state, $stateParams, commonService, authData) {
        var userName = authData.authenticationData.userName;
        $scope.cars = [];
        $scope.rows = [];
        $scope.status = [];
        $scope.routes = [];
        $scope.customer = [];
        $scope.LoadStatus = LoadStatus;
        $scope.GetStatus = GetStatus;
        $scope.ShowCar = ShowCar;
        $scope.LoadSeatNo = LoadSeatNo;
        $scope.LoadSeat = LoadSeat;
        $scope.UpdateCustomer = UpdateCustomer;
        var IDSeat;
        var IDSeatNo;
        var time;
        var IDCar;
        var IDBook;
        var oldIDSeatNo;

        function LoadCustomerByID() {
            apiService.get('api/booking/getall?id=' + $stateParams.id, null, function (result) {
                debugger;
                var IDcustomer = result.data[0].ID;
                apiService.get('api/customer/getbyid/' + IDcustomer, null, function (result) {
                    debugger;
                    $scope.customer = result.data[0];
                    IDSeat = result.data[0].IDSeat;
                    IDSeatNo = result.data[0].IDSeatNo;
                    oldIDSeatNo = result.data[0].IDSeatNo;
                    time = result.data[0].DateBook;
                    IDCar = result.data[0].IDCar;
                    IDBook = result.data[0].IDBook;
                    LoadSeat();
                    LoadSeatNo();
                        console.log($scope.customer);
                    console.log("ID SEAT : " + IDSeat);
                    
                    console.log("IDSEATNO : " + IDSeatNo);
                },
                    function () {
                    })

            }, function () {
                console.log("Không load được dữ liệu");
                })
        }

        function LoadSeat() {
            apiService.get('api/seat/getseatbycar?id=' + IDCar, null, function (result) {
                console.log(result.data);
                debugger;
                $scope.rows = result.data;
            }, function () { })
        }

        function LoadSeatNo() {
            apiService.get('api/seat/getseatnobyseat?id=' + IDSeat + '&dateBook=' + time, null, function(result) {
                console.log("Danh sách vị trí ghế theo IDSeat : ", result.data);
                $scope.status = result.data;
            }, function() { })
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
            var datecustomer = $('#datepicker-autoclose').val();
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
            if (datecustomer == "" || datecustomer == null) {
                notificationService.displayError("Chưa chọn ngày đi");
                a = false;
            }
            if (datecustomer == "" || datecustomer == null) {
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
                debugger;
                console.log(result.data);
                $scope.routes = result.data;
            }, function () {
                console.log("Không load được lộ trình nào!");
            });
        }

        function LOadAllCars(){
            apiService.get('/api/car/getall', null, function (result) {
                console.log(result.data);
                $scope.cars = result.data;
                if (result.data = null || result.data == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
            }, function () {
                console.log('Lỗi load danh sách xe.');
            });
        };

        function ShowCar() {

            var id = $scope.customer.IDRoute;
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
        //Load danh sách xe theo ID Ruter and Time Start
        //LoadStatus
        
        function LoadStatus() {
            debugger;
            var id = $scope.customer.IDCar;
            var config = {
                param: {
                    idSeat: id,
                }
            };
            
            apiService.get('/api/car/getrowbycar?id=' + config.param.idSeat, null, function (result) {
                $scope.rows = result.data;
                if (result.data = null || result.data == 0) {
                    //notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
            }, function () {
                console.log('Lỗi load danh sách xe.');
            });
        }

        function GetStatus() {
            var id = $scope.customer.IDSeat;
            var config = {
                param: {
                    idSeat: id,
                    dateBook: '12/02/2018'
                }
            };
            apiService.get('/api/car/getstatusbyrow?id=' + config.param.idSeat + '&dateBook=' + config.param.dateBook, null, function (result) {
                console.log("dah sách seatNo : " +result.data);
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

        //Cập nhật khách hàng
        var historyAction = {
            "ActionName": "Cập nhật hành khách",
            "Status": 1,
            "UserName": userName,
        };
        
        function UpdateCustomer() {
            $scope.customer["UpdatedBy"] = userName;
            $scope.customer["IDBook"] = IDBook;
            $scope.customer["oldIDSeatNo"] = oldIDSeatNo;
            alert(oldIDSeatNo);
            alert(IDSeatNo);
            apiService.put('api/customer/update', $scope.customer,
                function(result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('customers');
                }, function(error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
            apiService.post('api/historyaction/create', JSON.stringify(historyAction),
                function() {
                    console.log("Lưu lịch sử thành công");
                },
                function() {
                    console.log("Không lưu lịch sử thành công");
                }
            )
        }

        loadRoutes();
        LoadCustomerByID();
        LOadAllCars();
    }
})(angular.module('management.cars'));