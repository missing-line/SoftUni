function solve(input) {
    let array = [];

    input.forEach(x => {

        let line = x.split(' / ');

        let output = {
            name: line[0],
            level: +line[1],
            items: []
        };

        if (line.length > 2) {

            output.items = line[2]
                .split(', ')
                .map(x => {
                    return x
                });
        }

        array.push(output);

    });
    console.log(JSON.stringify(array));
}

solve(
    [
        'Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);

