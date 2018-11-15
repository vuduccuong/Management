/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.cars', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('cars', {
            parent: 'base',
            url: "/cars",
            templateUrl: "/app/components/cars/carListView.html",
            controller: "carListController"
        })
            .state('add_car', {
                parent: 'base',
                url: "/add_car",
                templateUrl: "/app/components/cars/carAddView.html",
                controller: "carAddController"
            })
            .state('edit_car', {
                parent: 'base',
                url: "/edit_car/:id",
                templateUrl: "/app/components/cars/carEditView.html",
                controller: "carEditController"
            });
    }
})();