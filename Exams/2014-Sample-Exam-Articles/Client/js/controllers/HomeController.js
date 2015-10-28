'use strict';

app.controller('HomeController',
    function HomeController($scope, ArticlesResource) {
        ArticlesResource.getLatest().success(function(articles) {
            $scope.articles = articles;
        })
    }
);