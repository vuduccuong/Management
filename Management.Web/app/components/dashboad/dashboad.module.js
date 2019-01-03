/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.dashboads', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('dashboads', {
            parent: 'base',
            url: "/dashboads",
            templateUrl: "/app/components/dashboad/dashboadListView.html",
            controller: "dashboadListController"
        });
    }
})();