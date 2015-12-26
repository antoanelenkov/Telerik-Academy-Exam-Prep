(function () {
    'use strict';

    function projects() {
        return {
            restrict:'A',
            templateUrl: 'views/directives/projects-directive.html',
        }
    }

    angular.module('myApp.directives')
        .directive('projects', [projects]);
}());