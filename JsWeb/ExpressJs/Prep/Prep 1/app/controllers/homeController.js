const authCookie = require('../config/authCookie');
const models = require('../models/index');

function home(req, res, next) {

    models.courseModel.find()
        .then(courses => {

            const homePageInfo = {
                pageTitle: 'Home Page',
                IsLoggedIn: req.cookies[authCookie.authCookieName] !== undefined,
                courses
            };

            if (!homePageInfo.IsLoggedIn)
                    homePageInfo.courses = courses
                        .filter(x => {if (x.isPublic){return x; }})
                        .sort((a,b) => a.title.localeCompare(b.title));

            res.render('partials/home.hbs', homePageInfo);
        });
}

module.exports = {
    home,
};