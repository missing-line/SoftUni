const path = require('path');
const authCookie = require('./authCookie');
const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser');
const secret = 'secret';


module.exports = (app) => {

    app.use(cookieParser(secret));

    app.use(bodyParser.urlencoded(
        {
            extended: true
        }));

    app.engine('hbs', handlebars({
        extname: 'hbs',
        defaultLayout: 'main',
        layoutsDir: __dirname + '../../views/layouts/',
        partialsDir: __dirname + '../../views/partials/'
    }));


    app.use((req, res, next) => {

        res.locals.IsLoggedIn = req.cookies[authCookie.authCookieName] !== undefined;
        res.locals.username = req.cookies['username'];

        next();

    });

    app.set('view engine', 'hbs');

    app.use(express.static('./static'));

};