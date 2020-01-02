const model = require('../models/index');
const utils = require('../utils/index');
const {authCookieName} = require('../config/authCookie');
const {validationResult} = require('express-validator');

function create(req, res, next) {

    res
        .render('partials/createCourse.hbs', {
            pageTitle: 'Create Course',
            IsLoggedIn: req.cookies[authCookieName] !== undefined ,

        })
}

function postCreateCourse(req, res, next) {
    const token = req.cookies[authCookieName] || '';

    const errors = validationResult(req);

    if (!errors.isEmpty()) {
        return res
            .render('partials/createCourse.hbs', {
                pageTitle: 'Create Course',
                IsLoggedIn: req.cookies[authCookieName] !== undefined,
                message: errors.array()[0].msg,
            })
    }

    utils.jwt
        .verifyToken(token)
        .then(data => {
            model.userModel.findById(data.id).then(user => {

                const {title, description, imageUrl, isPublic} = req.body;
                const isCheckPublic = isPublic === 'on';
                const created = new Date().toLocaleDateString('en-US');

                model.courseModel.create({
                    title,
                    description,
                    imageUrl,
                    isPublic: isCheckPublic,
                    created,
                    creator: user.id
                })
                    .then(course => {
                        res.redirect('/');
                    })
            })
        });
}

function search(req, res) {

    const {search} = req.body;

    model.courseModel.find()
        .then(courses => {
            const course = courses.find(x => {
                return x.title.toLowerCase() === search.toLowerCase()
            });

            if (course === undefined)
                return res.redirect('/');

            const SearchPageInfo = {
                pageTitle: 'Search Page',
                IsLoggedIn: req.cookies[authCookieName] !== undefined,
                courses: [course]
            };
            res.render('partials/home.hbs', SearchPageInfo)
        })

}

function details(req, res, next) {

    const token = req.cookies[authCookieName] || '';

    const courseId = req.params._id;

    utils.jwt.verifyToken(token).then(data => {

        model.userModel.findById(data.id).then(user => {

            model.courseModel.findById(courseId).then(course => {

                res.render('partials/course-details.hbs', {
                    pageTitle: 'Details Course',
                    IsLoggedIn: req.cookies[authCookieName] !== undefined,
                    course,
                    IsCreator: user.id === course.creator.toString(),
                    IsEnrolled: course.users.includes(user.id)
                })
            });
        })
    });
}

function enroll(req, res, next) {

    const token = req.cookies[authCookieName] || '';

    const courseId = req.params._id;

    utils.jwt.verifyToken(token).then(data => {

        model.userModel.findById(data.id).then(user => {

            model.courseModel.findOne({_id: courseId}).then(course => {

                course.users.push(user.id);
                course.save();

                user.courses.push(courseId);
                user.save();

                res.redirect('/');
            });

        })
    })
}

function edit(req, res, next) {

    res.render('partials/editCourse.hbs', {
        pageTitle: 'Edit Page',
        IsLoggedIn: req.cookies[authCookieName] !== undefined,
    })
}

function postEdit(req, res, next) {

    const {title, description, imageUrl, isPublic} = req.body;

    const courseId = req.params.id;

    const isCheckPublic = isPublic === 'on';

    model.courseModel.findByIdAndUpdate(courseId, {title, description, imageUrl, isPublic: isCheckPublic})
        .then(course => {
            res.redirect(`/details/${courseId}`);
        })
}

function del(req, res, next) {
    const courseId = req.params.id;

    model.courseModel.findByIdAndDelete(courseId).then(course => {
        res.redirect('/');
    })
}

module.exports = {
    create,
    postCreateCourse,
    search,
    details,
    enroll,
    edit,
    postEdit,
    del
};