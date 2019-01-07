(function (app) {
    app.controller('dashboadListController', dashboadListController);

    dashboadListController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$ngBootbox', 'authData'];

    function dashboadListController(apiService, $scope, notificationService, $state, $ngBootbox, authData) {
        $scope.bills = [];
        $scope.countall;
        $scope.counttrue;
        $scope.countnottrue;
        $scope.getBill = getBill;
        $scope.Export = Export;


        function getBill() {
            apiService.get('api/booking/getcount?keyword', null, function (result) {
                console.log(result.data);
                if (result.data === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                else {
                    $scope.countall = result.data.CountAll;
                    $scope.counttrue = result.data.CountWhereTrue;
                    $scope.countnottrue = result.data.CountNotTrue;
                    $scope.bills = result.data.data;
                    console.log($scope.bills);
                }
            }, function () {
                console.log('Load failed.');
            });
        };

        function Export() {
            $("#datatable").table2excel({
                // exclude CSS class
                
                name: "Hành khách",
                filename: "Báo cáo hành khách đặt vé xe" //do not include extension
            }); 
        }

        $scope.getBill();
    }
})(angular.module('management.dashboads'));