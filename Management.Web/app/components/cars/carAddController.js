(function (app) {
    app.controller('carAddController', carAddController);

    carAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function carAddController(apiService, $scope, notificationService, $state) {
        $scope.car = {
            CreatedDate: new Date(),
            Status: true,
        };

        $scope.AddCar = AddCar;

        function AddCar() {
            apiService.post('api/car/create', $scope.car,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('cars');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
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