const EventEmitter = require('events');
const myEE = new EventEmitter();

myEE.on('foo', () => {
    console.log('I am here')
});

myEE.on('bar', () => {
});

const sym = Symbol('symbol');
myEE.on(sym, () => {
});

myEE.emit('foo');

console.log(myEE.eventNames());
// Prints: [ 'foo', 'bar', Symbol(symbol) ]