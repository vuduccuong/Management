/// <reference path="../../../scripts/angular.js" />

(function () {
    angular.module('management.posts', ['management.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('posts', {
            parent: 'base',
            url: "/posts",
            templateUrl: "/app/components/posts/postListView.html",
            controller: "postListController"
        })
            .state('add_post', {
                parent: 'base',
                url: "/add_post",
                templateUrl: "/app/components/posts/postAddView.html",
                controller: "postAddController"
            })
            .state('edit_post', {
                parent: 'base',
                url: "/edit_post/:id",
                templateUrl: "/app/components/posts/postEditView.html",
                controller: "postEditController"
            });
    }
})();