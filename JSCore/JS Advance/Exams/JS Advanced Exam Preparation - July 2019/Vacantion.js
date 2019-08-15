class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    get numberOfChildren() {
        let allKids = 0;
        for (let key in this.kids) {
            allKids += this.kids[key].length;
        }

        return allKids;
    }

    registerChild(name, grade, budget) {

        if (budget < this.budget)
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;

        if (!this.kids.hasOwnProperty(grade)) {
            this.kids[grade] = [];
        }

        let find = this.kids[grade].findIndex(x => x.name === name);

        if (find === -1) {
            this.kids[grade].push({name, budget});
            let names = [];
            for (let key of this.kids[grade]) {
                names.push(`${key.name}-${key.budget}`)
            }
            return names
        }
        return `${name} is already in the list for this ${this.destination} vacation.`;
    }

    removeChild(name, grade) {

        if (this.kids.hasOwnProperty(grade)) {
            let find = this.kids[grade].findIndex(x => x.name === name);
            if (find !== -1) {
                this.kids[grade].splice(find, 1);
                let names = [];
                for (let key of this.kids[grade]) {
                    names.push(`${key.name}-${key.budget}`)
                }
                return names;
            }
        }

        return `We couldn't find ${name} in ${grade} grade.`;
    }

    toString() {
    l.hasOwnProperty()
        if (this.numberOfChildren === 0) {
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`
        }
        let keys = Object.keys(this.kids);
        let result = '';
        result += `${this.organizer} will take ${this.numberOfChildren} children on trip to ${this.destination}\n`;
        for (let key of keys) {
            result += `Grade: ${key}\n`;
            let count = 1;
            for (let value of this.kids[key]) {
                result += `${count++}. ${value.name}-${value.budget}\n`;
            }
        }
        return result;
    }
}


