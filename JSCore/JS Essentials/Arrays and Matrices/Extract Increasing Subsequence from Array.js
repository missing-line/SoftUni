function solve(input) {

    let arr = [];
    arr.push(input[0]);

    for (let i = 1; i < input.length; i++) {
        if (input[i] >= arr[arr.length - 1]){
            arr.push(input[i]);
        }
    }
    console.log(arr.join('\n'));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);
solve([20,
    3,
    2,
    15,
    6,
    1]
);