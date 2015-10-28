'use strict';

app.controller('PageController',
    function PageController($scope, author, copyright) {
        $scope.author = author;
        $scope.copyright = copyright;
    }
);