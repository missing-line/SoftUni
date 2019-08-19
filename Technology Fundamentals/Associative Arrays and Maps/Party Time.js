function solve(input) {
    let map = new Map();
    map.set('VIP', []);
    map.set('Regular', []);
    let indexAfterParty = 0;
    for (let i = 0; i < input.length; i++) {
        if (input[i] === 'PARTY') {
            indexAfterParty = i + 1;
            break;
        }
        let guess = input[i];
        if (!isNaN(Number(guess[0]))) {
            let values = map.get('VIP');
            values.push(input[i]);
            map.set('VIP', values);

        }
        else {
            let values = map.get('Regular');
            values.push(input[i]);
            map.set('Regular', values);

        }
    }

    for (let i = indexAfterParty; i < input.length; i++) {
        let valuesVIP = map.get('VIP');
        let valuesRegular = map.get('Regular');
        if (valuesVIP.includes(input[i])) {
            let index = valuesVIP.indexOf(input[i]);
            valuesVIP.splice(index, 1);
            map.set('VIP', valuesVIP);
        }
        if (valuesRegular.includes(input[i])) {
            let index = valuesRegular.indexOf(input[i]);
            valuesRegular.splice(index, 1);
            map.set('Regular', valuesRegular);
        }
    }
    let arr = [];
    for (let [key, value] of map) {
        for (let guess of value) {
            arr.push(guess);
        }
    }
    console.log(arr.length);
    console.log(arr.join('\n'));
}

solve(['m8rfQBvl',
        'fc1oZCE0',
        'UgffRkOn',
        '7ugX7bm0',
        '9CQBGUeJ',
        '2FQZT3uC',
        'dziNz78I',
        'mdSGyQCJ',
        'LjcVpmDL',
        'fPXNHpm1',
        'HTTbwRmM',
        'B5yTkMQi',
        '8N0FThqG',
        'xys2FYzn',
        'MDzcM9ZK',
        'MDzcM9ZK',
        'PARTY',
        '2FQZT3uC',
        'dziNz78I',
        'mdSGyQCJ',
        'LjcVpmDL',
        'fPXNHpm1',
        'HTTbwRmM',
        'B5yTkMQi',
        '8N0FThqG',
        'm8rfQBvl',
        'fc1oZCE0',
        'UgffRkOn',
        '7ugX7bm0',
        '9CQBGUeJ'
    ]
);