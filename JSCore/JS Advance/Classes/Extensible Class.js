(function () {
    let id = 0;

    return class Extensible {
        constructor() {
            this.id = id++;
        }

        extend(template) {
            for (const func in template) {
                if (typeof template[func] === 'function') {
                    Extensible.prototype[func] = template[func];
                } else {
                    this[func] = template[func];
                }
            }
        }
    }
})();


let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);
