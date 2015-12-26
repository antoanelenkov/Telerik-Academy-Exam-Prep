(function () {
    'use strict';

    function licenseImg() {
        return function (input) {
            var imgSrc = '';
            debugger;
            switch (input) {
                case "Apache": 
                    imgSrc = 'img/apache.jpg';
                    break;
                case "MIT":
                    imgSrc = 'img/mit.jpg';
                    break;
                case "Mozilla Public License":
                    imgSrc = 'img/mozzila.jpg';
                    break;
                case "GPL":
                    imgSrc = 'img/gpl.jpg';
                    break;
                case "BSD":
                    imgSrc = 'img/bsd.jpg';
                    break;
            }

            return imgSrc;
        }
    }

    angular.module('myApp.filters')
        .filter('licenseImg', [licenseImg]);
}());