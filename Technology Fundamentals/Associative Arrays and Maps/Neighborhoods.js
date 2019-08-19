function solve(input) {
    let map = new Map();
    let arr = input[0].split(', ');
    for (let i = 0; i < arr.length; i++) {
        if (!map.has(arr[i])){
            let array = [];
            map.set(arr[i],array);
        }
    }
    for (let i = 1; i < input.length; i++) {
        let curr = input[i].split('-');
        let address = curr[0].trim();
        let name = curr[1].trim();
        if (map.has(address)) {
            let value = map.get(address);
            value.push(name);
            map.set(address, value);
        }
    }
    let sorted = [...map].sort((a, b) => b[1].length - a[1].length);
    for (let [key, value] of sorted) {
        console.log(`${key}: ${value.length}`);
        for (let neighbor of value) {
            console.log(`--${neighbor}`)
        }
    }
}

solve(['Abbey Street, Herald Street, Bright Mews',
    'Bright Mews - Garry',
    'Bright Mews - Andrea',
    'Invalid Street - Tommy',
    'Abbey Street - Billy']
);