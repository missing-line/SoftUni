function solve(original) {
    let arr = [];
    for (let i = 0; i < original.length ; i++) {
        if (original[i] % 2 === 0){
            arr[i] = original[i] + i;
        }
        else if (original[i] % 2 !== 0){
            arr[i] = original[i] - i;
        }
    }
    let sumOriginal = 0;
    let sumArr = 0;
    for (let i = 0; i < original.length; i++) {
        sumOriginal += original[i];
        sumArr += arr[i];
    }
    console.log(arr);
    console.log(sumOriginal);
    console.log(sumArr);
}
solve([5, 15, 23, 56, 35]);