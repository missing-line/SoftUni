function validateRequest(object) {
    function missingProperty(object) {
        if (!object.hasOwnProperty('method')) {
            throw new Error('Invalid request header: Invalid Method');
        }
        if (!object.hasOwnProperty('uri')) {
            throw new Error('Invalid request header: Invalid URI');
        }
        if (!object.hasOwnProperty('version')) {
            throw new Error('Invalid request header: Invalid Version');
        }
        if (!object.hasOwnProperty('message')) {
            throw new Error('Invalid request header: Invalid Message');

        }
    }

    missingProperty(object);
    //GET, POST, DELETE or CONNECT
    if (object.method !== 'GET' &&
        object.method !== 'POST' &&
        object.method !== 'DELETE' &&
        object.method !== 'CONNECT') {

        throw new Error('Invalid request header: Invalid Method');
    }
    if (object.uri === '') {
        throw new Error('Invalid request header: Invalid URI');
    }
    if (object.uri) {
        const regex = /^([\w.]+)$/gm;
        if (!(regex.test(object.uri) || object.uri === '*')) {
            throw new Error('Invalid request header: Invalid URI');
        }

    }
    //HTTP/0.9, HTTP/1.0, HTTP/1.1 or HTTP/2.0
    if (object.version !== 'HTTP/0.9' &&
        object.version !== 'HTTP/1.0' &&
        object.version !== 'HTTP/1.1' &&
        object.version !== 'HTTP/2.0') {

        throw new Error('Invalid request header: Invalid Version');
    }
    if (object.message) {
        let regex = /[<>\\&'"]/g;
        if (regex.test(object.message))
            throw new Error('Invalid request header: Invalid Message');
    }

    return object;
}


console.log(validateRequest({
    method: 'GET',
    uri: 'kkk jjjj',
    version: 'HTTP/0.8',
    message: ''
}));