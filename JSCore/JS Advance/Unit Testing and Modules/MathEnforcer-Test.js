let mathEnforcer = require('./Math Enforcer');

let expect = require('chai').expect;

describe('mathEnforcer Test', function () {
    it('should return undefined', function () {
        expect(mathEnforcer.addFive('4')).to.equal(undefined);
        expect(mathEnforcer.subtractTen('4')).to.equal(undefined);
        expect(mathEnforcer.sum('4')).to.equal(undefined);
        expect(mathEnforcer.sum('4',5)).to.equal(undefined);
        expect(mathEnforcer.sum(4,'1')).to.equal(undefined);
        expect(mathEnforcer.sum([],4)).to.equal(undefined);
        expect(mathEnforcer.sum(4,{})).to.equal(undefined);
        expect(mathEnforcer.sum(4,true)).to.equal(undefined);
        expect(mathEnforcer.sum('4.4',true)).to.equal(undefined);
    });

    it('should return  correct subtraction , second is -10 by default', function () {
        expect(mathEnforcer.subtractTen(4)).to.equal(-6);
        expect(mathEnforcer.subtractTen(10)).to.equal(0);
        expect(mathEnforcer.subtractTen(11)).to.equal(1);
        expect(mathEnforcer.subtractTen(10.5)).to.equal(0.5);
        expect(mathEnforcer.subtractTen(-10.5)).to.equal(-20.5);
        expect(mathEnforcer.subtractTen(Math.abs(-4))).to.equal(-6);
    });

    it('should return correct sum of 2 numbers, second is 5 by default', function () {
        expect(mathEnforcer.addFive(4)).to.equal(9);
        expect(mathEnforcer.addFive(14)).to.equal(19);
        expect(mathEnforcer.addFive(0)).to.equal(5);
        expect(mathEnforcer.addFive(-1)).to.equal(4);
        expect(mathEnforcer.addFive(5.5)).to.equal(10.5);
        expect(mathEnforcer.addFive(Math.abs(-1))).to.equal(6);
    });

    it('should correct sum of 2 diff numbers ', function () {
        expect(mathEnforcer.sum(4,5)).to.equal(9);
        expect(mathEnforcer.sum(4,-5)).to.equal(-1);
        expect(mathEnforcer.sum(4,0)).to.equal(4);
        expect(mathEnforcer.sum(4,10.4)).to.equal(14.4);
        expect(mathEnforcer.sum(4.4,0)).to.equal(4.4);
        expect(mathEnforcer.sum(Math.abs(-1),0)).to.equal(1);
        expect(mathEnforcer.sum(Math.abs(-1),Math.abs(-1))).to.equal(2);
        expect(mathEnforcer.sum(-4,Math.abs(-1))).to.equal(-3);
        expect(mathEnforcer.sum(1,Math.pow(2,3))).to.equal(9);
    });
});

