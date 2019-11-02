function solve(input) {
    let products = {};
    let letter = {};
    let print = {};
    // Fill objects with prop..
    input.forEach(x => {
        let line = x.split(' : ');
        if (!products.hasOwnProperty(line[0])) {
            products[line[0]] = line[1]
        }
        if (!letter.hasOwnProperty(line[0][0])) {
            letter[line[0][0]] = [];
        }
    });

    //Sort keys
    let keys = Object.keys(products).sort((a, b) => a.localeCompare(b));
    let keysLetter = Object.keys(letter).sort((a, b) => a.localeCompare(b));

   // Fill letter => product sorted
    for (let key of keysLetter) {
        print[key] = [];
        for (let value of keys) {
            if (value[0] === key) {
                print[key].push(`${value}: ${products[value]}`)
            }
        }
    }

    // print result
    for (let key in print) {
        console.log(key);
        for (let value of print[key])
            console.log('  ' + value);
    }
}

solve(
    [
        'Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10'
    ]
);