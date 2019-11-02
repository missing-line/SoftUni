function solve(input) {
    const reducer = ((a, b) => a + b);
    let gladiators = {};

    for (let i of input) {
        if (i === 'Ave Cesar')
            break;

        if (!i.includes('->')) {
            let line = i.split(' ');
            let first = line[0];
            let second = line[2];

            let keys = Object.keys(gladiators);

            if (keys.includes(first) && keys.includes(second)) {

                let keysOfTechniqueOnFirst = Object.keys(gladiators[first]);
                let keysOfTechniqueOnSecond = Object.keys(gladiators[second]);

                let check = keysOfTechniqueOnFirst
                    .some( x => keysOfTechniqueOnSecond.includes((x)));

                if (!check)
                    continue;

                let findTechnique = keysOfTechniqueOnFirst
                    .find(x => keysOfTechniqueOnSecond.includes(x));

                gladiators[first][findTechnique] > gladiators[second][findTechnique] ?  delete gladiators[second] : delete gladiators[first]
            }

        } else {
            let line = i.split(' -> ');

            let gladiator = line[0];
            let technique = line[1];
            let skill = line[2];

            if (!gladiators.hasOwnProperty(gladiator))
                gladiators[gladiator] = {};

            if (!gladiators[gladiator].hasOwnProperty(technique)) {
                gladiators[gladiator][technique] = 0;
            }

            if (gladiators[gladiator][technique] < +skill)
                gladiators[gladiator][technique] = +skill;
        }
    }

    let sort = Object.keys(gladiators).sort((a, b) => {
        return Object.values(gladiators[b]).reduce(reducer) - Object.values(gladiators[a]).reduce(reducer) ||
            a.localeCompare(b);
    });

    for (let i of sort) {
        let total = Object.values(gladiators[i]).reduce(reducer);
        console.log(`${i}: ${total} skill`);

        let innerSort = Object.keys(gladiators[i])
            .sort((a, b) => gladiators[i][b] - gladiators[i][a] || a.localeCompare(b));

        for (let inner of innerSort)
            console.log(`- ${inner} <!> ${gladiators[i][inner]}`);
    }
}

solve(['Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar']
);

/*
solve(['Pesho -> BattleCry -> 400',
    'Gosho -> PowerPunch -> 300',
    'Stamat -> Duck -> 200',
    'Stamat -> Tiger -> 250',
    'Ave Cesar'
]);*/
