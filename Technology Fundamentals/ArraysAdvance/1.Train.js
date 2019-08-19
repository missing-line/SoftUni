function solve(input) {
    let arr = input[0].split(" ");
    let capacity = Number(input[1]);

    for (let i = 2; i <= input.length - 1; i++) {
        if (input[i].includes("Add")) {
            let currArr = input[i].split(" ");
            arr.push(currArr[1]);
        }
        else {
            let passengers = Number(input[i]);
            arr = FindingPassengerWagon(arr, passengers, capacity);
        }
    }
    console.log(arr.join(" "));

    function FindingPassengerWagon(arr, passengers, capacity) {
        for (let i = 0; i < arr.length; i++) {
            if (Number(arr[i]) + passengers <= capacity) {
                arr[i] = Number(arr[i]) + passengers;
                break;
            }
        }
        return arr;
    }
}

solve(['32 54 21 12 4 0 23',
    '75',
    'Add 10',
    'Add 0',
    '30',
    '10',
    '75']
);

function f(word) {
    let array = ['Eva dadd', 'sdadaad', 'dadada'];

    for (let i = 0; i < array.length; i++) {
        let check = array[i].match(word);
        console.log(check.toString());
        return;
    }
}

f('E');
