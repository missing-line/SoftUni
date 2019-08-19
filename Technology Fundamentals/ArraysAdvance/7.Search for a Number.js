function solve(input1, input2) {
    let array = input1.slice(0, input2[0]);
    array.splice(0, input2[1]);
    let count = 0;
    for (let i = 0; i < array.length; i++) {
        if (array[i] !== input2[2]) {
            count++;
        }
    }
    console.log(`Number ${input2[2]} occurs ${count} time.`)

}

solve([5, 2, 3, 4, 1, 6],
    [5, 2, 3]
);