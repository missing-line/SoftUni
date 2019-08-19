function solve(input) {
    let arr = [];
    for (let i = 0; i < input.length; i++) {
        let currArr = input[i].split(" ");
        let name = currArr[0];
        if (currArr.includes("not") && arr.includes(name)) {
            let index = arr.indexOf(name);
            arr.splice(index,1);
        }
        else if (currArr.includes("not") && !arr.includes(name)) {
            console.log(`${name} is not in the list!`)
        }
        else {
            if (!arr.includes(name)) {
                arr.push(name);
            }
            else{
                console.log(`${name} is already in the list!`)
            }

        }
    }
    for (let i = 0; i < arr.length; i++) {
        console.log(arr[i]);
    }
}

solve(['Tom is going!',
    'Annie is going!',
    'Tom is going!',
    'Garry is going!',
    'Jerry is going!']

);