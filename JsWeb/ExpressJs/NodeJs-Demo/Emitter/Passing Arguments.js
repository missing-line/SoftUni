const EventEmitter  = require('events');

class  MyEmitter extends  EventEmitter{}

const myEmitter = new MyEmitter(); // instance

myEmitter.on('event', function(a, b) {
    console.log(a, b, this, this === myEmitter);
});

myEmitter.emit('event', 'a', 'b');