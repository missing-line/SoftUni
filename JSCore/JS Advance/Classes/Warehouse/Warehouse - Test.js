let Warehouse = require('./Warehouse');

let expect = require('chai').expect;
let assert = require('chai').assert;

describe('Warehouse', function () {
    it('should return correct initialization', function () {
        let house = new Warehouse(10);
        expect(house.capacity).to.equal(10);
    });

    it('should throw invalid capacity with negative', function () {

        expect(() => {
            throw new Warehouse(-1);
        }).to.throw('Invalid given warehouse space');
    });

    it('should throw invalid capacity with 0', function () {
        expect(() => {
            throw new Warehouse(0);
        }).to.throw('Invalid given warehouse space');
    });

    it('should throw invalid capacity with string', function () {
        expect(() => {
            throw new Warehouse('opa');
        }).to.throw('Invalid given warehouse space');
    });

    it('should return empty availableProducts', function () {
        let house = new Warehouse(10);
        let foodKeys = Object.keys(house.availableProducts.Food).length;
        expect(foodKeys).to.equal(0);
    });

    it('should throw There is not enough space or the warehouse is already full', function () {
        let house = new Warehouse(2);
        house.addProduct('Food', 'burger', 2);
        expect(() => {
            throw house.addProduct('Food', 'burger', 1)
        }).to.throw('There is not enough space or the warehouse is already full');
    });

    it('should add correct ', function () {
        let house = new Warehouse(10);
        let result = JSON.stringify(house.addProduct('Food', 'burger', 2));
        expect(result).to.equal('{"burger":2}');
    });

    it('should orderProducts correct', function () {
        let house = new Warehouse(10);
        house.addProduct('Food', 'burger', 2);
        house.addProduct('Food', 'EGG', 4);
        let firstProduct = house.orderProducts('Food');
        let keys = Object.keys(firstProduct);
        expect(keys[0]).to.equal('EGG');
        expect(house.availableProducts.Food[keys[0]]).to.equal(4);
    });

    it('should orderProducts correct', function () {
        let house = new Warehouse(10);
        house.addProduct('Drink', 'cola', 2);
        house.addProduct('Drink', 'milk', 4);
        let firstProduct = house.orderProducts('Drink');
        let keys = Object.keys(firstProduct);
        expect(keys[0]).to.equal('milk');
        expect(house.availableProducts.Drink[keys[0]]).to.equal(4);
    });

    it('should return revision correct', function () {
        let house = new Warehouse(120);
        house.addProduct('Food', 'burger', 2);
        house.addProduct('Food', 'neshto si', 4);
        house.addProduct('Drink', 'cola', 1);
        house.addProduct('Drink', 'milk', 2);
        house.orderProducts('Food');
        house.orderProducts('Drink');
        let result = house.revision();
        expect(result).to.equal(`Product type - [Food]\n- neshto si 4\n- burger 2\nProduct type - [Drink]\nmilk 2\ncola 1`);
    });

    it('should return revison is empty', function () {
        let house = new Warehouse(120);
        house.addProduct('Food', 'burger', 2);
        house.scrapeAProduct('burger',2);
        let result = house.revision();
        expect(result).to.equal('The warehouse is empty');
    });

    it('should return product do not exists', function () {
        let house = new Warehouse(120);
        expect(() => {
            throw house.scrapeAProduct('cola', 1);
        }).to.throw('cola do not exists');
    });

    it('should return correct scrapeAProduct', function () {
        let house = new Warehouse(120);
        house.addProduct('Drink', 'cola', 1);
        let result = JSON.stringify(house.scrapeAProduct('cola',2));
        expect(result).to.equal('{"cola":0}');
    });

    it('should return correct scrapeAProduct', function () {
        let house = new Warehouse(120);
        house.addProduct('Drink', 'cola', 5);
        let result = JSON.stringify(house.scrapeAProduct('cola',2));
        expect(result).to.equal('{"cola":3}');
    });

    it('should return correct from occupiedCapacity', function () {
        let house = new Warehouse(120);
        house.addProduct('Drink', 'cola', 1);
        house.addProduct('Food', 'burger', 1);
        house.addProduct('Food', 'egg', 1);
        house.scrapeAProduct('cola',2);
        expect(house.occupiedCapacity()).to.equal(2);
    });
});


