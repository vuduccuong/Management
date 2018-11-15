(function (app) {
    app.controller('carAddController', carAddController);

    carAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','authData'];

    function carAddController(apiService, $scope, notificationService, $state, authData) {
        var userName = authData.authenticationData.userName;
        $scope.car = {
            CreatedBy : userName,
            Status: true,
        };

        $scope.AddCar = AddCar;
        var historyAction = {
            "ActionName" : "Thêm mới xe",
            "Status": 1,
            "UserName": userName,
        };

        function AddCar() {
            apiService.post('api/car/create', $scope.car,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('cars');
                }, function (error) {
                    historyAction["Status"] = 0;
                    notificationService.displayError('Thêm mới không thành công.');
                });
            debugger;
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

        //Load tất cả loại xe
        function loadTypeCars() {
            apiService.get('api/car/getalltypecars', null, function (result) {
                $scope.typeCars = result.data;
            }, function () {
                console.log('Không load được loại xe');
            });
        }

        //load tất cả tài xế
        function loadDrivers() {
            var keyword = '';
            var config = {
                params: {
                    keyword
                }
            };
            apiService.get('api/driver/getall', config, function (result) {
                $scope.drivers = result.data;
            }, function () {
                console.log('Không load được danh sách tài xế');
            });
        }

        //Load tất cả lộ trình
        function loadRoutes() {
            var keyword = '';
            var config = {
                params: {
                    keyword
                }
            };
            apiService.get('api/route/getall', config, function (result) {
                $scope.routes = result.data;
            }, function () {
                console.log("Không load được lộ trình nào!");
            });
        }
        loadTypeCars();
        loadDrivers();
        loadRoutes();
    }
})(angular.module('management.cars'));