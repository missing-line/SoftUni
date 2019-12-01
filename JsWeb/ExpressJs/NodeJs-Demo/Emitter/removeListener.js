const MyEmitter = require('./baseEmmit');
const myEmitter = new MyEmitter();

const callbackA = () => {
    console.log('A');
    myEmitter.removeListener('event', callbackB); // remove , but will call one time..
};

const callbackB = () => {
    console.log('B');
};

myEmitter.on('event', callbackA);

myEmitter.on('event', callbackB);


myEmitter.emit('event');

myEmitter.emit('event');
