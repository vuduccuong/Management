(function (app) {
    app.controller('seatCarController', seatCarController);

    seatCarController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', 'authData'];

    function seatCarController($scope, apiService, notificationService, $ngBootbox, authData) {

    }
})(angular.module('management.seats'));