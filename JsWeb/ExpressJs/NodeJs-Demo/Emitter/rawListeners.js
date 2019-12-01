const MyEmitter = require('./baseEmmit');

const emitter = new MyEmitter();

emitter.once('log', () => console.log('log once'));

const listeners = emitter.rawListeners('log');

const logFnWrapper = listeners[0];

logFnWrapper.listener();

logFnWrapper();

emitter.on('log', () => console.log('log persistently'));

const newListeners = emitter.rawListeners('log');

newListeners[0]();
emitter.emit('log');