/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.customers', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('customers', {
            parent: 'base',
            url: "/customers",
            templateUrl: "/app/components/customers/customerListView.html",
            controller: "customerListController"
        });
    }
})();