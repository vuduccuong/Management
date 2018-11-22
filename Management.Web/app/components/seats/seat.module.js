/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.seats', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('seats', {
            parent: 'base',
            url: "/seats",
            templateUrl: "/app/components/seats/seatListView.html",
            controller: "seatListController"
        })
            .state('add_seat', {
                parent: 'base',
                url: "/add_seat",
                templateUrl: "/app/components/seats/seatCategoryAddView.html",
                controller: "seatAddController"
            })
            .state('edit_seat', {
                parent: 'base',
                url: "/edit_seat/:id",
                templateUrl: "/app/components/seats/seatEditView.html",
                controller: "seatEditController"
            })
            .state('seat_car', {
                parent: 'base',
                url: "/seat_car/:id",
                templateUrl: "/app/components/seats/seatCarView.html",
                controller:"seatCarController"
            });
    }
})();