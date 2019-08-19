function solve(input) {
    let [ size, days ] = input.map(Number);
    let coins = 0;
    let spent = 0;
    for (let i = 1; i <= days; i++) {
        if (i % 10 === 0) {
            size -= 2;
        }
        if (i % 15 === 0) {
            size += 5;
        }
        if (i % 3 === 0) {
            spent += (3 * size);
        }
        if (i % 5 === 0) {
                coins += (20 * size);
                if (i % 3 === 0){
                    spent += (2 * size);
                }
        }
        coins += 50;
        spent += (2 * size);
    }
    console.log(`${size} companions received ${Math.trunc((coins - spent) / size)} coins each.`)
}

solve([3,5]);