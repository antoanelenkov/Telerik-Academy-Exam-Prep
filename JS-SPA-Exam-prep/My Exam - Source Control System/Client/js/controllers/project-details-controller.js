(function () {
    'use strict';

    function ProjectDetailsController($window, $routeParams, projects, identity, commits, collaborators) {
        var vm = this;
        vm.isAuthenticated = identity.isAuthenticated();
        vm.currentLocation = $window.location.href;

        if (!vm.isAuthenticated) {
            $window.location.href = '#/unauthorized';

            return;
        }

        vm.identity = identity;

        projects.getProjectDetails($routeParams.id)
            .then(function (res) {
                vm.project = res;
            });

        vm.addCollaborator = function (collaborator) {
            projects.addCollaborator($routeParams.id, collaborator)
          .then(function (res) {
              vm.project = res;
          });
        }

        commits.getProjectCommits($routeParams.id)
            .then(function (res) {
                vm.commits = res;
            });

        collaborators.getAllCollaborators($routeParams.id)
            .then(function (res) {
                vm.collaborators = res;
                vm.isCollaborator = isCollaborator(vm.collaborators);
            });

        function isCollaborator(collaborators) {
            debugger;
            for (var i = 0; i < collaborators.length; i++) {
                if (collaborators[i] === identity.getCurrentUser().userName) {
                    return true;
                }
            }

            return false;
        }

    }

    angular.module('myApp.controllers')
    .controller('ProjectDetailsController', ['$window', '$routeParams', 'projects', 'identity', 'commits', 'collaborators', ProjectDetailsController]);
}());