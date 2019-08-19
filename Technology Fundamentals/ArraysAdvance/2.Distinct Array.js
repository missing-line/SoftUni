function solve(input) {
    let arrInput = input;
    let arr =  input;
    for (let i = 0; i < arrInput.length; i++) {
        for (let j = arr.length - (1 + i); j > 0; j--) {
            if (arr[j] === arrInput[i]){               
                arr.splice(j,1);
                j--;
            }
        }
    }
    console.log(arr.join(" "));
}

solve([7, 8, 9, 7, 2, 3, 4, 1, 2]);