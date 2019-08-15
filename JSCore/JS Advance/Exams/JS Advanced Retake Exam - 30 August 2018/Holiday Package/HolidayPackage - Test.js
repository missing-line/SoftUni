let HolidayPackage = require('./Holiday Package');

let expect = require('chai').expect;

describe('HolidayPackage', function () {
    describe('constructor', function () {
        it('should initialization correct', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            expect(holidayPackage.destination).to.equal('Italy');
            expect(holidayPackage.season).to.equal('Summer');
            expect(holidayPackage.insuranceIncluded).to.equal(false);
            expect(holidayPackage.vacationers.length).to.equal(0);
        });
    });

    describe('showVacationers', function () {
        it('test with empty vacationers ', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            expect(holidayPackage.showVacationers()).to.equal('No vacationers are added yet');
        });
        it('test with non empty vacationers ', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            holidayPackage.addVacationer('Ivan Ivanov');
            expect(holidayPackage.showVacationers()).to.equal('Vacationers:\n' +
                'Ivan Ivanov');
        });
    });

    describe('addVacationer', function () {
        it('should add', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            holidayPackage.addVacationer('Petar Petrov');
            expect(holidayPackage.vacationers.length).to.equal(1);
        });

        it('should return Error', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            //Vacationer name must be a non-empty string
            expect(() =>
                holidayPackage.addVacationer(' ')).to.throw('Vacationer name must be a non-empty string')
        });

        it('should return Error', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            //Vacationer name must be a non-empty string
            expect(() =>
                holidayPackage.addVacationer( 1)).to.throw('Vacationer name must be a non-empty string')
        });

        it('should return Error', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            //Vacationer name must be a non-empty string
            expect(() =>
                holidayPackage.addVacationer('')).to.throw('Name must consist of first name and last name')
        });

        it('should return Error', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            //Vacationer name must be a non-empty string
            expect(() =>
                holidayPackage.addVacationer('Opa')).to.throw('Name must consist of first name and last name')
        });
    });

    describe('generateHolidayPackage',function () {
        it('should be correct', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            holidayPackage.addVacationer('Petar Petrov');
            holidayPackage.addVacationer('Georgi Georgiev');
            let expected = holidayPackage.generateHolidayPackage();
            expect(expected).to.equal('Holiday Package Generated\n' +
                'Destination: Italy\n' +
                'Vacationers:\n' +
                'Petar Petrov\n' +
                'Georgi Georgiev\n' +
                'Price: 1000')
        });

        it('should throw error', function () {
            let holidayPackage = new HolidayPackage('Italy', 'Summer');
            expect(() =>
                holidayPackage.generateHolidayPackage()).to.throw('There must be at least 1 vacationer added');
        });
    })
});