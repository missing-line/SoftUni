const model = require('../models/index');
const utils = require('../utils/index');
const authCookie = require('../config/authCookie');
const {validationResult} = require('express-validator');

function login(req, res, next) {
    res.render('partials/login.hbs', {
        pageTitle: 'Login Page',
        IsLoggedIn: req.cookies[authCookie.authCookieName] !== undefined
    })
}

function postLogin(req, res, next) {
    const {username, password} = req.body;

    model.userModel.findOne({username})
        .then(user => Promise.all([user, user ? user.matchPassword(password) : false]))
        .then(([user, match]) => {
            
            if (!match) {
                return res.render('partials/login.hbs');
            }
            const token = utils.jwt.createToken({id: user._id});

            res
                .cookie(authCookie.authCookieName, token)
                .redirect('/');

        });
}

function register(req, res, next) {
    res.render('partials/register.hbs', {pageTitle: 'Register Page'});
}

function postRegister(req, res, next) {
    const {username, password, repeatPassword} = req.body;

    if (password !== repeatPassword)
        return res.render('partials/register.hbs', {
            message: 'Invalid data!'
        });

    model.userModel.create({username, password})
        .then(user => {
            const token = utils.jwt.createToken({id: user._id});

            res
                .cookie(authCookie.authCookieName, token)
                .redirect('/');
        })
}

function logout(req, res, next) {
    res.clearCookie(authCookie.authCookieName).redirect('/');
}

module.exports = {
    login,
    register,
    postRegister,
    postLogin,
    logout
};