(function (app) {
    app.controller('routeAddController', routeAddController);

    routeAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function routeAddController(apiService, $scope, notificationService, $state) {
        $scope.route = {
            CreatedDate: new Date(),
            Status: true,
        };

        $scope.AddRoute = AddRoute;

        function AddRoute() {
            apiService.post('api/route/create', $scope.route,
                function (result) {
                    notificationService.displaySuccess('Thêm mới thành công.');
                    $state.go('routes');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
    }
})(angular.module('management.routes'));