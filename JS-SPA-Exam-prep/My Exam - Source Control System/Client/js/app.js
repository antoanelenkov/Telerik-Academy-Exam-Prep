(function () {
    'use strict';
    var PARTIALS_FOLDER = 'views/partials/';
    var CONTROLLER_AS_VIEW_MODEL = 'vm';

    function config($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: PARTIALS_FOLDER + 'identity/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/', {
                templateUrl: PARTIALS_FOLDER + 'home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/projects', {
                templateUrl: PARTIALS_FOLDER + 'projects/projects-public.html',
                controller: 'ProjectsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/projects/add', {
                templateUrl: PARTIALS_FOLDER + 'projects/projects-private.html',
                controller: 'CreateProjectsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/projects/:id', {
                templateUrl: PARTIALS_FOLDER + 'projects/project-details.html',
                controller: 'ProjectDetailsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/projects/:id/addcommits', {
                templateUrl: PARTIALS_FOLDER + 'commits/commits-add.html',
                controller: 'CreateCommitController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/commits/:id', {
                templateUrl: PARTIALS_FOLDER + 'commits/commit-details.html',
                controller: 'CommitDetailsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/unauthorized', {
                template: '<h1 class="text-center">You are not authorized!</h1>'
            })
            .otherwise({ redirectTo: '/' });
    };

    angular.module('myApp.services', []);
    angular.module('myApp.filters', []);
    angular.module('myApp.directives', []);
    angular.module('myApp.controllers', ['myApp.services', 'myApp.directives']);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'myApp.controllers', 'myApp.filters']).
        config(['$routeProvider', config])
        .value('toastr', toastr)
        .constant('baseServiceUrl', 'http://spa.bgcoder.com');
}());