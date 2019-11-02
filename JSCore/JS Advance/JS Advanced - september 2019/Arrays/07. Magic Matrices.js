function solve(arr) {

    function GetSum(array) {
        return array.reduce((a, b) => a + b, 0);
    }

    function checkSumsRows(arr, sum) {
        let sums = arr.map(x => x.reduce((a, b) => a + b, 0));
        let isEquals = [...new Set(sums)];
        return isEquals.length === 1 && isEquals[0] === sum;
    }

    function checkSumsCols(arr, sum) {
        let sums = arr.reduce((a, b) =>
            a.map((x, i) => x + (b[i] || 0)));

        let isEquals = [...new Set(sums)];
        return isEquals.length === 1 && isEquals[0] === sum;
    }

    let sum = GetSum(arr[0]);

    if (!checkSumsRows(arr, sum))
        return console.log("false");

    if (!checkSumsCols(arr, sum))
        return console.log("false");

    console.log("true");
}

solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);

solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);