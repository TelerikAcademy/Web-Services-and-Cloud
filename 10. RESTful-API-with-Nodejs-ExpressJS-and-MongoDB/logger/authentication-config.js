'use strict';

let passport = require('passport'),
  Strategy = require('passport-http-bearer'),
  mongoose = require('mongoose');

let User = mongoose.model('User');

passport.use(new Strategy(function(token, done) {
  User.findOne({
    token
  }, function(err, user) {
    if(err){
      done(err);
      return;
    }

    done(null, user);
  });
}));
