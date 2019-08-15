function solve(matrix) {

    let array = [];

    for (let i = 0; i < matrix.length; i++) {
        array.push(Math.max(...matrix[i]));
    }
    console.log(Math.max(...array));
}

solve([[20, 50, 10],
    [8, 33, 145]]
);

solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
);