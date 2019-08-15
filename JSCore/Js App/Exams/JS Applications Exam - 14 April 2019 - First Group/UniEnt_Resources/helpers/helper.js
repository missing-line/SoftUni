const helper = function () {
    const handler = function (response) {

        if (response.status >= 400) {
            helper.notify('errorBox', 'Error data!');
            throw new Error('Invalid data!');
        }
        if (response.status !== 204) {
            response = response.json();
        }

        return response;
    };

    const notify = function (id, message) {
        let box = document.getElementById(id);
        box.style.display = 'block';
        box.textContent = message;
    };

    const stopNotify = function () {
        Array.from(document.getElementById('notifications').children)
            .forEach(x => {
                x.style.display = 'none';
            })
    };
    return {
        handler,notify,stopNotify
    }
}();
