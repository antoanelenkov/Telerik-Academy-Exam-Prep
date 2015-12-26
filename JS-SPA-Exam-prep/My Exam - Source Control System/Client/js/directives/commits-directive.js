(function () {
    'use strict';

    function commits() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/commits-directive.html',
        }
    }

    angular.module('myApp.directives')
        .directive('commits', [commits]);
}());