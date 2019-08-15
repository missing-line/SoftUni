const storage = function () {
    const appKey = 'kid_SJs32E0GB';
    const appSecret = 'ad8bd0cb93164a04922abdf9b575a2f0';

    const getData = function (key) {
        return localStorage.getItem(key + appKey)
    };

    const getUsername = function (key) {
        return localStorage.getItem(key)
    };

    const saveData = function (key, value) {
        localStorage.setItem(key + appKey, JSON.stringify(value));
    };

    const saveUser = function (data) {
        saveData('userInfo', data);
        saveData("authToken", data._kmd.authtoken);
    };

    const deleteUser = function () {
        localStorage.removeItem("userInfo" + appKey);
        localStorage.removeItem("authToken" + appKey);
    };

    const isLogIn = async function (context) {
        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }
        return loggedIn;
    };


    return {
        getData,
        saveData,
        saveUser,
        deleteUser,
        isLogIn,
        appKey,
        appSecret,
        getUsername,
    }
}();