'use strict';
let fs = require('fs');

module.exports = function(app) {
  let path = './routers';
  fs.readdirSync(path)
    .filter(file => file !== 'index.js')
    .forEach(file => require(`./${file}`)(app));
}
