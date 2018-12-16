/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.bills', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('bills', {
            parent: 'base',
            url: "/bills",
            templateUrl: "/app/components/bills/billListView.html",
            controller: "billListController"
        })
            .state('billconfirm', {
                parent: 'base',
                url: "/billconfirm",
                templateUrl: "/app/components/bills/billconfirmListView.html",
                controller: "billconfirmListController"
            });
    }
})();