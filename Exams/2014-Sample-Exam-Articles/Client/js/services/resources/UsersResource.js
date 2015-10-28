'use strict';

app.factory('UsersResource', function($resource, baseUrl) {
    var usersApi = baseUrl + '/api/users';

    var UsersResource = {
        register:  $resource(usersApi + '/register'),
        login:  $resource(usersApi + '/login'),
        logout:  $resource(usersApi + '/logout')
    }

    return UsersResource;
});