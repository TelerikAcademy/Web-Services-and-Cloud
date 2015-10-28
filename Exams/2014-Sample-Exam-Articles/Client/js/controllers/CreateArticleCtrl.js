'use strict';

app.controller('CreateArticleCtrl',
    function CreateArticleCtrl($scope, $location, ArticlesResource, identity) {
        if (!identity.isAuthenticated()) {
            $location.path('/signup');
        }

        $scope.createArticle = function(article) {
            article.tags = article.tags.split(',');
            ArticlesResource.create(article).success(function() {
                $location.path('/');
            });
        }
    }
);
