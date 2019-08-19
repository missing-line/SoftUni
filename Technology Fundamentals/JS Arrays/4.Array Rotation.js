function solve(arr, n) {
    for (let i = 0; i < n; i++) {
        let lastElement = arr[0];
        for (let j = 0; j < arr.length - 1; j++) {
            arr[j] = arr[j + 1];
        }
        arr[arr.length - 1] = lastElement;
    }
    console.log(arr.join(" "));
}

solve([51, 47, 32, 61, 21],
    2
);