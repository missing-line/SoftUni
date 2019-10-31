let BookStore = require('./02. Book Store_Ресурси');

let expect = require('chai').expect;
let assert = require('chai').assert;

describe('BookStore', function () {

    describe('constructor', function () {
        it('should return correct store name', function () {
            let bookStore = new BookStore('BookStore');

            expect(bookStore.name).to.equal('BookStore');
        });

        it('should return empty this.books', function () {
            let bookStore = new BookStore('BookStore');

            expect(bookStore.books.length).to.equal(0);
        });

        it('should return empty this._workers', function () {
            let bookStore = new BookStore('BookStore');

            expect(bookStore.workers.length).to.equal(0);
        });
    });
    
    describe('fill correctly array from books-Authors', function () {
        it('should return 4 books', function () {
            let array = ['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear'];

            let bookStore = new BookStore('BookStore');
            bookStore.stockBooks(array);

            expect(bookStore.books.length).to.equal(4);
        });
    });
    
    describe('hire', function () {
        it('should return correctly msg with new worker', function () {
            let store = new BookStore('Store');
            let msg = 'George started work at Store as seller';
            let actual = store.hire('George', 'seller');

            expect(actual).to.equal(msg);
        });

        it('should throw err with hired worker', function () {
            let store = new BookStore('Store');
            store.hire('George', 'seller');

            expect(() =>
                store.hire('George', 'seller')).to.throw('This person is our employee');
        });

    });

    describe('fire', function () {
        it('should return name if is fired', function () {
            let store = new BookStore('Store');
            store.hire('George', 'seller');

            expect(store.fire('George')).to.equal(`George is fired`);
        });

        it('should throw err non exist worker', function () {
            let store = new BookStore('Store');
            store.hire('George', 'seller');

            expect(() =>
                store.fire('Tom').to.throw('Tom doesn\'t work here'));
        });
    });

    describe('printWorkers and sellBooks', function () {
        it('should print correct', function () {
            let store = new BookStore('Store');
            store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);
            store.hire('George', 'seller');
            store.hire('Ina', 'seller');
            store.hire('Tom', 'juniorSeller');
            store.sellBook('Inferno', 'Ina');
            store.fire('Tom');

            let expected = 'Name:George Position:seller BooksSold:0\nName:Ina Position:seller BooksSold:1';

            expect(store.printWorkers()).to.equal(expected);
        });

        it('should throw err not found worker', function () {
            let store = new BookStore('Store');
            store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);
            store.hire('George', 'seller');
            store.hire('Ina', 'seller');
            store.hire('Tom', 'juniorSeller');
            store.sellBook('Inferno', 'Ina');

            expect(() =>
                store.sellBook('Harry Potter', 'Ina1')).to.throw(`Ina1 is not working here`);
        });

        it('should throw err with not found book', function () {
            let store = new BookStore('Store');
            store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);
            store.hire('George', 'seller');
            store.hire('Ina', 'seller');
            store.hire('Tom', 'juniorSeller');

            expect(() =>
                store.sellBook('Inferno1', 'Ina')).to.throw('This book is out of stock');
        });

        it('should return empty string', function () {
            let store = new BookStore('Store');
            expect(store.printWorkers()).to.equal('');
        });

        it('should  correct count of sell books', function () {

            let store = new BookStore('Store');
            store.stockBooks(['Inferno-Dan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);
            store.hire('Ina', 'seller');
            store.sellBook('Inferno', 'Ina');

            let sells = store.workers.find(x => x.name = 'Ina').booksSold;

            expect(sells).to.equal(1);
        });


    });

    it('should return undefined author', function () {
        let store = new BookStore('Store');
        store.stockBooks(['InfernoDan Braun', 'Harry Potter-J.Rowling', 'Uncle Toms Cabin-Hariet Stow', 'The Jungle-Upton Sinclear']);

        expect(store.books.find(x => x.title === 'InfernoDan Braun').author).to.equal(undefined);
    });

    it(' object => object ', function () {
        let store = new BookStore('Store');
        store.stockBooks(['Inferno-Dan Braun', 'Uncle Toms Cabin-Hariet Stow']);

        store.hire('George', 'seller');
        store.hire('Ina', 'seller');
        store.hire('Tom', 'juniorSeller');

        store.sellBook('Inferno', 'Ina');

        let actual = store.stockBooks(['Uncle Toms Cabin-Hariet Stow']);
        let expected = '[object Object],[object Object]';

        assert.equal(actual, expected);
        //expect(actual).to.equal(expected);
    });
});

