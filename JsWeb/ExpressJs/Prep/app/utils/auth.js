const jwt = require('./jwt');
const authCookie = require('../config/authCookie');
const model = require('../models/index');

function auth(redirectUnauthenticated = true) {
    return function (req, res, next) {
        const token = req.cookies[authCookie] || '';
        Promise.all([jwt.verifyToken(token)])
            .then(([data]) => {
                model.userModel.findById(data.id).then(user => {
                    req.user = user;
                    next();
                })
            }).catch(err => {
            if (!redirectUnauthenticated) {
                next();
                return;
            }
            next(err);
        })
    }
}

module.exports = auth;


