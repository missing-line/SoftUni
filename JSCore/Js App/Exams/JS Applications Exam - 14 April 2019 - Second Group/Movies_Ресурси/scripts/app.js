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
    // ...Movie Section... //
    this.get('#/create',userController.getAddMovie);
    this.post('#/create',userController.postCreateMovie);

    this.get('#/cinema',userController.getCinema);
    this.get('#/details/:eventId',userController.getMovieDetails);
    this.get('#/buy/:eventId',userController.putBuyTicket);
    this.get('#/myMovies',userController.getMyMovies);

    this.get('#/delete/:eventId',userController.deleteGet);
    this.post('#/delete/:eventId',userController.deletePost);

    this.get('#/edit/:eventId',userController.editGet);
    this.post('#/edit/:eventId',userController.editPost);

});

(() => {
    app.run('#/home');
})();