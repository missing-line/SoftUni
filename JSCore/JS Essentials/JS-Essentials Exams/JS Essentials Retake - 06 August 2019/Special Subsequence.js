function sequence(input) {
    const original = input.map(x => x);

    let isNegative;
    let isPositive;
    let results = [];

    let index = [0,];
    while (input.length > 0) {
        if (input[0] > 0) {
            isNegative = true;
            isPositive = false;
        } else {
            isNegative = false;
            isPositive = true;
        }

        for (let i = 1; i < input.length; i++) {
            if (input[0] === 0)
                break;
            if (isNegative) {
                if (input[i] < 0) {
                    index.push(i);
                    isPositive = true;
                    isNegative = false;
                    continue;
                }
                break;
            } else if (isPositive) {
                if (input[i] > 0) {
                    index.push(i);
                    isPositive = false;
                    isNegative = true;
                    continue;
                }
                break;
            }
        }

        let arr = [];
        for (let i = 0; i < index.length; i++) {
            arr.push(input[index[i]])
        }

        if (results.length === 0){
           results.push(arr);
        } else if (results[0].length < arr.length) {
            results[0] = arr;
        }

        input = input.splice(index.length);
        index = [0,];
    }

    if (results.length === 0 || results[0].length === 1) {
        console.log(`In ${original.join(', ')} no special sequence is found`);
        return;
    }

    console.log(`The longest sequence is ${results[0].join(', ')}`);
}

sequence([1, -2, 1, -1, 2, 1, -1, 0, 1, -2, 1, -1, 2, 1, -1]);
sequence([-1, -1, 0, -1, 1, -1, 0]);
sequence([1, 2, 3, 4, 5]);