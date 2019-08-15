const userModel = function () {

    const register = function (params) {
        let user = params.username;
        let password = params.password;
        let rePassword = params.rePassword;

        if (user.length < 3 || password.length < 6 || password !== rePassword) {
            helper.notify('errorBox', 'Error data!');
            window.location = '#/register';
        } else {
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

    const createEventPost = function (params) {
        let data = {
            ...params,
            peopleInterestedIn: 0,
            organizer: JSON.parse(storage.getData('userInfo')).username
        };

        let url = `/appdata/${storage.appKey}/events`;
        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };
        return requester.post(url, headers);
    };

    const getAllEvents = function () {
        let url = `https://baas.kinvey.com/appdata/${storage.appKey}/events`;
        let headers = {
            headers: {}
        };
        return requester.get(url, headers);
    };

    const getEvent = function (id) {
        let url = `https://baas.kinvey.com/appdata/${storage.appKey}/events/${id}`;
        let headers = {
            headers: {}
        };
        return requester.get(url, headers);
    };

    const putEdit = function (params) {

        let url = `https://baas.kinvey.com/appdata/${storage.appKey}/events/${params.eventId}`;
        let data = {
            name: params.name,
            description: params.description,
            dateTime: params.dateTime,
            imageURL: params.imageURL,
            organizer: params.organizer,
            peopleInterestedIn: params.peopleInterestedIn
        };

        let headers = {
            body: JSON.stringify(data),
            headers: {
                Authorization: '',
            }
        };
        return requester.put(url, headers);
    };

    const joinPost = function (currentEvent) {
        let url = `https://baas.kinvey.com/appdata/${storage.appKey}/events/${currentEvent._id}`;
        currentEvent.peopleInterestedIn++;
        let data = {
            ...currentEvent
        };
        let headers = {
            body: JSON.stringify(data),
            headers: {
                Authorization: '',
            }
        };
        return requester.put(url, headers);
    };

    return {
        register,
        login,
        logout,
        createEventPost,
        getAllEvents,
        getEvent,
        putEdit,
        joinPost,

    }
}();
