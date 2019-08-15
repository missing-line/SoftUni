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
        helper.notify("loadingNotification", 'Loading....!');
        userModel.register(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                helper.notify("successNotification", 'Success Register!');
                homeController.getHome(context);
            })
    };

    const postLogin = function (context) {
        helper.notify("loadingNotification", 'Loading....!');
        userModel.login(context.params)
            .then(helper.handler)
            .then((data) => {
                storage.saveUser(data);
                helper.stopNotify();
                helper.notify("successNotification", 'Success LogIn!');
                homeController.getHome(context);
            })
    };

    const logout = function (context) {
        helper.notify("loadingNotification", 'Loading....!');
        userModel.logout()
            .then(helper.handler)
            .then(() => {
                storage.deleteUser();
                helper.stopNotify();
                helper.notify("successNotification", 'Success LogOut!');
                context.redirect('#/home');
            });
    };

    return {
        getRegister,
        postRegister,
        getLogin,
        postLogin,
        logout,
    }
}();