'use strict';

let express = require('express'),
  bodyParser = require('body-parser'),
  mongoose = require('mongoose'),
  app = express();

let connectionString = "mongodb://localhost/logger";

mongoose.connect(connectionString);

app.use(bodyParser.json());

require('./models');
require('./authentication-config');
require('./routers')(app);

app.use(function(err, req, res, next) {
  if (err) {
    res.status(err.status || 500)
      .json({
        message: err.message
      });
    return;
  }
});

// app.use(function(req, res, next) {
//   console.log('asdasd');
//   console.log(`Body: ${res.body}`);
//   res.body = {
//     result: res.body
//   };
//   next();
// });

let port = 3001;
app.listen(port, () =>
  console.log(`Server running at localhost:${port}`));
