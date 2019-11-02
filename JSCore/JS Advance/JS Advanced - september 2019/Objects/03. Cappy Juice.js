function solve(input) {

    let bottles = {};
    let full = {};

    input.forEach(x => {
        let token = x.split(' => ');

        if (!bottles.hasOwnProperty(token[0]))
            bottles[token[0]] = 0;

        bottles[token[0]] += +token[1];

        while (bottles[token[0]] >= 1000) {

            bottles[token[0]] -= 1000;

            if (!full.hasOwnProperty(token[0]))
                full[token[0]] = 0;

            full[token[0]]++;
        }
    });

    for (let i in full)
        console.log(`${i} => ${full[i]}`);
}

solve(
    ['Orange => 2000',
        'Peach => 1432',
        'Banana => 450',
        'Peach => 600',
        'Strawberry => 549']
);

solve(
    ['Kiwi => 234',
        'Pear => 2345',
        'Watermelon => 3456',
        'Kiwi => 4567',
        'Pear => 5678',
        'Watermelon => 6789']
);
