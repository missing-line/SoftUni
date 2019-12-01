const MyEmitter = require('./baseEmmit');

const myEmitter = new MyEmitter();

myEmitter.once('newListener', (event, listener) => {
    if (event === 'event') {
        myEmitter.on('event', () => {
            console.log('B');
        });
    }
});

myEmitter.on('event', () => {
    console.log('A');
});

myEmitter.on('event', () => {
    console.log('C');
});


myEmitter.emit('event');


