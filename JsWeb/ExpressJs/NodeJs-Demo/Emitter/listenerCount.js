const EventEmitter  = require('events');

class  MyEmitter extends  EventEmitter{}

const myEmitter = new MyEmitter();

myEmitter.on('event', () => {});

myEmitter.on('event', () => {});

console.log(EventEmitter.listenerCount(myEmitter, 'event'));

console.log(myEmitter.listenerCount( 'event'));
