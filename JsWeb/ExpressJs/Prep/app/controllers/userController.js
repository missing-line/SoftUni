const model = require('../models/index');
const utils = require('../utils/index');
const authCookie = require('../config/authCookie');
const {validationResult} = require('express-validator');

function login(req, res, next) {
    res.render('partials/login.hbs', {pageTitle: 'Login Page'})
}

function postLogin(req, res, next) {
    const {username, password} = req.body;

    model.userModel.findOne({username})
        .then(user => Promise.all([user, user ? user.matchPassword(password) : false]))
        .then(([user, match]) => {
            
            if (!match) {
                return res.render('partials/login.hbs', {
                    message: 'Wrong password or username!'
                });
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
        return res.render('partials/createCourse.hbs', {
            message: 'Invalid data!'
        });
    // =>                                <=\\
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
        return res.render('partials/createCourse.hbs', {
            message: errors.array()[0].msg,
            oldInput: req.body
        })
    }


    model.userModel.create({username, password})
        .then(user => {
            const token = utils.jwt.createToken({id: user._id});
            res.cookie(authCookie.authCookieName, token).redirect('/');
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