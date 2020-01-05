const model = require('../models/index');
const {validationResult} = require('express-validator');

function create(req, res, next) {

    res
        .render('partials/createCourse.hbs', {pageTitle: 'Create Course',})
}

function postCreateCourse(req, res, next) {
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
        return res
            .render('partials/createCourse.hbs', {
                pageTitle: 'Create Course',
                message: errors.array()[0].msg
            })
    }

    const {title, description, imageUrl, isPublic} = req.body;
    const isPublicChecker = isPublic === 'on';
    const created = new Date().toLocaleDateString('en-US');

    model.courseModel.create({
        title,
        description,
        imageUrl,
        isPublic: isPublicChecker,
        created,
        creator: req.user._id
    }).then(() => {
        res.redirect('/');
    })
}

function search(req, res) {

    const {search} = req.body;

    model.courseModel.find().then(courses => {
        const course = courses.find(x => {
            return x.title.toLowerCase() === search.toLowerCase()
        });

        if (course === undefined)
            return res.redirect('/');

        const SearchPageInfo = {
            pageTitle: 'Search Page',
            courses: [course]
        };
        res.render('partials/home.hbs', SearchPageInfo)
    })
}

function details(req, res, next) {

    const courseId = req.params._id;

    model.courseModel.findById(courseId).then(course => {

        res.render('partials/course-details.hbs', {
            pageTitle: 'Details Course',
            course,
            IsCreator: course.creator.toString() === req.user._id.toString(),
            IsEnrolled: course.users.includes(req.user._id)
        })
    });
}

function enroll(req, res, next) {

    const courseId = req.params._id;

    model.courseModel.findOne({_id: courseId}).then(course => {

        course.users.push(req.user._id);
        course.save();

        req.user.courses.push(courseId);
        req.user.save();

        res.redirect('/');
    });

}

function edit(req, res, next) {

    res.render('partials/editCourse.hbs', {
        pageTitle: 'Edit Page',
    })
}

function postEdit(req, res, next) {

    const {title, description, imageUrl, isPublic} = req.body;

    const courseId = req.params.id;

    const isCheckPublic = isPublic === 'on';

    model.courseModel.findByIdAndUpdate(courseId, {title, description, imageUrl, isPublic: isCheckPublic})
        .then(() => {
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