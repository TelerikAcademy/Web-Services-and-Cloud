'use strict';

let mongoose = require('mongoose');

let schema = new mongoose.Schema({
  text: {
    type: String,
    required: true
  },
  date: {
    type: Date,
    required: true
  },
  type: {
    type: mongoose.Schema.Types.Mixed,
    required: true
  },
  user: {
    type: mongoose.Schema.Types.Mixed,
    required: true
  }
});

mongoose.model('Log', schema);
