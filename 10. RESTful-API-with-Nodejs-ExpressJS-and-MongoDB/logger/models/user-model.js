'use strict';

let mongoose = require('mongoose');

let schema = new mongoose.Schema({
  username: {
    type: String,
    required: true,
    index: {
      unique: true
    }
  },
  usernameToLower: {
    type: String,
    required: true,
    index: {
      unique: true
    }
  },
  password: {
    type: String,
    required: true
  },
  token: String
});

mongoose.model('User', schema);
