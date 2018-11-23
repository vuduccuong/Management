(function (app) {
    app.controller('carEditController', carEditController);

    carEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService','authData'];

    function carEditController(apiService, $scope, notificationService, $state, $stateParams, commonService, authData) {
        var userName = authData.authenticationData.userName;
 

        $scope.Updatecar = Updatecar;

        var historyAction = {
            "ActionName": "cập nhật xe",
            "Status": true,
            "UserName": userName,
        };

        function loadcarDetail() {
            apiService.get('api/car/getbyid/' + $stateParams.id, null, function (result) {
                $scope.car = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        };

        function Updatecar() {
            $scope.car["UpdatedBy"] = userName;
            apiService.put('api/car/update', $scope.car,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('cars');
                }, function (error) {
                    historyAction["Status"] = false;
                    notificationService.displayError('Cập nhật không thành công.');
                });

            apiService.post('api/historyaction/create', JSON.stringify(historyAction),
                function () {
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


        loadcarDetail();
    }
})(angular.module('management.cars'));