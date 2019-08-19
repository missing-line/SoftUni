function solve(arr) {
    let sumLeft = 0;
    for (let i = 0; i < arr.length; i++) {
        let currArray = arr[i].split(" ");
        sumLeft += Number(currArray[i]);
    }
    let sumRight = 0;
    for (let i = 0; i < arr.length; i++) {
        let currArray = arr[i].split(" ").reverse();
        sumRight += Number(currArray[i]);
    }
    if (sumLeft !== sumRight) {
       for (let i = 0; i < arr.length; i++) {
       let currArr = arr[i].split(" ");
        console.log(currArr.join(" "));
    }
}
    else {
        for (let i = 0; i < arr.length; i++) {
            let currArray = arr[i].split(" ");
            for (let j = 0; j < currArray.length; j++) {
                if (j !== i && j !== currArray.length - (1 + i)) {
                    currArray[j] = sumLeft;
                }
            }
            arr[i] = currArray.join(" ");
        }

        for (let i = 0; i < arr.length; i++) {
            let currArr = arr[i].split(" ");
            console.log(currArr.join(" "));
        }

    }
}

solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);