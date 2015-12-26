(function () {
    'use strict';

    function licenses(data) {
        function getAllLicenses() {
            return data.get('/api/licenses');
        }

        return {
            getAllLicenses: getAllLicenses
        }
    }

    angular.module('myApp.services')
        .factory('licenses', ['data', licenses]);
}());