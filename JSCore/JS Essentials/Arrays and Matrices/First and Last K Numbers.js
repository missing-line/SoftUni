function solve(input) {
    let k = input[0];
    let arr = input.slice(1);

    let firstK = [];
    let secondK = [];

    for (let i = 0; i < k; i++) {
        firstK.push(arr[i]);
    }
    for (let i = 1; i <= k ; i++) {
        secondK.push(arr[arr.length - i]);
    }
    secondK.reverse();
    console.log(firstK.join(' '));
    console.log(secondK.join(' '));
}

solve([3,
    6, 7, 8, 9]
);