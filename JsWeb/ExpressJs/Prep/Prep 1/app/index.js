const dbConnection = require('./config/db');

dbConnection()
    .then(() => {
        const config = require('./config/config'); // connection port
        const app = require('express')();

        require('./config/express')(app);
        require('./config/routes')(app);

        app.listen(config.port, console.log(`Listening on port ${config.port}!`));
    });