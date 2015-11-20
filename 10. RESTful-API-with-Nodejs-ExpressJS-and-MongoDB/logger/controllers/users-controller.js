'use strict';

let mongoose = require('mongoose'),
  User = mongoose.model('User');

function generateNewToken() {
  return Math.random() + '';
}

let controller = {
  register: function(req, res, next) {
    let user = req.body;

    user.usernameToLower = user.username.toLowerCase();

    let dbUser = new User(user);
    dbUser.save(function(err) {
      if (err) {
        next(err);
        return;
      }
      res.status(201)
        .json({
          username: user.username
        });
    })
  },
  login: function(req, res, next) {
    let user = req.body;

    User.findOne({
      usernameToLower: user.username.toLowerCase()
    }, function(err, dbUser) {
      if (err) {
        next(err);
        return;
      }

      if (!user || user.password !== dbUser.password) {
        next({
          message: "Invalid username or password"
        });
        return;
      }

      if (!dbUser.token) {
        dbUser.token = generateNewToken();
        dbUser.save();
      }

      res.json({
        username: dbUser.username,
        token: dbUser.token
      });
    });
  },
};

module.exports = controller;
