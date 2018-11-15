(function (app) {
    app.controller('driverEditController', driverEditController);

    driverEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService','authData'];

    function driverEditController(apiService, $scope, notificationService, $state, $stateParams, commonService, authData) {
        var userName = authData.authenticationData.userName;
        

        $scope.Updatedriver = Updatedriver;

        var historyAction = {
            "ActionName": "Cập nhật tài xế",
            "Status": 1,
            "UserName": userName,
        };

        function loaddriverDetail() {
            apiService.get('api/driver/getbyid/' + $stateParams.id, null, function (result) {
                $scope.driver = result.data;
            }, function (error) {
                historyAction["Status"] = 0;
                notificationService.displayError(error.data);
            });
        }

        function Updatedriver() {
            $scope.driver["UpdatedBy"] = userName;
            apiService.put('api/driver/update', $scope.driver,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('drivers');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
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

        loaddriverDetail();
    }
})(angular.module('management.drivers'));