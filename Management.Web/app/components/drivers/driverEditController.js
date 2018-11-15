(function (app) {
    app.controller('driverEditController', driverEditController);

    driverEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function driverEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.driver = {
            UpdatedDate: new Date()
        };

        $scope.Updatedriver = Updatedriver;

        function loaddriverDetail() {
            apiService.get('api/driver/getbyid/' + $stateParams.id, null, function (result) {
                $scope.driver = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatedriver() {
            apiService.put('api/driver/update', $scope.driver,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('drivers');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loaddriverDetail();
    }
})(angular.module('management.drivers'));