let manager = (function () {

    const obj = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };

    const receipt = {
        apple: {carbohydrate: 1, flavour: 2},
        lemonade: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        eggs: {protein: 5, fat: 1, flavour: 1,},
        turkey: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10,}
    };


    return function (input) {
        let arr = input.split(' ');
        let command = arr[0];
        let product = arr[1];
        let quantity = +arr[2];

        if (command === 'restock') {
            obj[product] += quantity;
            return 'Success';

        } else if (command === 'prepare') {
            const curr = {};

            for (let key in receipt[product]) {
                curr[key] = quantity * receipt[product][key];
                if (curr[key] > obj[key]){
                    return `Error: not enough ${key} in stock`;
                }
            }
            for (let key in curr){
                obj[key] -= curr[key];
            }
            return 'Success';
        } else {
            let report = [];
            for (let key in obj) {
                report.push(`${key}=${obj[key]}`);
            }
            return report.join(' ');
        }
    };
})();
console.log(manager('restock protein 100'));
console.log(manager('restock carbohydrate 100'));
console.log(manager('restock fat 100'));
console.log(manager('restock flavour 100'));
console.log(manager('report'));
console.log(manager('prepare apple 2'));
console.log(manager('report'));
console.log(manager('prepare apple 1'));
console.log(manager('report'));

//   ['restock protein 100', 'Success'],
//   ['restock carbohydrate 100', 'Success'],
//   ['restock fat 100', 'Success'],
//   ['restock flavour 100', 'Success'],
//   ['report', 'protein=100 carbohydrate=100 fat=100 flavour=100'],
//   ['prepare apple 2', 'Success'],
//   ['report', 'protein=100 carbohydrate=98 fat=100 flavour=96'],
//   ['prepare apple 1', 'Success'],
//   ['report', 'protein=100 carbohydrate=97 fat=100 flavour=94']