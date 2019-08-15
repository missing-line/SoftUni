const userController = function () {

    const getRegister = function (context) {
        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/register/register.hbs')
        })
    };

    const getLogin = function (context) {
        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/login/login.hbs')
        })
    };

    const postRegister = function (context) {
        //helper.notify('loadingBox','Loading.......!');
        userModel.register(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                helper.stopNotify();
                helper.notify('infoBox','Success Register!');
                homeController.getHome(context);
            })
    };

    const postLogin = function (context) {
        helper.notify('loadingBox','Loading.......!');
        userModel.login(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                helper.stopNotify();
                helper.notify('infoBox','Success LogIn!');
                homeController.getHome(context);
            })
    };

    const logout = function (context) {
        helper.notify('loadingBox','Loading.......!');
        userModel.logout()
            .then(helper.handler)
            .then(() => {
                storage.deleteUser();
                helper.notify('infoBox','Success LogOut!');
               context.redirect('#/home');
            });
    };

    const getAddMovie = function (context) {
        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/create/create.hbs')
        }).then(storage.isLogIn(context))
    };

    const postCreateMovie = function (context) {
        helper.notify('loadingBox','Loading.......!');
        userModel.createMovie(context.params)
            .then(helper.handler)
            .then(() => {
                helper.stopNotify();
                helper.notify('infoBox','Success Creation!');
                homeController.getHome(context);
            })
    };

    const getCinema = function (context) {
        userModel.getAllMovies()
            .then(helper.handler)
            .then(() => {
                homeController.getHomeCinema(context);
            })
    };

    const getMovieDetails = async function (context) {
        const id = context.params.eventId;

        let repo = await userModel.getAllMovies();
        let movies = await repo.json();
        let currentMovie = movies.find(x => x._id === id);

        context.title = currentMovie.title;
        context.imageUrl = currentMovie.imageUrl;
        context.genre = currentMovie.genre;
        context.description = currentMovie.description;
        context.tickets = currentMovie.tickets;
        context._id = currentMovie._id;

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/details/details.hbs')
        }).then(storage.isLogIn(context))
    };

    const putBuyTicket = async function (context) {
        helper.notify('loadingBox','Loading.......!');
        const id = context.params.eventId;
        let repo = await userModel.getAllMovies();
        let movies = await repo.json();
        let currentMovie = movies.find(x => x._id === id);

        userModel.putTicketBuy(currentMovie)
            .then(helper.handler)
            .then(() => {
                this.redirect('#/cinema');
                homeController.getHomeCinema(context);
            })
    };

    const getMyMovies = async function (context) {
        const user = JSON.parse(storage.getData('userInfo'))._id;
        let repo = await userModel.getAllMovies();
        let movies = await repo.json();
        let collection = movies.filter(x => x._acl.creator === user);

        context.collection = collection;
        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
            singleCollection: './views/cinema/singleCollection.hbs',
        }).then(function () {
            this.partial('./views/cinema/myMovies.hbs')
        }).then(storage.isLogIn(context))
    };

    const deleteGet = async function (context) {
        const id = context.params.eventId;
        console.log(id);
        let repo = await userModel.getAllMovies();
        let movies = await repo.json();
        let currentMovie = movies.find(x => x._id === id);

        context.title = currentMovie.title;
        context.imageUrl = currentMovie.imageUrl;
        context.genres = currentMovie.genres;
        context.description = currentMovie.description;
        context.tickets = currentMovie.tickets;
        context._id = currentMovie._id;

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/delete/delete.hbs')
        }).then(storage.isLogIn(context))
    };

    const deletePost = function (context) {
        const id = context.params.eventId;
        userModel.deletePostMovie(id)
            .then(helper.handler)
            .then(() => {
                context.redirect('#/home');
            })
    };

    const editGet = async function (context) {
        const id = context.params.eventId;
        let repo = await userModel.getAllMovies();
        let movies = await repo.json();
        let currentMovie = movies.find(x => x._id === id);

        context.title = currentMovie.title;
        context.imageUrl = currentMovie.imageUrl;
        context.genres = currentMovie.genres;
        context.description = currentMovie.description;
        context.tickets = currentMovie.tickets;
        context._id = currentMovie._id;

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/edit/edit.hbs')
        }).then(storage.isLogIn(context))
    };

    const editPost = function (context) {
        const id = context.params.eventId;
        let title = context.params.title;
        let description = context.params.description;
        let imageUrl = context.params.imageUrl;
        let genres = context.params.genres;
        let tickets = Number(context.params.tickets);

        let data = {
            title: title,
            imageUrl: imageUrl,
            genres: genres,
            tickets: tickets,
            description: description,
        };
        let url = `/appdata/${storage.appKey}/movies/${id}`;
        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };
        requester.put(url, headers)
            .then(helper.handler)
            .then(() => {
                context.redirect('#/home');
            }).then(storage.isLogIn(context))
    };

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout,
        getAddMovie,
        postCreateMovie,
        getCinema,
        getMovieDetails,
        putBuyTicket,
        getMyMovies,
        deletePost,
        deleteGet,
        editGet,
        editPost
    }
}();