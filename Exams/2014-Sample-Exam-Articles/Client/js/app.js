'use strict';

var app = angular
    .module('app', ['ngResource', 'ngRoute'])
    .config(function($routeProvider, $httpProvider) {

        $routeProvider
            .when('/home', {
                templateUrl: 'templates/home.html'
            })
            .when('/login', {
                templateUrl: 'templates/login.html'
            })
            .when('/signup', {
                templateUrl: 'templates/signup.html'
            })
            .when('/create', {
                templateUrl: 'templates/create.html'
            })
            .otherwise({redirectTo: '/home'});
    })
    .constant('toastr', toastr)
    .constant('baseUrl', 'http://localhost:16727')
    .constant('author', 'Ivaylo Kenov & Evlogi Hristov')
    .constant('copyright', 'Telerik Academy');