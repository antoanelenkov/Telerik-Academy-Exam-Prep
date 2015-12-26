(function () {
    'use strict';

    function collaborators(data) {
        function getAllCollaborators(projectId) {
            return data.get('/api/projects/collaborators/' + projectId);
        }

        return {
            getAllCollaborators: getAllCollaborators
        }
    }

    angular.module('myApp.services')
        .factory('collaborators', ['data', collaborators]);
}());