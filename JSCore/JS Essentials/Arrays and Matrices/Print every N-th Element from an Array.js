function solve(input) {

    let step = input[input.length - 1];
    let arr = input.slice(0, input.length - 1);

    for (let i = 0; i <= arr.length - 1; i++) {
        if (i % step === 0){
            console.log(arr[i]);
        }
    }
}

solve(['5',
    '20',
    '31',
    '4',
    '20',
    '2']
);

solve(['dsa',
    'asd',
    'test',
    'tset',
    '2']
);

solve(
    ['1',
        '2',
        '3',
        '4',
        '5',
        '6']

);