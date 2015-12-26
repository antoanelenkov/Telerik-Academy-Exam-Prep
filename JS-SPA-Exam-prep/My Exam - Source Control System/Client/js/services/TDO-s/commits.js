(function () {
    'use strict';

    function commits(data) {
        function getPublicCommits() {
            return data.get('/api/commits');
        }

        function getCommitDetails(id) {
            return data.get('/api/commits/' + id);
        }

        function createCommit(commit) {
            return data.post('/api/commits/', commit);
        }

        function getProjectCommits(projectId) {
            return data.get('/api/commits/byproject/' + projectId);
        }

        return {
            getCommitDetails: getCommitDetails,
            getPublicCommits: getPublicCommits,
            createCommit: createCommit,
            getProjectCommits: getProjectCommits
        }
    }

    angular.module('myApp.services')
        .factory('commits', ['data', commits]);
}());