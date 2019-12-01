const MyEmitter =  require('./baseEmmit');

const myEmitter = new MyEmitter();

let m = 0;

myEmitter.once('event', () => {
    console.log(++m);
});
myEmitter.emit('event');
// Prints: 1
myEmitter.emit('event');
// Ignored ... // unregistered ...

