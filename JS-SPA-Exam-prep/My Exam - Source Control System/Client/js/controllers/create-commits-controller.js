(function () {
    'use strict';

    function CreateCommitController($routeParams, $scope, $window, commits, notifier, identity) {
        var vm = this;
        var endIndex = $window.location.href.indexOf('/addcommits');
        vm.isAuthenticated = identity.isAuthenticated();

        if (!vm.isAuthenticated) {
            $window.location.href = '#/unauthorized';

            return;
        }

        vm.createCommit = function (commit) {
            debugger;
            commit.projectId = $routeParams.id;

            commits.createCommit(commit)
                .then(function (res) {
                    notifier.success('You successfully created commit!');
                    debugger;
                    $window.location.href = $window.location.href.substring(0, endIndex);
                })
        }
    }

    angular.module('myApp.controllers')
    .controller('CreateCommitController', ['$routeParams','$scope', '$window', 'commits', 'notifier', 'identity', CreateCommitController]);
}());