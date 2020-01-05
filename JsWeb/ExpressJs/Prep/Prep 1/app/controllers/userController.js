const model = require('../models/index');
const utils = require('../utils/index');
const authCookie = require('../config/authCookie');

function login(req, res, next) {
    res.render('partials/login.hbs', {
        pageTitle: 'Login Page',
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
                .cookie('username', user.username)
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
                .cookie('username', user.username)
                .redirect('/');
        })
}

function logout(req, res, next) {
    res
        .clearCookie(authCookie.authCookieName)
        .clearCookie('username')
        .redirect('/');
}

module.exports = {
    login,
    register,
    postRegister,
    postLogin,
    logout
};