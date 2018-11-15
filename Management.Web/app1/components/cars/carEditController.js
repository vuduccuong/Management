(function (app) {
    app.controller('carEditController', carEditController);

    carEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function carEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.car = {
            UpdatedDate: new Date(),
            Status: true
        };

        $scope.Updatecar = Updatecar;

        function loadcarDetail() {
            apiService.get('api/car/getbyid/' + $stateParams.id, null, function (result) {
                $scope.car = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatecar() {
            apiService.put('api/car/update', $scope.car,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('cars');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loadcarDetail();
    }

})(angular.module('management.cars'));