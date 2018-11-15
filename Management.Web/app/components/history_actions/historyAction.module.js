/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.history_actions', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('history_actions', {
            parent: 'base',
            url: "/history_actions",
            templateUrl: "/app/components/history_actions/historyActionListView.html",
            controller: "historyActionListController"
        });
    }
})();