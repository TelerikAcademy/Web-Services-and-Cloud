'use strict';
let fs = require('fs');
let path = './models';
fs.readdirSync(path)
  .filter(file => file !== 'index.js')
  .forEach(file => require(`./${file}`));
