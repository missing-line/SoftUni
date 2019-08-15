let Calculator = require('./calculator');

let expect = require('chai').expect;

describe('Calculator', function () {
    it('should initialization correct', function () {
        let cal = new Calculator();
        expect(cal.expenses.length).to.equal(0);
    });

    it('should add', function () {
        let cal = new Calculator();
        cal.add(10);
        cal.add("Pesho");
        expect(cal.expenses.length).to.equal(2);
    });

    it('should toString return emty', function () {
        let cal = new Calculator();
        let actual = cal.toString();
        expect(actual).to.equal('empty array');
    });
    it('should toString with values from arr', function () {
        let cal = new Calculator();
        cal.add(10);
        cal.add("Pesho");
        cal.add("5");
        let actual = cal.toString();
        expect(actual).to.equal('10 -> Pesho -> 5');
    });
    it('should return cant divine by zero', function () {
        let output = new Calculator();
        output.add(10);
        output.add("Pesho");
        output.add(0);
        output.add(2);
        let actual = output.divideNums();
        expect(actual).to.equal('Cannot divide by zero');
    });

    it('should divine correct', function () {
        let output = new Calculator();
        output.add(10);
        output.add("Pesho");
        output.add(5);
        output.add(2);
        let actual = output.divideNums();
        expect(actual).to.equal(1);
    });

    it('should throw Error', function () {
        let output = new Calculator();
        output.add("Pesho");
        expect(() => output.divideNums()).to.throw('There are no numbers in the array!');
    });

    it('should return empty', function () {
        let output = new Calculator();
        let actual = output.orderBy();
        expect(actual).to.equal('empty');
    });

    it('should orderBy correct', function () {
        let output = new Calculator();
        output.add(10);
        output.add(1);
        output.add("Pesho");
        output.add("5");
        let actual = output.orderBy();
        expect(actual).to.equal('1, 10, 5, Pesho');
    });
});