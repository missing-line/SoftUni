function solve(arr) {
    let name = arr[0];
    let count = 1;
    for (let i = 1; i <= arr.length - 1; i++) {
        let curr = arr[i];
        let check = "";
        for (let j = curr.length - 1; j >= 0; j--) {
            check += curr[j];
        }
        if (check === name) {
            console.log(`User ${name} logged in.`);
        }
        else if (count === 4) {
            console.log(`User ${name} blocked!`);
            return;
        }
        else {
            console.log(`Incorrect password. Try again.`);
            count++;
        }
    }
}

solve(['momo', 'omom']);