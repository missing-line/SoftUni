function solve(input,) {
    let n = +input.pop();
    for (let i = 1; i <= n % input.length; i++) {

        let element = input[input.length - 1]; // 1 2 3 4

        for (let j = input.length - 1; j >= 0; j--) {
            input[j] = input[j - 1];
        }
        input[0] = element;
    }
    console.log(input.join(" "));
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
)
solve([]);