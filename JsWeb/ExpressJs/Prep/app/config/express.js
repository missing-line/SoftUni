const path = require('path');
const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser');
const secret = 'secret';


module.exports = (app) => {

    app.engine('hbs', handlebars({
        extname: 'hbs',
        defaultLayout: 'main',
        layoutsDir: __dirname + '../../views/layouts/',
        partialsDir: __dirname + '../../views/partials/'
    }));

    app.set('view engine', 'hbs');

    app.use(bodyParser.urlencoded(
        {
            extended: true
        }));

    app.use(cookieParser(secret));

    app.use(express.static('./static'));

};