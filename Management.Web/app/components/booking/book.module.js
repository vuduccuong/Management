/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.booking', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('booking', {
            parent: 'base',
            url: "/booking",
            templateUrl: "/app/components/booking/bookAddView.html",
            controller: "bookAddController"
        });
    }
})();