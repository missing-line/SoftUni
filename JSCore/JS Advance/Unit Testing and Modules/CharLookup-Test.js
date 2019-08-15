const lookupChar = require('./CharLookup');

const  expect = require('chai').expect;

describe('lookupChar - Test',function () {
    it('should return undefined', function () {
        expect(lookupChar(4,0)).to.equal(undefined);
        expect(lookupChar([],0)).to.equal(undefined);
        expect(lookupChar(false,0)).to.equal(undefined);
        expect(lookupChar(Infinity,0)).to.equal(undefined);
        expect(lookupChar([],0)).to.equal(undefined);
        expect(lookupChar({},0)).to.equal(undefined);


        expect(lookupChar('string',[])).to.equal(undefined);
        expect(lookupChar('string',true)).to.equal(undefined);
        expect(lookupChar('string',{})).to.equal(undefined);
        expect(lookupChar('string',Infinity)).to.equal(undefined);
        expect(lookupChar('string','0')).to.equal(undefined);
    });

    it('should return Incorrect index', function () {
        expect(lookupChar('akg',-1)).to.equal('Incorrect index');
        expect(lookupChar('akg',4)).to.equal('Incorrect index');
        expect(lookupChar('akg',3)).to.equal('Incorrect index');
    });

    it('should correct index', function () {
        expect(lookupChar('akg',2)).to.equal('g');
    });
});