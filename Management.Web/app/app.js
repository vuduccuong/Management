/// <reference path="../scripts/angular.js" />

(function () {
    angular.module('management',
        ['management.products',
            'management.product_categories',
            'management.common',
            'angularUtils.directives.dirPagination'
        ])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();