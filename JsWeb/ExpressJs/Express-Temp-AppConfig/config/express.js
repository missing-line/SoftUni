const path = require('path');
const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser');
const secret = 'secret';


module.exports = (app) => {

    app.use(bodyParser.urlencoded({extended:false}));

    app.use(cookieParser(secret));

    app.set('views', handlebars({extname : '.hbs', defaultLayout: false}));

    app.engine('.hbs', path.resolve(_basedir , 'views'));
};

