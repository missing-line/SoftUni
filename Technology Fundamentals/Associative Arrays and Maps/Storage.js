function solve(input) {
    let map = new Map();
    for (let i = 0; i < input.length; i++) {
        let curr = input[i].split(' ');
        let product = curr[0];
        let quantity = Number(curr[1]);
        if (!map.has(product)) {
            map.set(product, quantity);
        }
        else {
            let currQuantity = map.get(product);
            let newQuantity = currQuantity += quantity;
            map.set(product, newQuantity);
        }
    }
    for (let [key, value] of map) {
        console.log(`${key} -> ${value}`);
    }

}

solve(['tomatoes 10',
    'coffee 5',
    'olives 100',
    'coffee 40']
);