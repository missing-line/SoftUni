const MyEmitter = require('./baseEmmit');

const myEE = new MyEmitter();

myEE.on('foo', () => console.log('a'));

myEE.prependListener('foo', () => console.log('b'));

myEE.prependListener('foo', () => console.log('x'));

myEE.on('foo', () => console.log('c'));

myEE.emit('foo');
