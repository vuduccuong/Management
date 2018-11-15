/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.drivers', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('drivers', {
            parent: 'base',
            url: "/drivers",
            templateUrl: "/app/components/drivers/driverListView.html",
            controller: "driverListController"
        })
            .state('add_driver', {
                parent: 'base',
                url: "/add_driver",
                templateUrl: "/app/components/drivers/driverAddView.html",
                controller: "driverAddController"
            })
            .state('edit_driver', {
                parent: 'base',
                url: "/edit_driver/:id",
                templateUrl: "/app/components/drivers/driverEditView.html",
                controller: "driverEditController"
            });
    }
})();