function solve(input) {
    let map = new Map();
    let battleIndex = 0;
    for (let i = 0; i < input.length; i++) {
        let currWarrior = input[i].split(' -> ');
        if (currWarrior.length === 1) {
            battleIndex = i;
            break;
        }

        let name = currWarrior[0];
        let skill = currWarrior[1];
        let power = Number(currWarrior[2]);
        if (!map.has(name)) {
            map.set(name, new Map());
            let values = map.get(name);
            values.set(skill, power);
            map.set(name, values);
        }
        else {
            let values = map.get(name);
            if (!values.has(skill)) {
                values.set(skill, power);
                map.set(name, values);
            }
            else if (values.has(skill)) {
                let currPower = values.get(skill);
                currPower += power;
                values.set(skill, currPower);
                map.set(name, values);
            }
        }
    }

    for (let i = battleIndex; i < input.length; i++) {
        let currBattle = input[i].split(' vs ');
        if (currBattle[0] === `Ave Cesar`) {
            break;
        }
        let first = currBattle[0];
        let second = currBattle[1];
        if (map.has(first) && map.has(second)) {
            let firstValues = map.get(first);
            let secondValues = map.get(second);
            for (let [keyFirst, valueFirst] of firstValues) {
                for (let [keySecond, valueSecond] of secondValues) {
                    if (keyFirst === keySecond) {
                        if (valueFirst > valueSecond) {
                            valueSecond -= valueFirst;
                            if (valueSecond <= 0) {
                                map.delete(second);
                            }
                            else {
                                secondValues.set(keySecond, valueSecond);
                                map.set(second, secondValues);
                            }
                        }
                        else if (valueFirst < valueSecond) {
                            valueFirst -= valueSecond;
                            if (valueFirst <= 0) {
                                map.delete(first);
                            }
                            else {
                                firstValues.set(keyFirst, valueFirst);
                                map.set(first, firstValues);
                            }
                        }

                    }
                }
            }
        }
    }
    let printMaxPower = new Map();
    for (let [key, value] of map) {
        let sum = 0;
        if (!printMaxPower.has(key)) {
            printMaxPower.set(key, 0);
            for (let [skill, power] of value) {
                sum += power;
            }
        }
        else {
            for (let [skill, power] of value) {
                sum += power;
            }
        }
        let valuePrint = printMaxPower.get(key);
        valuePrint += sum;
        printMaxPower.set(key, valuePrint);
    }
    let sortedPower = [...printMaxPower].sort((a, b) => b[1] - a[1]);
    let sortedName = [...sortedPower].sort((a, b) => a[0].localeCompare(b[0]));


    for (let [key, value] of sortedName) {
        console.log(`${key} : ${value} skill`)
        for (let [name,values] of map){
            if (name === key){
                let innerPower = [...values].sort((a, b) => a - b);
                let skillName = [...innerPower].sort((a, b) => a[0].localeCompare(b[0]));
                for (let [key,value] of skillName){
                    console.log(`--${key} -> ${value}`)
                }
            }
        }
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