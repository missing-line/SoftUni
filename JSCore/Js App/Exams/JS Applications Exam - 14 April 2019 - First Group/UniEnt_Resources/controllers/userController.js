const userController = function () {

    const getRegister = function (context) {
        context.loadPartials({
            header: './views/home/header.hbs',
            footer: './views/home/footer.hbs',
        }).then(function () {
            this.partial('./views/register/registerPage.hbs')
        })
    };

    const getLogin = function (context) {
        context.loadPartials({
            header: './views/home/header.hbs',
            footer: './views/home/footer.hbs',
        }).then(function () {
            this.partial('./views/login/loginPage.hbs');
        })
    };

    const postRegister = function (context) {
        helper.notify('loadingBox', 'Loading...!');
        userModel.register(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                helper.notify('successBox', 'Success Register!');
                homeController.getHome(context);
            })
    };

    const postLogin = function (context) {
        helper.notify('loadingBox', 'Loading...!');
        userModel.login(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                helper.stopNotify();
                helper.notify('successBox', 'Success Login!');
                homeController.getHome(context);
            })
    };

    const logout = function (context) {
        helper.notify('successBox', 'Success LogOut!');
        userModel.logout()
            .then(helper.handler)
            .then(() => {
                storage.deleteUser();
                helper.stopNotify();
                helper.notify('successBox', 'Success LogOut!');
               context.redirect('#/home');
            });
    };

    const createEvent = function (context) {
        context.loadPartials({
            header: './views/home/header.hbs',
            footer: './views/home/footer.hbs',
        }).then(function () {
            this.partial('./views/event/organize.hbs')
        })
            .then(storage.isLogIn(context))

    };

    const postEvent = function (context) {
        userModel.createEventPost(context.params)
            .then(helper.handler)
            .then(() => {
                helper.notify('successBox', 'Success Operation!');
                context.redirect('#/home');
            })
    };

    const getProfile = async function (context) {

        const id = JSON.parse(storage.getData('userInfo'))._id;
        let response = await userModel.getAllEvents();
        let ev = await response.json();
        let acl = ev.filter(x => {
            return x._acl.creator === id
        });
        context.count = acl.length;
        let name = acl.filter(x => {
            return x.name;
        });
        context.eventName = name;

        context.loadPartials({
            header: './views/home/header.hbs',
            footer: './views/home/footer.hbs',
        }).then(function () {
            this.partial('./views/userProfil/userProfil.hbs')
        })
            .then(storage.isLogIn(context))
    };

    const getDetails = async function (context) {
        const loggedIn = storage.getData('userInfo') !== null;
        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response = await userModel.getEvent(context.params.eventId);
            let ev = await response.json();

            Object.keys(ev).forEach((x) => {
                context[x] = ev[x];
            });

            context.creator = JSON.parse(storage.getData('userInfo')).username === ev.organizer;
        }
        context.loadPartials({
            header: './views/home/header.hbs',
            footer: './views/home/footer.hbs',
        }).then(function () {
            this.partial('./views/event/details.hbs')
        })

    };

    const getEdit = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            let response = await userModel.getEvent(context.params.eventId);
            let ev = await response.json();

            Object.keys(ev).forEach((x) => {
                context[x] = ev[x];
            });
        }

        context.loadPartials({
            header: './views/home/header.hbs',
            footer: './views/home/footer.hbs',
        }).then(function () {
            this.partial('./views/event/edit.hbs')
        })
    };

    const postEdit = function (context) {

        userModel.putEdit(context.params)
            .then(helper.handler)
            .then(() => {
                context.redirect('#/home');
            })
    };

    const deletePost = function (context) {
        let url = `https://baas.kinvey.com/appdata/${storage.appKey}/events/${context.params.eventId}`;
        let headers = {
            headers: {}
        };

        requester.del(url, headers)
            .then(headers.headers)
            .then(() => {
                context.redirect('#/home');
            })
    };

    const postJoin =  async  function (context) {
        let response = await userModel.getEvent(context.params.eventId);
        let ev = await response.json();
        helper.notify('loadingBox', 'Loading...!');
        userModel.joinPost(ev)
            .then(helper.handler)
            .then(() => {
                context.redirect('#/home')
            })
    };

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout,
        createEvent,
        postEvent,
        getProfile,
        getDetails,
        getEdit,
        postEdit,
        deletePost,
        postJoin
    }
}();