let PizzUni = require('./02. PizzUni_Ресурси');

let expect = require('chai').expect;

describe('PizzUni', function () {
    describe('constructor', function () {
        it('should initialization correct', function () {
            let pizzi = new PizzUni();
            expect(pizzi.registeredUsers.length).to.equal(0);
            expect(pizzi.orders.length).to.equal(0);
            expect(pizzi.availableProducts.pizzas.length).to.equal(3);
            expect(pizzi.availableProducts.drinks.length).to.equal(3);
        });
    });

    describe('registerUser', function () {
        it('should reg correct', function () {
            let pizzi = new PizzUni();
            let actual = JSON.stringify(pizzi.registerUser('string'));
            expect(actual).to.equal('{"email":"string","orderHistory":[]}');
        });

        it('should throw ', function () {
            let pizzi = new PizzUni();
            pizzi.registerUser('string');
            expect(() => pizzi.registerUser('string')).to.throw(`This email address (string) is already being used!`);
        });
    });

    describe('makeOrder', function () {
        it('should throw with non find email', function () {
            let pizzi = new PizzUni();
            expect(() => pizzi.makeAnOrder('string', 'orderedPizza', 'orderedDrink')).to.throw(`You must be registered to make orders!`);
        });

        it('should throw with non find pizza', function () {
            let pizzi = new PizzUni();
            pizzi.registerUser('string');
            expect(() => pizzi.makeAnOrder('string', 'orderedPizza', 'orderedDrink')).to.throw(`You must order at least 1 Pizza to finish the order.`);
        });

        it('should throw with non find pizza', function () {
            let pizzi = new PizzUni();
            pizzi.registerUser('string');
            let actual = pizzi.makeAnOrder('string', 'Italian Style', 'orderedDrink');
            expect(actual).to.equal(0);
        });
    });

    describe('detailsAboutMyOrder', function () {
        it('should return pending', function () {
            let pizzi = new PizzUni();
            pizzi.registerUser('string');
            pizzi.makeAnOrder('string', 'Italian Style', 'orderedDrink');
            let actual = pizzi.detailsAboutMyOrder(0);
            expect(actual).to.equal('Status of your order: pending');
        });

        it('should return undefined with negative index', function () {
            let pizzi = new PizzUni();
            let actual = pizzi.detailsAboutMyOrder(-1);
            expect(actual).to.equal(undefined);
        });
    });

    describe('completeOrder', function () {
        it('should return jsonObject', function () {
            let pizzi = new PizzUni();
            pizzi.registerUser('string');
            pizzi.makeAnOrder('string', 'Italian Style', 'orderedDrink');
            pizzi.detailsAboutMyOrder(0);
            let actual = JSON.stringify(pizzi.completeOrder());
            expect(actual).to.equal('{"orderedPizza":"Italian Style","email":"string","status":"completed"}');
        });

        it('should return jsonObject', function () {
            let pizzi = new PizzUni();
            pizzi.registerUser('string');
            pizzi.makeAnOrder('string', 'Italian Style', 'orderedDrink');
            pizzi.completeOrder();
            pizzi.registerUser('email');
            pizzi.makeAnOrder('email', 'Classic Margherita', 'Fanta');
            let actual = JSON.stringify(pizzi.completeOrder());
            expect(actual).to.equal('{"orderedPizza":"Classic Margherita","orderedDrink":"Fanta","email":"email","status":"completed"}');
        });
    });

    it('should return object when searching and find user', function () {
        let pizzi = new PizzUni();

        pizzi.registerUser('string');
        pizzi.makeAnOrder('string', 'Italian Style', 'orderedDrink');

        pizzi.detailsAboutMyOrder(0);
        pizzi.completeOrder();
        let actual = pizzi.doesTheUserExist('string').orderHistory[0];
        expect(typeof actual).to.equal('object')
    });

});


