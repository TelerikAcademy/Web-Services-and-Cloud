'use strict';

app.factory('authorization', function(identity) {
    return {
        getAuthorizationHeader: function() {
            return {
                'Authorization': 'Bearer ' + identity.currentUser['access_token']
            }
        }
    }
});