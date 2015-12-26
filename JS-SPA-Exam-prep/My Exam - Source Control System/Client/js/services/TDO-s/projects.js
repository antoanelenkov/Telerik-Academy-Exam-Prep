(function () {
    'use strict';

    function projects(data) {
        function getPublicProjects() {
            return data.get('/api/projects');
        }

        function createProject(project) {
            return data.post('/api/projects', project);
        }

        function filter(request) {
            return data.get('/api/projects/all', request);
        }

        function getProjectDetails(id) {
            return data.get('/api/projects/' + id);
        }

        function addCollaborator(projectId, collaborator) {
            return data.put('/api/projects/' + projectId, collaborator);
        }

        return {
            getPublicProjects: getPublicProjects,
            createProject: createProject,
            getProjectDetails: getProjectDetails,
            filter: filter,
            addCollaborator: addCollaborator
        }
    }

    angular.module('myApp.services')
        .factory('projects', ['data', projects]);
}());