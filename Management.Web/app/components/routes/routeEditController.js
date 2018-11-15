(function (app) {
    app.controller('routeEditController', routeEditController);

    routeEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function routeEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.route = {
            UpdatedDate: new Date(),
            Status: true
        };

        $scope.Updateroute = Updateroute;

        function loadrouteDetail() {
            apiService.get('api/route/getbyid/' + $stateParams.id, null, function (result) {
                $scope.route = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updateroute() {
            apiService.put('api/route/update', $scope.route,
                function (result) {
                    notificationService.displaySuccess('Cập nhật lộ trình thành công.');
                    $state.go('routes');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loadrouteDetail();
    }
})(angular.module('management.routes'));