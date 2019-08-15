function solve(matrix) {

    let leftSum = 0;
    let rightSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        leftSum += matrix[i][i];
    }

    for (let i = 0; i < matrix.length; i++) {
        matrix[i] = matrix[i].reverse();
        rightSum += matrix[i][i];
    }
    console.log(`${leftSum} ${rightSum}`);
}

solve([[20, 40],
    [10, 60]]
);

solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
);