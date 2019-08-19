function solve(input, arrCommands) {
    let arr = [];
    for (let i = 0; i < input.length; i++) {
        arr[i] = input[i].split(" ").map(Number);
    }
    for (let i = 0; i < arrCommands.length; i++) {
        let curr = arrCommands[i].split(" ");
        let command = curr[0];
        let index = Number(curr[1]);
        if (command === "breeze") {
            for (let j = 0; j < arr[index].length; j++) {
                arr[index][j] -= 15;
                if (arr[index][j] < 0)
                    arr[index][j] = 0;
            }
        }
        else if (command === "gale") {
            for (let j = 0; j < arr.length; j++) {
                arr[j][index] -= 20;
                if (arr[index][j] < 0)
                    arr[index][j] = 0;
            }
        }
        else if (command === "smog") {
            if (index > 0)
                for (let i = 0; i < arr.length; i++) {
                    for (let j = 0; j < arr[i].length; j++) {
                        arr[i][j] += index;
                    }
                }
        }
    }
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            if (arr[i][j] >= 50) {
                let currResult = `[${i}-${j}]`;
                result.push(currResult);
            }
        }
    }
    if (result.length === 0) {
        console.log(`No polluted areas`)
        return;
    }
    console.log(`Polluted areas: ${result.join(", ")}`);
}

solve(["5 7 3 28 32",
        "41 12 49 30 33",
        "3 16 20 42 12",
        "2 20 10 39 14",
        "7 34 4 27 24"],
    ["smog 11", "gale 3", "breeze 1", "smog 2"]
);