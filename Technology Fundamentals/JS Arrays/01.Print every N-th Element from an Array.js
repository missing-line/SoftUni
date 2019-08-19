function solve(arr) {
    let step = Number(arr[arr.length - 1]);
    let arrResult = [];
    for (let i = 0; i < arr.length - 1; i +=step) {
        arrResult.push(arr[i]);
    }
    console.log(arrResult.join(" "));
}

solve(['5', '20', '31', '4', '20', '2']);