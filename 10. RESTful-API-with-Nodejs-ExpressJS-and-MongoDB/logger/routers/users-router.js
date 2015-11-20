'use strict';

let express = require('express'),
  router = express.Router();

let controller = require('./../controllers/users-controller');

router.post('/register', controller.register)
    .post('/token', controller.login);

module.exports = function(app) {
  app.use('/api/users', router);
};
