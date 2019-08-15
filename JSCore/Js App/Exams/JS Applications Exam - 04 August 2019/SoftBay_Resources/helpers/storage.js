const storage = function () {
    const appKey = 'kid_BkmL9NEmH';
    const appSecret = '9060c078e8674fd384e771c5740635cc';

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
        getUsername,
        appKey,
        appSecret,
    }
}();