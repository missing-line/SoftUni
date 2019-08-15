function solve(input) {

    let lastElement = input[input.length - 1];
    input = input.slice(0, input.length - 1);
    let step = lastElement % input.length;

    for (let i = 0; i < step; i++) {
        let lastElement = input[input.length - 1];
        // 1 2 3 4                    4 1 2 3
        for (let j = input.length - 1; j >= 1; j--) {
            input[j] = input[j - 1];
        }
        input[0] = lastElement;
    }

    console.log(input.join(' '));

}

solve(['1',
    '2',
    '3',
    '4',
    '2']
);
solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']
);
