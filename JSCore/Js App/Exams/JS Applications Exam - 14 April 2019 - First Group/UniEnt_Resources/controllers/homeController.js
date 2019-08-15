const homeController = function () {

    const getHome = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            let response = await userModel.getAllEvents();
            context.events = await response.json();
        }

        context.loadPartials({
            header: './views/home/header.hbs',
            footer: './views/home/footer.hbs',
            eventView: './views/event/eventView.hbs',
        }).then(function () {
            this.partial('./views/home/homePage.hbs')
        })
    };

        return {
            getHome,
        }
}();