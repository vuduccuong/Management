(function (app) {
    app.controller('routeAddController', routeAddController);

    routeAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','authData'];

    function routeAddController(apiService, $scope, notificationService, $state, authData) {
        var userName = authData.authenticationData.userName;
        $scope.route = {
            CreatedBy: userName,
            Status: true,
        };

        $scope.AddRoute = AddRoute;

        var historyAction = {
            "ActionName": "Thêm mới lộ trình",
            "Status": 1,
            "UserName": authData.authenticationData.userName,
        };

        function AddRoute() {
            apiService.post('api/route/create', $scope.route,
                function (result) {
                    notificationService.displaySuccess('Thêm mới thành công.');
                    $state.go('routes');
                }, function (error) {
                    historyAction["Status"] = 0;
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
})(angular.module('management.routes'));