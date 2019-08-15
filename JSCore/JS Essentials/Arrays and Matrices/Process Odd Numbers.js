function solve(array) {

    let numbers = [];
    for (let i = 0; i <= array.length - 1; i++) {
        if (i % 2 !== 0) {
            numbers.push(array[i] * 2);
        }
    }
    numbers.reverse();
    console.log(numbers.join(' '));
}

solve([10, 15, 20, 25]);