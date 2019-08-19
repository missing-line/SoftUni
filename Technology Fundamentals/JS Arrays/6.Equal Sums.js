function solve(arr) {
    if (arr.length === 1){
        console.log(0);
        return;
    }
    let isEquals = new  Boolean(false);
    let result = 0;
    for (let i = 0; i < arr.length; i++) {
        let sumLeft = 0;
        for (let j = 0; j < i; j++) {
            sumLeft += arr[j];
        }
        let sumRight = 0;
        for (let j = i + 1; j <arr.length ; j++) {
         sumRight+= arr[j];
        }
        if (sumRight === sumLeft){
            result = i;
            isEquals = true;
            break;
        }
    }
    if (isEquals === true) {
        console.log(result);
    }
    else{
        console.log("no")
    }
}
solve([1, 2, 3, 3]);