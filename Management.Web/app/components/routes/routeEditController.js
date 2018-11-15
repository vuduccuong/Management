(function (app) {
    app.controller('routeEditController', routeEditController);

    routeEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService','authData'];

    function routeEditController(apiService, $scope, notificationService, $state, $stateParams, commonService, authData) {
        var userName = authData.authenticationData.userName;
        

        $scope.Updateroute = Updateroute;

        var historyAction = {
            "ActionName": "Cập nhật lộ trình",
            "Status": 1,
            "UserName": authData.authenticationData.userName,
        };

        function loadrouteDetail() {
            apiService.get('api/route/getbyid/' + $stateParams.id, null, function (result) {
                $scope.route = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updateroute() {
            $scope.route["UpdatedBy"] = userName;
            apiService.put('api/route/update', $scope.route,
                function (result) {
                    notificationService.displaySuccess('Cập nhật lộ trình thành công.');
                    $state.go('routes');
                }, function (error) {
                    historyAction["Status"] = 0;
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

        loadrouteDetail();
    }
})(angular.module('management.routes'));