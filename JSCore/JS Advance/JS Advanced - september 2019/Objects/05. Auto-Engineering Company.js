function solve(input) {
    let cars = {};

    input.forEach(x => {
        let arr = x.split(' | ');
        let car = arr[0];
        let model = arr[1];
        let value = +arr[2];

        if (!cars.hasOwnProperty(car))
            cars[car] = {};

        if (!cars[car].hasOwnProperty(model))
            cars[car][model] = 0;

        cars[car][model] += value;
    });

    for (let car in cars) {
        console.log(car);

        for (let model in cars[car]){
            console.log(`###${model} -> ${cars[car][model]}`);
        }
    }
}

solve(
    [
        'Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10'
    ]
);