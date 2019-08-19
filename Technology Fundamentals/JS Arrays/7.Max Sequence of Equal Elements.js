function solve(arr) {
    let result = [];
    let bestCount = 0;
    let bestNumber = 0;
    arr = arr[0].split(" ");
    for (let i = 0; i < arr.length - 1; i++) {
        let count = 0;
        for (let j = i + 1; j < arr.length; j++) {
            if (arr[i] === arr[j]) {
                count++;
            }
            else {
                break;
            }
            if (count > bestCount) {
                bestCount = count;
                bestNumber = arr[i];
            }
        }
    }
    for (let i = 0; i < bestCount + 1 ; i++) {
        result.push(bestNumber);
    }
    console.log(result.join(" "));
}

solve(['2 1 1 2 3 3 2 2 2 1']);