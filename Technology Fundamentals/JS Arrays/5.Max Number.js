function solve(arr) {
    let result = [];
    for (let i = 0; i < arr.length - 1; i++) {
        let bigger = arr[i];
        for (let j = i + 1; j < arr.length; j++) {
            if (bigger < arr[j]) {
                bigger = arr[j];
            }
        }
        if (result.indexOf(bigger) === -1)
        result.push(bigger);
    }
    if (result.indexOf(arr[arr.length-1]) === -1) 
    result.push(arr[arr.length - 1]);
    console.log(result.join(" "));
}
solve([27, 19, 42, 2, 13, 45, 48]);
