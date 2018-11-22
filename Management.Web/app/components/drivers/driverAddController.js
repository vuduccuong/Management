(function (app) {
    app.controller('driverAddController', driverAddController);

    driverAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','authData'];

    function driverAddController(apiService, $scope, notificationService, $state, authData) {
        var userName = authData.authenticationData.userName;
        $scope.driver = {
            CreatedBy: userName,
        }
        $scope.AddDriver = AddDriver;

        var historyAction = {
            "ActionName": "Thêm mới tài xế",
            "Status": true,
            "UserName": userName,
        };

        function AddDriver() {
            apiService.post('api/driver/create', $scope.driver,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('drivers');
                }, function (error) {
                    historyAction["Status"] = false;
                    notificationService.displayError('Thêm mới không thành công.');
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
    }
})(angular.module('management.drivers'));