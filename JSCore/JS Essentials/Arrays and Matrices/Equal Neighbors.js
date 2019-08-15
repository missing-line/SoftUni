function solve(matrix) {

    let equals = 0;

    for (let i = 0; i < matrix.length - 1; i++) {
        let col = matrix[i];
        for (let j = 0; j < col.length - 1; j++) {
            if (col[j] === col[j + 1]) {
                equals++;
            }
            if (col[j] === matrix[i + 1][j]) {
                equals++;
            }
        }
        if (col[col.length - 1] === matrix[i + 1][matrix[i + 1].length - 1]) {
            equals++;
        }
    }

    for (let i = 0; i < matrix[matrix.length - 1].length; i++) {
        if (matrix[matrix.length - 1][i] === matrix[matrix.length - 1][i + 1]) {
            equals++;
        }
    }
    console.log(equals);
}

solve([['2', '3', '4', '7', '0'],
       ['4', '0', '5', '3', '4'],
       ['2', '3', '5', '4', '2'],
       ['9', '8', '7', '5', '5']]
);