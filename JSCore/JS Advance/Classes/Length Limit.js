class Stringer{
    constructor(name, capacity) {
        this.innerString  = name;
        this.innerLength = capacity;
    }

    decrease(value) {
        this.innerLength -= value;
        if (this.innerLength < 0)
            this.innerLength = 0;
    }

    increase(value) {
        this.innerLength += value;

    }
    toString () {
        if (this.innerLength === 0)
            return '...';
        if (this.innerString .length > this.innerLength)
               return this.innerString .substring(0, this.innerLength) + '...';

        return this.innerString
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
