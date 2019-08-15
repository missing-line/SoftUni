const homeController = function () {

    const getHome = function (context) {
        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/homePage/home.hbs')
        }).then(() => {
            storage.isLogIn(context);
        })
    };

    return {
        getHome,
    }
}();