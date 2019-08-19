function solve(input) {
    let arr = [];
    let sum = 0;
    let count = 0;
    for (let i = 0; i < input.length - 1; i++) {
        let curr = input[i].split(" ");
        arr.push(curr);
    }
    let bombs = input[input.length - 1].split(" ");

    for (let i = 0; i < bombs.length; i++) {
        let curr = bombs[i].split(",");
        let row = Number(curr[0]);
        let col = Number(curr[1]);
        let value = arr[row][col];
        if (Number(value) > 0) {
            if (col + 1 <= arr[row].length - 1) {
                arr[row][col + 1] = Number(arr[row][col + 1] - value);
            }
            if (col - 1 >= 0) {
                arr[row][col - 1] = Number(arr[row][col - 1] - value);
            }
            if (row - 1 >= 0 && col - 1 >= 0) {
                arr[row - 1][col - 1] = Number(arr[row - 1][col - 1] - value);
            }
            if (row - 1 >= 0) {
                arr[row - 1][col] = Number(arr[row - 1][col] - value);
            }
            if (row - 1 >= 0 && col + 1 <= arr[row].length - 1) {
                arr[row - 1][col + 1] = Number(arr[row - 1][col + 1] - value);
            }
            if (row + 1 <= arr.length - 1 && col - 1 >= 0) {
                arr[row + 1][col - 1] = Number(arr[row + 1][col - 1] - value);
            }
            if (row + 1 <= arr.length - 1) {
                arr[row + 1][col] = Number(arr[row + 1][col] - value);
            }
            if ((row + 1 <= arr.length - 1 && col + 1 <= arr[row].length - 1)) {
                arr[row + 1][col + 1] = Number(arr[row + 1][col + 1] - value);
            }
        }
    }
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            if (Number(arr[i][j] > 0)) {
                sum += Number(arr[i][j]);
                count++;
            }
        }
    }
    console.log(sum);
    console.log(count);
}

solve(['5 10 15 20',
    '10 10 10 10',
    '10 15 10 10',
    '10 10 10 10',
    '2,2 0,1']
);
