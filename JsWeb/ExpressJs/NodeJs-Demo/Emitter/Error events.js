const MyEmitter = require('./baseEmmit');

const myEmitter = new MyEmitter();

myEmitter.on('event', function (a, b) {
    if (a === b) {
        myEmitter.emit('error', new Error('whoops!'));
    }
});

myEmitter.emit('event', 1, 1);

