class Rat {

    constructor(name) {
        this.name = name;
        this.unites = [];
    }

    unite(otherRat) {
        if (typeof (otherRat) === 'object')
            this.unites.push(otherRat);
    }

    getRats() {
        return this.unites;
    }

    toString() {

        let namesOfRats = '';
        if (this.unites) {
            for (let name of this.unites) {
                namesOfRats += `##${name.name}\n`;
            }
        }

        return `${this.name}\n${namesOfRats}`;
    }
}

let firstRat = new Rat("Peter");
console.log(firstRat.toString()); // Peter

console.log(firstRat.getRats()); // []

firstRat.unite(new Rat("George"));
firstRat.unite(new Rat("Alex"));
console.log(firstRat.getRats());
// [ Rat { name: 'George', unitedRats: [] },
//  Rat { name: 'Alex', unitedRats: [] } ]
console.log(firstRat.getRats().length);
console.log(firstRat.toString());
// Peter
// ##George
// ##Alert
console.log(typeof (firstRat));