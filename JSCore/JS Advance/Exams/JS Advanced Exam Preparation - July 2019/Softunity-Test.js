let SoftUniFy = require('./03. Softunify');

let expect = require('chai').expect;

describe('SoftUniFy', function () {
    describe('constructor', function () {
        it('should initialization correctly', function () {
            let soft = new SoftUniFy();
            expect(Object.entries(soft.allSongs).length).to.equal(0);
        });
    })

    describe('downloading song',function () {
        it('should return correct object', function () {
            let sofunify = new SoftUniFy();
            sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            let actual = JSON.stringify(sofunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...'));
            let expected = '{"allSongs":{"Eminem":{"rate":0,"votes":0,"songs":["Phenomenal - IM PHENOMENAL...","Venom - Knock, Knock let the devil in..."]}}}';
            expect(actual).to.equal(expected);
        });
    })

    describe('rateArtist',function () {
        it('should return no found artist', function () {
            let sofunify = new SoftUniFy();
            let actual = sofunify.rateArtist('Eminem',50);
            let actual1 = sofunify.rateArtist('Eminem');
            expect(actual).to.equal('The Eminem is not on your artist list.');
            expect(actual1).to.equal('The Eminem is not on your artist list.');
        });
        it('should return 50 rate', function () {
            let sofunify = new SoftUniFy();
            sofunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            let actual = sofunify.rateArtist('Eminem',50);
            expect(actual).to.equal(50);
        });
        it('should return 0 rate', function () {
            let sofunify = new SoftUniFy();
            sofunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            let actual = sofunify.rateArtist('Eminem','aa');
            expect(actual).to.equal(0);
        });
        it('should artits isnt found', function () {
            let sofunify = new SoftUniFy();
            let actual = sofunify.rateArtist('Eminem');
            expect(actual).to.equal('The Eminem is not on your artist list.');
        });
    })
    
    describe('songsList',function () {
        it('should return 3 songs', function () {
            let sofunify = new SoftUniFy();

            sofunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            sofunify.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');
            let actual = sofunify.songsList;
            let expected = 'Venom - Knock, Knock let the devil in...\n' +
                'Phenomenal - IM PHENOMENAL...\n' +
                'Light Me On Fire - You can call me a liar.. ';
            expect(actual).to.equal(expected);
        });

        it('should return empty list', function () {
            let sofunify = new SoftUniFy();
            expect(sofunify.songsList).to.equal('Your song list is empty');
        });
    })

    describe('playsong',function () {
        it('should return song', function () {
            let sofunify = new SoftUniFy();
            sofunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
            sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
            sofunify.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');

            let actual = 'Eminem:\n' +
                'Venom - Knock, Knock let the devil in...\n';
            expect(sofunify.playSong('Venom')).to.equal(actual);
        });
    })
});