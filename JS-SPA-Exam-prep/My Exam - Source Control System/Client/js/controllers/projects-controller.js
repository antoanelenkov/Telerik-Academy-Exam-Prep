(function () {
    'use strict';

    function ProjectsController(projects, identity) {
        var vm = this;
        vm.identity = identity;

        projects.getPublicProjects()
            .then(function (res) {
                vm.projects = res;
                vm.filteredProjects = res;
            });

        vm.filter = function (request) {
            return projects.filter(request)
                .then(function (res) {
                    vm.filteredProjects = res;
                    vm.projects=res;

            });
        }
    }

    angular.module('myApp.controllers')
    .controller('ProjectsController', ['projects', 'identity', ProjectsController]);
}());