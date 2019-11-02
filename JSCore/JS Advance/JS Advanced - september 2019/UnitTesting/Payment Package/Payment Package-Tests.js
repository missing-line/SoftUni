let PaymentPackage = require('./Payment Package');

let expect = require('chai').expect;

describe('PaymentPackage', function () {

    it('should throw err with missing value ', function () {
        expect(() =>
            new PaymentPackage('HR Services'))
            .to.throw('Value must be a non-negative number');
    });

    it('should throw error with negative value', function () {
        expect(() =>
            new PaymentPackage('HR Services', -100))
            .to.throw('Value must be a non-negative number');
    });

    it('should throw err with != string - Name must be a non-empty string', function () {
        expect(() =>
            new PaymentPackage(-10, 100))
            .to.throw('Name must be a non-empty string');
    });

    it('should throw err with empty string - Name must be a non-empty string', function () {
        expect(() =>
            new PaymentPackage('', 100))
            .to.throw('Name must be a non-empty string');
    });

    it('should initialize correct ', function () {
        let pp = new PaymentPackage('HR Services', 1500);

        expect(pp.name).to.equal('HR Services');
        expect(pp.value).to.equal(1500);
        expect(pp.VAT).to.equal(20);
        expect(pp.active).to.equal(true);
    });

    it('should throw err with VAT - !== number', function () {
        let pp = new PaymentPackage('HR', 15000);
        expect(() =>
            pp.VAT = 'opa')
            .to.throw('VAT must be a non-negative number');
    });

    it('should throw err with VAT - < 0', function () {
        let pp = new PaymentPackage('HR', 15000);
        expect(() =>
            pp.VAT = -10)
            .to.throw('VAT must be a non-negative number');
    });

    it('should throw err with active != boolean', function () {
        let pp = new PaymentPackage('HR', 15000);
        expect(() =>
            pp.active = 2)
            .to.throw('Active status must be a boolean');
    });

    it('should throw err with active != boolean with null', function () {
        let pp = new PaymentPackage('HR', 15000);
        expect(() =>
            pp.active = null)
            .to.throw('Active status must be a boolean');
    });

    it('should return correct string', function () {
        const packages = [
            new PaymentPackage('HR Services', 1500),
        ];
        expect(packages.toString()).to.equal('Package: HR Services\n' +
            '- Value (excl. VAT): 1500\n' +
            '- Value (VAT 20%): 1800')
    });

    it('change active and still working', function () {
        let packages = new PaymentPackage('HR Services', 1500);
        packages.active = false;

        expect(packages.toString()).to.equal(
            'Package: HR Services (inactive)\n' +
            '- Value (excl. VAT): 1500\n' +
            '- Value (VAT 20%): 1800');
    });

    it('change VAT and still working ', function () {
        let packages = new PaymentPackage('HR Services', 150);
        packages.VAT = 10;
        expect(packages.toString()).to.equal('Package: HR Services\n' +
            '- Value (excl. VAT): 150\n' +
            '- Value (VAT 10%): 165');
    });

    it('should initialize correct with value 0 ', function () {
        let pp = new PaymentPackage('HR', 0);
        pp.VAT = 0;
        expect(pp.toString()).to.equal( 'Package: HR\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0');
    });


});
