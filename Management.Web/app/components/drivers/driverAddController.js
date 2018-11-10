(function (app) {
    app.controller('driverAddController', driverAddController);

    driverAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function driverAddController(apiService, $scope, notificationService, $state) {
        $scope.driver = {
            CreatedDate: new Date(),
            Status: true,
        };

        $scope.AddDriver = AddDriver;

        function AddDriver() {
            apiService.post('api/driver/create', $scope.driver,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('drivers');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
    }

})(angular.module('management.drivers'));