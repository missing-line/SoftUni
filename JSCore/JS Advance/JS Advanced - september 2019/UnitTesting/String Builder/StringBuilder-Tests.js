let StringBuilder = require('./String Builder');

let expect = require('chai').expect;
let assert = require('chai').assert;


describe('StringBuilder' , function () {

    it('should initialize correct', function () {
        let str = new StringBuilder('hello');
        expect(str._stringArray.length).to.equal(5);
    });

    it('should initialize correct with empty string', function () {
        let str = new StringBuilder('');
        expect(str._stringArray.length).to.equal(0);
        expect(str.toString()).to.equal('');
    });

    it('should append correct', function () {
        let str = new StringBuilder();
        str.append(', there');
        expect(str.toString()).to.equal(', there');
        expect(str._stringArray[str._stringArray.length - 1]).to.equal('e');
    });

    it('should prepend correct', function () {
        let str = new StringBuilder('hello');
        str.append(', there');
        str.prepend('User, ');
        expect(str.toString()).to.equal('User, hello, there');
    });

    it('should insertAt correct', function () {
        let str = new StringBuilder('hello');
        str.append(', there');
        str.prepend('User, ');
        str.insertAt('woop',5 );

        expect(str.toString()).to.equal('User,woop hello, there');
    });

    it('should  remove correct', function () {
        let str = new StringBuilder('hello');

        str.append(', there');
        str.prepend('User, ');
        str.insertAt('woop',5 );
        str.remove(6, 3);

        expect(str.toString()).to.equal('User,w hello, there');
    });

    it('should throw error ', function () {
        expect(() =>
            new StringBuilder(2)).to.throw('Argument must be string');
        expect(() =>
            new StringBuilder([])).to.throw('Argument must be string');
        expect(() =>
            new StringBuilder({})).to.throw('Argument must be string');
        expect(() =>
            new StringBuilder(true)).to.throw('Argument must be string');
    });


    it('should initialize array with undefined', function () {
        let str = new StringBuilder(undefined);
        expect(str._stringArray.length).to.equal(0);
    });

    it('should throw error append ,prepend ,insertAt ', function () {
        let str = new StringBuilder();

        expect(() =>
            str.append(1)).to.throw('Argument must be string');

        expect(() =>
            str.prepend(1)).to.throw('Argument must be string');

        expect(() =>
            str.insertAt(1, 1)).to.throw('Argument must be string');

    });

    it('should have the correct function properties', function () {
        assert.isFunction(StringBuilder.prototype.append);
        assert.isFunction(StringBuilder.prototype.prepend);
        assert.isFunction(StringBuilder.prototype.insertAt);
        assert.isFunction(StringBuilder.prototype.remove);
        assert.isFunction(StringBuilder.prototype.toString);
    });

});