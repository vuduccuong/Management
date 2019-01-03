(function (app) {
    app.controller('dashboadListController', dashboadListController);

    dashboadListController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$ngBootbox', 'authData'];

    function dashboadListController(apiService, $scope, notificationService, $state, $ngBootbox, authData) {

        
    }
})(angular.module('management.dashboads'));