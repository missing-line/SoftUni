const userModel = function () {

    const register = function (params) {
        let user = params.username;
        let password = params.password;
        let repeatPassword = params.rePassword;

        if (user && password && password === repeatPassword) {
            let data = {
                username: params.username,
                password: params.password,
            };

            let url = `/user/${storage.appKey}`;

            let auth = btoa(`${storage.appKey}:${storage.appSecret}`);
            let authString = `Basic ${auth}`;

            let headers = {
                body: JSON.stringify(data),
                headers: {
                    Authorization: authString
                }
            };

            return requester.post(url, headers);
        }
    };

    const login = function (params) {

        let url = `/user/${storage.appKey}/login`;

        let auth = btoa(`${params.username}:${params.password}`);
        let authString = `Basic ${auth}`;

        let headers = {
            headers: {
                Authorization: authString
            },
            body: JSON.stringify({...params})
        };

        return requester.post(url, headers);
    };

    const logout = function () {
        let url = `/user/${storage.appKey}/_logout`;
        let headers = {
            headers: {}
        };

        return requester.post(url, headers);
    };

    const create = function (params) {

        if (params.description && !isNaN(params.price) && params.imageUrl.startsWith('https://') && params.product) {
            let url = `/appdata/${storage.appKey}/offers`;
            let headers = {
                body: JSON.stringify({...params}),
                headers: {}
            };

            return requester.post(url, headers)
        }
    };

    const getAllOffers = function () {
        let url = `/appdata/${storage.appKey}/offers`;
        let headers = {
            headers: {}
        };
        return requester.get(url, headers)
    };

    const postDeleteOffers = function (id) {
        let url = `/appdata/${storage.appKey}/offers/${id}`;
        let headers = {
            headers: {}
        };
        return requester.del(url, headers)
    };

    const postEditOffer = function (params) {
        let url = `/appdata/${storage.appKey}/offers/${params.eventId}`;
        let data = {
            product: params.product,
            description: params.description,
            imageUrl: params.pictureUrl,
            price: params.price,
            buy: Number(params.buy),
        };

        let headers = {
            body: JSON.stringify(data),
            headers: {
                Authorization: '',
            },
        };

        return requester.put(url, headers)
    };



    return {
        register,
        login,
        logout,
        create,
        getAllOffers,
        postDeleteOffers,
        postEditOffer,

    }
}();
