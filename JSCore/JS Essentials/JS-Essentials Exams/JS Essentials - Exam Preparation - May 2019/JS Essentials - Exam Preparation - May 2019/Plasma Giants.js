function solve(array, size) {
    let rounds = 1;
    let min = Math.min(...array);
    let max = Math.max(...array);

    let first = array.slice(0, array.length / 2);
    let second = array.slice(array.length / 2);

    let firstSlice = [];
    let secondSlice = [];

    while (first.length !== 0) {
        let slice = first.slice(0, size);
        first = first.slice(size);
        firstSlice.push(slice);
    }
    while (second.length !== 0) {
        let slice = second.slice(0, size);
        second = second.slice(size);
        secondSlice.push(slice);
    }

    let firstSums = [];
    let secondSums = [];

    for (let i = 0; i < firstSlice.length; i++) {
        let currentSum = firstSlice[i].reduce((a, b) => a * b);
        firstSums.push(currentSum);
    }

    for (let i = 0; i < secondSlice.length; i++) {
        let currentSum = secondSlice[i].reduce((a, b) => a * b);
        secondSums.push(currentSum);
    }

    let firstGiant = firstSums.reduce((a, b) => a + b);
    let secondGiant = secondSums.reduce((a, b) => a + b);


    while (firstGiant > max && secondGiant > max && min > 0) {
        firstGiant -= min;
        secondGiant -= min;
        rounds++;
    }


    if (firstGiant === secondGiant) {
        console.log(`Its a draw ${firstGiant} - ${secondGiant}`);
    } else if (firstGiant < secondGiant) {
        console.log(`Second Giant defeated First Giant with result ${secondGiant} - ${firstGiant} in ${rounds} rounds`);
    } else {
        console.log(`First Giant defeated Second Giant with result ${firstGiant} - ${secondGiant} in ${rounds} rounds`);
    }
}

solve([3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 2);
solve([4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], 2);