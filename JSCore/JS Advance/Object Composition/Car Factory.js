function solve(car) {
    let engine =  [{ power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }];

    let wheel = 0;
    if (car.wheelsize % 2 === 0)
        car.wheelsize--;

    wheel = car.wheelsize;

    return {
        model: car.model,
        engine: engine.filter(x => x.power >= car.power)[0],
        carriage: {
            type:  car.carriage,
            color: car.color
        },
        wheels: [wheel, wheel, wheel, wheel]
    };
}

let car = {
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
};

console.log(solve(car));