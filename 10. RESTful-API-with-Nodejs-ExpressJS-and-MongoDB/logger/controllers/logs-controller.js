'use strict';

let mongoose = require('mongoose'),
  Log = mongoose.model('Log');

var controller = {
  all: function(req, res) {
    let filter = {};

    if (req.query.type) {
      filter.type = req.query.type
    }

    if (req.query.userId) {
      filter.user = req.query.userId
    }

    Log.find(filter, function(err, logs) {
      if (err) {
        throw err;
      }

      res.json({
        result: logs
      });
    });
  },
  add: function(req, res, next) {
    let log = req.body;
    log.type = log.type || 'uncategorized';
    let user = req.user;
    log.date = new Date();
    log.user = user._id;

    var dbLog = new Log(log);
    dbLog.save(function(err) {
      if (err) {
        next(err);
        return;
      }

      res.status(201)
        .json({
          result: dbLog
        });
    });
  }
};

module.exports = controller;
