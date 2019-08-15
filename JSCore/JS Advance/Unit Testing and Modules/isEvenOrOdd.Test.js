const isOddOrEven = require('./EvenOrOdd');

let expect = require('chai').expect;

describe('isOddOrEven',function () {
    it('should return undefined', function () {
       expect(isOddOrEven(13)).to.equal(undefined);
       expect(isOddOrEven([])).to.equal(undefined);
       expect(isOddOrEven(true)).to.equal(undefined);
       expect(isOddOrEven({})).to.equal(undefined);
    });

    it('should return even', function () {
        expect(isOddOrEven('rage')).to.equal('even','Uncorrected result');
    });

    it('should return odd', function () {
        expect(isOddOrEven('try')).to.equal('odd','Uncorrected result');
    });
});