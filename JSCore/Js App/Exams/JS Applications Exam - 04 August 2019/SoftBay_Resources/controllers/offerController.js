const offerController = function () {

    const getCreate = function (context) {
        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/create/create.hbs')
        }).then(storage.isLogIn(context))
    };

    const postCreate = function (context) {
        helper.notify("errorNotification", 'If cant create item , please insert valid data!');
        userModel.create(context.params)
            .then(helper.handler)
            .then(() => {
                helper.stopNotify();
                helper.notify("successNotification", 'Success Create Item!');
                context.redirect('#/details')
            })
    };

    const getDetails = async function (context) {
        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            let repo = await userModel.getAllOffers();
            let event = await repo.json();

            let obj = JSON.parse(storage.getData('userInfo'));
            let id = obj["_id"];// id user

            for (let key of event) {
                key['creator'] = key._acl.creator === id;
            }
            context.products = event;
        }

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/details/details.hbs')
        })
    };

    const getDelete = async function (context) {
        console.log(context.params);

        let repo = await userModel.getAllOffers();
        let current = await repo.json();

        let find = current.find(x => x._id === context.params.eventId);
        Object.keys(find).forEach((x) => {
            context[x] = find[x];
        });

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/delete/delete.hbs')
        }).then(storage.isLogIn(context))
    };

    const postDelete = function (context) {
        helper.notify("loadingNotification", 'Loading....!');
        userModel.postDeleteOffers(context.params.eventId)
            .then(helper.handler)
            .then(() => {
                helper.stopNotify();
                helper.notify("successNotification", 'Success Delete Item!');
                context.redirect('#/details');
            })
    };

    const getEdit = async function (context) {
        let repo = await userModel.getAllOffers();
        let current = await repo.json();

        let find = current.find(x => x._id === context.params.eventId);

        Object.keys(find).forEach((x) => {
            context[x] = find[x];
        });

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/edit/edit.hbs')
        }).then(storage.isLogIn(context))
    };

    const postEdit = function (context) {
        helper.notify("loadingNotification", 'Loading....!');
        userModel.postEditOffer(context.params)
            .then(helper.handler)
            .then(() => {
                helper.stopNotify();
                helper.notify("successNotification", 'Success Edit!');
                context.redirect('#/details');
            })
    };

    const getInfo  = async  function (context) {

        let repo = await userModel.getAllOffers();
        let current = await repo.json();

        let find = current.find(x => x._id === context.params.eventId);

        Object.keys(find).forEach(x => {
            context[x] = find[x];
        });

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/info/info.hbs')
        }).then(storage.isLogIn(context))

    };

    const getProfile = async function (context) {

        let repo = await userModel.getAllOffers();
        let event = await repo.json();

        let obj = JSON.parse(storage.getData('userInfo'));
        let id = obj["_id"];// id user
        let find = event.filter(x => x._acl.creator === id);

        context.offersCount = find.length;

        context.loadPartials({
            header: './views/homePage/header.hbs',
            footer: './views/homePage/footer.hbs',
        }).then(function () {
            this.partial('./views/profile/profile.hbs')
        }).then(storage.isLogIn(context))
    };

    return {
        getCreate,
        getDetails,
        postCreate,
        getDelete,
        postDelete,
        getEdit,
        postEdit,
        getInfo,
        getProfile
    }
}();