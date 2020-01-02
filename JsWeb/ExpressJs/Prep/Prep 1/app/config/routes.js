const controller = require('../controllers/index');
const auth = require('../utils/index');

module.exports = (app) => {

    app.get('/', auth.authUser(false), controller.homeController.home);

    app.get('/login', controller.userController.login);
    app.post('/login', controller.userController.postLogin);

    app.get('/register', controller.userController.register);
    app.post('/register', auth.validator, controller.userController.postRegister);

    app.get('/logout', controller.userController.logout);


    app.get('/course/create', controller.authController.create);
    app.post('/course/create', auth.validator, controller.authController.postCreateCourse);

    app.get('/details/:_id', controller.authController.details);

    app.get('/enroll/:_id', controller.authController.enroll);

    app.get('/edit/:id', controller.authController.edit);
    app.post('/edit/:id', controller.authController.postEdit);

    app.get('/delete/:id', controller.authController.del);

    app.post('/search', controller.authController.search);
};