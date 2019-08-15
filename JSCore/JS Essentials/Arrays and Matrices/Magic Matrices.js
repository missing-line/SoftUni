function solve(input) {
    
    let array = [];
    for (let i = 0; i < input.length; i++) {
        array.push(input[i].reduce(function (a,b) {
            return a + b;
        }, 0))
    }

    for (let i = 0; i < input.length; i++) {
        let col = getCol(input, i);
        array.push(col.reduce(function (a,b) {
            return a + b;
        }, 0));
    }

    function getCol(matrix, col) {
        let column = [];
        for (let i = 0; i < matrix.length; i++) {
            column.push(matrix[i][col]);
        }
        return column;
    }

    console.log(array.every((val, i, arr) => val === arr[0]));
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);
solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);