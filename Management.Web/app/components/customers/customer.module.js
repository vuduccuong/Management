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
        })
            .state('edit_customer', {
                parent: 'base',
                url: "/edit_customer/:id",
                templateUrl: "/app/components/customers/customerEditView.html",
                controller: "customerEditController"
            });
    }
})();