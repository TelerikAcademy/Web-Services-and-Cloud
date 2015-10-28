'use strict';

app.factory('CategoriesResource', function($http, baseUrl) {
    var categoriesApi = baseUrl + '/api/categories';

    return {
        getAll: function() {
            return $http.get(categoriesApi);
        },
        getArticlesInCategory: function(id) {
            return $http.get(categoriesApi + '/' + id);
        }
    }
});