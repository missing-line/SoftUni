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

    const getHomeCinema = async function (context) {

        let repo = await userModel.getAllMovies();
        let movies = await repo.json();

        context.movies = movies.sort((a,b) => b.tickets - a.tickets);

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
            movie: './views/cinema/movie.hbs',
        }).then(function () {
            this.partial('./views/cinema/cinema.hbs')
        }).then(() =>{
            storage.isLogIn(context);
        })


    };

    return {
        getHome,
        getHomeCinema,
    }
}();