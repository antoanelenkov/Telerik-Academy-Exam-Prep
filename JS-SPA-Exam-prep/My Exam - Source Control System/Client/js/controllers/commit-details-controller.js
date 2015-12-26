(function () {
    'use strict';

    function CommitDetailsController($window, $routeParams, commits, identity) {
        var vm = this;
        vm.isAuthenticated = identity.isAuthenticated();

        if (!vm.isAuthenticated) {
            $window.location.href = '#/unauthorized';

            return;
        }

        vm.identity = identity;

        commits.getCommitDetails($routeParams.id)
            .then(function (res) {
                vm.commit = res;
            });

    }

    angular.module('myApp.controllers')
    .controller('CommitDetailsController', ['$window','$routeParams', 'commits', 'identity', CommitDetailsController]);
}());