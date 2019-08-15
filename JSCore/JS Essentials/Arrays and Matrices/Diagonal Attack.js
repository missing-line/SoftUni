function solve(matrix) {

    let leftSum = 0;
    let rightSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        let arr = matrix[i].split(' ');
        leftSum += Number(arr[i]);
        rightSum += Number(arr[arr.length - (i + 1)]);
    }

    if (leftSum === rightSum){

        for (let i = 0; i < matrix.length; i++) {
           matrix[i] = matrix[i].split(' ');
            for (let j = 0; j < matrix[i].length; j++) {
                if (i !== j &&  j !== matrix[i].length - (i + 1)){
                    matrix[i][j] = leftSum;
                }
            }
        }

        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(' '));
        }
    } else {
        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i]);
        }
    }

}


solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

solve(['1 1 1',
    '1 1 1',
    '1 1 0']
);