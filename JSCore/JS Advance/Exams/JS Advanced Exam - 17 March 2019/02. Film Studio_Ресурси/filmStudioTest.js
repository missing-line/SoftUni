let FilmStudio = require('./FilmStudio');

let expect = require('chai').expect;
let assert = require('chai').assert;

describe('FilmStudio', function () {
    describe('constructor', function () {
        it('should ', function () {
            let studio = new FilmStudio('SU');
            expect(studio.name).to.equal('SU');
            expect(studio.films.length).to.equal(0);
        });
    });

    describe('makingMovie', function () {
        it('making movie for a first time ', function () {
            let studio = new FilmStudio('SU');
            let movie = studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

            expect(movie.filmName).to.equal('The Avengers');
            expect(movie.filmRoles.length).to.equal(4);
        });
        it('should return series ', function () {
            let studio = new FilmStudio('SU');
            studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            let movie = studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);
            expect(movie.filmName).to.equal('The Avengers 2');
            expect(movie.filmRoles.length).to.equal(4);
        });
        it('should throw error with invalid arguments', function () {
            let studio = new FilmStudio('SU');
            expect(() =>
                studio.makeMovie('The Avengers', {})).to.throw('Invalid arguments');
        });
        it('should throw error with invalid arguments', function () {
            let studio = new FilmStudio('SU');
            expect(() =>
                studio.makeMovie('Iron-Man', 'Thor', 'Hulk', 'Arrow guy')).to.throw('Invalid arguments');
        });

        it('should throw error with invalid arguments count', function () {
            let studio = new FilmStudio('SU');
            expect(() =>
                studio.makeMovie('test')).to.throw('Invalid arguments count');
        });

    });

    describe('casting', function () {
        it('should  missing movie', function () {
            let studio = new FilmStudio('SU');
            expect(studio.casting('Johny', 'Hulk')).to.equal('There are no films yet in SU.');
        });

        it('should  missing role', function () {
            let studio = new FilmStudio('SU');
            studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Arrow guy']);
            expect(studio.casting('Johny', 'Hulk')).to.equal('Johny, we cannot find a Hulk role...');
        });
        it('should find correct movie, role', function () {
            let studio = new FilmStudio('SU');
            studio.makeMovie('The Avengers', ['Iron-Man', 'Thor', 'Arrow guy']);
            expect(studio.casting('Johny', 'Thor')).to.equal('You got the job! Mr. Johny you are next Thor in the The Avengers. Congratz!');
        });
    });

    describe('lookForProducer', function () {
        it('with existing film', function () {
            let studio = new FilmStudio('SU');
            let filmName = 'The Avengers';
            studio.makeMovie(filmName, ['Iron-Man', 'Thor', 'Hulk', 'Arrow guy']);

            let result = studio.lookForProducer(filmName);
            let expected = `Film name: The Avengers\nCast:\nfalse as Iron-Man\nfalse as Thor\nfalse as Hulk\nfalse as Arrow guy\n`;
            expect(result).to.equal(expected);
        });

        it('should return throw error', function () {
            let studio = new FilmStudio('SU');
            //assert.throws(() => studio.lookForProducer('test'), Error,/test do not exist yet, but we need the money.../);
            expect(() => studio.lookForProducer('test')).to.throw(Error,/test do not exist yet, but we need the money.../);
        });
    })
});
