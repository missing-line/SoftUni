function solve(n) {
    let count = 0;
    let sum = 0;
    for (let i = 1; i <= 100 ; i++) {
        if (i % 2 != 0) {
            console.log(i);
            sum+= i;
            count++;
        }
        if (count === n) {
            console.log(`Sum: ${sum}`)
            break;
        }
    }
}
