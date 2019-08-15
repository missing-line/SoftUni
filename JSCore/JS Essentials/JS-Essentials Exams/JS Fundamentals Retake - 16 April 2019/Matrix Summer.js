function solve(a, b) {
    let result = [];
    for (let i = 0; i < a.length; i++) {
        let first = a[i];
        let second = b[i];
        let arr = [];
        let remainder = 0;
        for (let j = 0; j < first.length; j++) {
            remainder += first[j] + second[j];
            if (remainder > 9){
                arr.push(9);
                remainder -= 9;
            } else {
                arr.push(remainder);
                remainder = 0;
            }
        }
        while (remainder > 0) {
            arr.push(remainder < 10 ? remainder : 9);
            remainder -= 9;
        }
        result.push(arr)
        /*if (remainder > 0 && remainder <= 9){
            arr.push(remainder);
        }
        result.push(arr);*/
    }
    console.log(JSON.stringify(result));
}

solve([[1, 2, 3], [3, 4, 5], [5, 6, 7]],
    [[1, 1, 1], [1, 1, 1], [1, 1, 1]]
);

solve([[9, 9], [4, 7]],
    [[7, 1], [1, 2]]
);

