let AutoService = require('./02. AutoService');

let expect = require('chai').expect;


describe('AutoService', function () {
    describe('constructor', function () {
        it('should initialization correct', function () {
            let service = new AutoService(2);
            expect(service.garageCapacity).equal(2);
            expect(service.workInProgress.length).equal(0);
            expect(service.backlogWork.length).equal(0);
        });
    });

    describe('signUpForReview', function () {
        it('should push in the workInProgress ', function () {
            let services = new AutoService(2);
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken'
            });
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken'
            });
            expect(services.workInProgress.length).to.equal(2);
        });

        it('should push in the backlogWork ', function () {
            let services = new AutoService(0);
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken'
            });
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken'
            });
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken'
            });
            expect(services.backlogWork.length).to.equal(3);
        });
    });

    describe('carInfo', function () {

        it('should return car', function () {
            let services = new AutoService(2);
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken'
            });
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken',
                'wheels': 'broken',
                'tires': 'broken'
            });
            services.signUpForReview('Philip', 'PB4321PB', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'exaustPipe': 'REMUS'
            });

            let result = services.carInfo('PB4321PB', 'Philip');
            expect(result.clientName).to.equal('Philip');
            expect(result.plateNumber).to.equal('PB4321PB');
        });

        it('should ', function () {
            let services = new AutoService(2);
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken'
            });
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken',
                'wheels': 'broken',
                'tires': 'broken'
            });
            services.signUpForReview('Philip', 'PB4321PB', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'exaustPipe': 'REMUS'
            });

            let result = services.carInfo('PB9999PB', 'PHILIPS');
            expect(result).to.equal('There is no car with platenumber PB9999PB and owner PHILIPS.')
        });

    });

    describe('repairCar tester', function () {
        it('should return empty clients', function () {
            let services = new AutoService(2);
            services.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken',
                'wheels': 'broken',
                'tires': 'broken'
            });
            services.repairCar();
            expect(services.repairCar()).to.equal('No clients, we are just chilling...');
        });

        it('should return car is repaired', function () {
            let autoService = new AutoService(2);

            autoService.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken',
                'wheels': 'broken',
                'tires': 'broken'
            });
            expect(autoService.repairCar()).to.equal('Your doors and wheels and tires were repaired.');
        });

        it('should return car isn\'t need to be repaired', function () {
            let autoService = new AutoService(2);
            autoService.signUpForReview('Peter', 'CA1234CA', {'engine': 'MFRGG23', 'transmission': 'FF4418ZZ'});
            autoService.signUpForReview('Peter', 'CA1234CA', {
                'engine': 'MFRGG23',
                'transmission': 'FF4418ZZ',
                'doors': 'broken',
                'wheels': 'broken',
                'tires': 'broken'
            });
            expect(autoService.repairCar()).to.equal('Your car was fine, nothing was repaired.');
        });

        it('should be empty arrays after repairCar ', function () {
            let autoService = new AutoService(1);
            autoService.signUpForReview('Peter', 'CA1234CA', {'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'fine', 'wheels': 'fine', 'tires': 'fine'});
            autoService.signUpForReview('Opa', 'PB4321PB', {'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'exaustPipe': 'broken'});
            autoService.repairCar();
            let rs = autoService.repairCar();
            expect(rs).to.equal('Your exaustPipe were repaired.');
            expect(autoService.workInProgress.length).to.equal(0);
            expect(autoService.backlogWork.length).to.equal(0);
        });

        it ('should return the car if it is in workInProgress',function() {
            let autoService = new AutoService(4);
            autoService.signUpForReview('Peter', 'CA1234CA', { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken', 'wheels': 'broken', 'tires': 'broken' });
            let actual = autoService.carInfo('CA1234CA', 'Peter');
            let expected = {'plateNumber': 'CA1234CA', 'clientName': 'Peter', 'carInfo': { 'engine': 'MFRGG23', 'transmission': 'FF4418ZZ', 'doors': 'broken', 'wheels': 'broken', 'tires': 'broken' }};
            expect(actual).to.equal(expected);
        });
    });
});


