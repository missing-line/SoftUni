const app = Sammy("#main", function () {

    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome);
    //User
    this.get('#/register',userController.getRegister);
    this.post('#/register',userController.postRegister);

    this.get('#/login',userController.getLogin);
    this.post('#/login',userController.postLogin);

    this.get('#/logout',userController.logout);

    this.get('#/create',offerController.getCreate);
    this.post('#/create',offerController.postCreate);

    this.get('#/details',offerController.getDetails);

    this.get('#/delete/:eventId',offerController.getDelete);
    this.post('#/delete/:eventId',offerController.postDelete);

    this.get('#/edit/:eventId',offerController.getEdit);
    this.post('#/edit/:eventId',offerController.postEdit);

    this.get('#/info/:eventId',offerController.getInfo);

    this.get('#/profile',offerController.getProfile);

});

(() => {
    app.run('#/home');
})();