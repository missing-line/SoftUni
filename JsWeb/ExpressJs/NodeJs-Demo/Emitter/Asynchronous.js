const EventEmitter  = require('events');

class  MyEmitter extends  EventEmitter{}

const myEmitter = new MyEmitter();

myEmitter.on('event', (a, b) => {
    console.log(a);

    setImmediate(() => {
        console.log('this happens asynchronously');
    });

    console.log(b);
});

myEmitter.emit('event', 'a', 'b');