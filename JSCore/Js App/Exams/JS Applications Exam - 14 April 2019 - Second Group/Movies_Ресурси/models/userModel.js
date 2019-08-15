const userModel = function () {

    const register = function (params) {
        let user = params.username;
        let password = params.password;
        let repeatPassword = params.repeatPassword;

        if (user.length >= 3 && password.length >= 6 && password === repeatPassword) {
            let data = {
                username: params.username,
                password: params.password
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

    const createMovie = function (params) {
        let title = params.title;
        let description = params.description;
        let imageUrl = params.imageUrl;
        let genres = params.genres;
        let tickets = Number(params.tickets);

        if (title.length >= 6 &&
            description.length >= 10 &&
            (imageUrl.startsWith('https://') || imageUrl.startsWith('http://')) &&
            isNaN(tickets) === false &&
            genres.includes(' ')) {
            let url = `/appdata/${storage.appKey}/movies`;
            let headers = {
                headers: {
                    Authorization: '',
                },
                body: JSON.stringify({...params})
            };

            return requester.post(url, headers)
        } else {

        }
    };

    const getAllMovies = function () {
        let url = `/appdata/${storage.appKey}/movies`;
        let headers = {
            headers: {
                Authorization: '',
            },
        };
        return requester.get(url, headers);
    };

    const putTicketBuy = function (currentMovie) {
        if (currentMovie.tickets >= 1) {
            let url = `/appdata/${storage.appKey}/movies/${currentMovie._id}`;
            let data = {
                title: currentMovie.title,
                description: currentMovie.description,
                imageUrl: currentMovie.imageUrl,
                genres: currentMovie.genres,
                tickets: currentMovie.tickets - 1,
            };


            let headers = {
                body: JSON.stringify(data),
                headers: {
                    Authorization: '',
                },
            };

            return requester.put(url, headers)
        }
    };

    const deletePostMovie = function (id) {
        let url = `/appdata/${storage.appKey}/movies/${id}`;
        let headers = {
            headers: {}
        };
        return requester.del(url, headers)
    };


    return {
        register,
        login,
        logout,
        createMovie,
        getAllMovies,
        putTicketBuy,
        deletePostMovie,
    }
}();
