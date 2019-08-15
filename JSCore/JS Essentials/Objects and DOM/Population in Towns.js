function solve(input) {

    let map = new Map();
    for (let i of input) {
        let arr = i.split(/ <-> /);
        let town = arr[0];
        let population = Number(arr[1]);
        if (!map.has(town)) {
            map.set(town, Number(population));
        }
        else { // get newValue
            let value = map.get(town);
            value += population;
            map.set(town, value);
        }

    }

    for (let [key, value] of map.entries()) { // print dictionary
        console.log(`${key} : ${value}`);
    }
}

solve(
    ['Sofia <-> 1200000',
        'Montana <-> 20000',
        'New York <-> 10000000',
        'Washington <-> 2345000',
        'Las Vegas <-> 1000000']
);