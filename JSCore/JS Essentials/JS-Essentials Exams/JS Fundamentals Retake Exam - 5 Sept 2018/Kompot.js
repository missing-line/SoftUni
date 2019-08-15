function solve(input) {

    let cherryPer = 25 * 9;
    let peachPer = 2.5 * 140;
    let plumPer = 10 * 20;

    let cherry = 0;
    let peach = 0;
    let plum = 0;
    let bucket = 0;

    for (let i = 0; i < input.length; i++) {
        let arr = input[i].split(/\s+/g);

        let fruit = arr[0];
        let weight = +arr[1];

        switch (fruit) {
            case 'cherry':
                cherry += weight;
                break;
            case 'plum':
                plum += weight;
                break;
            case 'peach':
                peach += weight;
                break;
            default:
                bucket += weight;
                break;
        }
    }

    cherry *= 1000;
    peach *= 1000;
    plum *= 1000;

    console.log(`Cherry kompots: ${Math.floor(cherry / cherryPer)}`);
    console.log(`Peach kompots: ${Math.floor(peach / peachPer)}`);
    console.log(`Plum kompots: ${Math.floor(plum / plumPer)}`);
    console.log(`Rakiya liters: ${(bucket * 0.200).toFixed(2)}`);
}

solve(
    ['cherry 1.2',
        'peach 2.2',
        'plum 5.2',
        'peach 0.1',
        'cherry 0.2',
        'cherry 5.0',
        'plum 10',
        'cherry 20.0',
        'papaya 20']
);

solve([   'apple 6',
        'peach 25.158',
        'strawberry 0.200',
        'peach 0.1',
        'banana 1.55',
        'cherry 20.5',
        'banana 16.8',
        'grapes 205.65'
        ,'watermelon 20.54'
    ]
);