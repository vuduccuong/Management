/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.routes', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('routes', {
            parent: 'base',
            url: "/routes",
            templateUrl: "/app/components/routes/routeListView.html",
            controller: "routeListController"
        })
            .state('add_route', {
                parent: 'base',
                url: "/add_route",
                templateUrl: "/app/components/routes/routeAddView.html",
                controller: "routeAddController"
            })
            .state('edit_route', {
                parent: 'base',
                url: "/edit_route/:id",
                templateUrl: "/app/components/routes/routeEditView.html",
                controller: "routeEditController"
            });
    }
})();