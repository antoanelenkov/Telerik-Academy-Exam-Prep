(function () {
    'use strict';

    function collaborators() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/collaborators-directive.html',
        }
    }

    angular.module('myApp.directives')
        .directive('collaborators', [collaborators]);
}());