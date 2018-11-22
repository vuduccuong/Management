(function (app) {
    app.controller('seatEditController', seatEditController);

    seatEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function seatEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {

    }
})(angular.module('management.seats'));