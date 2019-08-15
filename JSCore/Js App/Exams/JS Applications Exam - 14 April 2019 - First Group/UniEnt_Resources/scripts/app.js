const app = Sammy("#main", function () {

    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome);
    //User
    this.get('#/register',userController.getRegister);
    this.get('#/login',userController.getLogin);
    this.post('#/register',userController.postRegister);
    this.post('#/login',userController.postLogin);
    this.get('#/logout',userController.logout);
    //Event
    this.get('#/createEvent',userController.createEvent);
    this.get('#/details/:eventId',userController.getDetails);
    this.post('#/createEvent',userController.postEvent);
    //Profile
    this.get('#/profile',userController.getProfile);
    //Edit
    this.get('#/edit/:eventId',userController.getEdit);
    this.post('#/edit/:eventId',userController.postEdit);
    //Delete
    this.get('#/delete/:eventId',userController.deletePost);
    //Join
    this.get('#/join/:eventId',userController.postJoin);
});

(() => {
    app.run('#/home');
})();