'use strict';

let express = require('express'),
  router = express.Router(),
  passport = require('passport');

let controller = require('./../controllers/logs-controller');

router.get('/', controller.all)
  .post('/',
    passport.authenticate('bearer', {
      session: false
    }),
    controller.add);

module.exports = function(app) {
  app.use('/api/logs', router);
};
