(function () {
    'use strict';

    function CreateProjectsController($scope, $window, projects, licenses, notifier, identity) {
        var vm = this;
        vm.isAuthenticated = identity.isAuthenticated();

        if (!vm.isAuthenticated) {
            $window.location.href = '#/unauthorized';

            return;
        }

        licenses.getAllLicenses()
        .then(function (res) {
            vm.licenses = res;
        });

        vm.createProject = function (project) {
            project.licenseId = $scope.license.Id * 1;

            if (!project.private) {
                project.private = false;
            }

            projects.createProject(project)
                .then(function (res) {
                    notifier.success('You successfully created project!');
                    $window.location.href = '#/';
                })
        }
    }

    angular.module('myApp.controllers')
    .controller('CreateProjectsController', ['$scope', '$window', 'projects', 'licenses', 'notifier', 'identity', CreateProjectsController]);
}());