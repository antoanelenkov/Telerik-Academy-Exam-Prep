(function () {
    'use strict';

    function data(baseServiceUrl, $http, $q, notifier,authorization) {
        var authHeader = authorization.getAuthorizationHeader();

        function get(url, queryParams) {
            var defered = $q.defer();

            $http.get(baseServiceUrl + url, { params: queryParams, headers: authHeader })
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (error) {
                    var err = getError(error);
                    notifier.error(err);

                    defered.reject(error);
                })

            return defered.promise;
        }

        function post(url, postData) {
            var defered = $q.defer();

            $http.post(baseServiceUrl + url, postData,{ headers: authHeader })
                .then(function (response) {
                    defered.resolve(response.data.message);
                }, function (error) {
                    var err = getError(error);
                    notifier.error(err);

                    defered.reject(error);
                })

            return defered.promise;
        }

        function put(url, putData) {
            var defered = $q.defer();

            $http.put(baseServiceUrl + url, putData, { headers: authHeader })
                .then(function (response) {
                    defered.resolve(response.data.message);
                }, function (error) {
                    var err = getError(error);
                    notifier.error(err);

                    defered.reject(error);
                })

            return defered.promise;
        }

        function getError(response) {
            var error = response.data.modelState;

            if (error && error[Object.keys(error)[0]][0]) {
                error = error[Object.keys(error)[0]][0];
            }
            else {
                error = response.data.Message;
            }

            return error;
        }

        return {
            get: get,
            post: post,
            put: put
        }
    }

    angular.module('myApp.services')
        .factory('data', ['baseServiceUrl', '$http', '$q', 'notifier','authorization', data]);
}());