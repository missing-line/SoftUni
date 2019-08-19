function solve(input) {
    let map = new Map();

    for (let i = 0; i < input.length; i++) {

        let currGarage = input[i].split(' - ');
        let numberOfGarage = currGarage[0];

        if (!map.has(numberOfGarage)) {
            let arr = [];
            let carsIN = currGarage[1].split(', ');
            for (let j = 0; j < carsIN.length; j++) {

                let car = carsIN[j].split(': ');
                let arrIndex = `${car[0]} - ${car[1]}`;
                arr.push(arrIndex);
            }
            let set = new Set();
            set.add(arr);
            map.set(numberOfGarage, set);
        }
        else {
            let values = map.get(numberOfGarage);
            let arr = [];
            let carsIN = currGarage[1].split(', ');
            for (let j = 0; j < carsIN.length; j++) {
                let isFind = Boolean(false);
                let car = carsIN[j].split(': ');
                let arrIndex = `${car[0]} - ${car[1]}`;
                for (let array of values) {
                    if (array.includes(arrIndex)) {
                        isFind = true;
                        break;
                    }
                }
                if (!isFind) {
                    arr.push(arrIndex);
                }
            }

            values.add(arr);

            map.set(numberOfGarage, values);
        }
    }

    let sorted = [...map].sort((a, b) => a[0] - b[0]);
    for (let [key, values] of sorted) {
        console.log(`Garage № ${key}`);
        for (let innerArray of values) {
            console.log(`--- ${innerArray.join(', ')}`);
        }
    }
}

solve(['2 - fuel type: petrol',
    '1 - color: blue, fuel type: diesel',
    '1 - fuel type: diesel, color: blue',
    '1 - color: red, manufacture: Audi',
    '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'
]);