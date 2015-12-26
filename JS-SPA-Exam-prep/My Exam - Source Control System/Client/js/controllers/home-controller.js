(function () {
    'use strict';

    function HomeController(statistics, projects, commits) {
        var vm = this;

        vm.home = 'home';

        statistics.getStats()
            .then(function (res) {
                vm.stats = res;
            });

        projects.getPublicProjects()
            .then(function (res) {
                vm.projects = res;
            });

        commits.getPublicCommits()
    .then(function (res) {
        vm.commits = res;
    });
    }

    angular.module('myApp.controllers')
    .controller('HomeController', ['statistics', 'projects', 'commits', HomeController]);
}());