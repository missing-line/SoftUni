function solve(input) {
    let step = +input.pop();

    for (let i = 0; i < input.length; i += step) {
        console.log(input[i]);
    }
}

solve(['5',
    '20',
    '31',
    '4',
    '20',
    '2']
);

solve(['1',
    '2',
    '3',
    '4',
    '5',
    '6']

);