function solve(n) {
    let text = 'ATCGTTAGGG';
    let count = 0;
    let midCount = 0;
    let i = 0;
    while (count !== n) {
        if (midCount === 0) {
            console.log(`**${text[midCount + i]}${text[midCount + 1 + i]}**`);
            midCount++;
        }
        else if (midCount === 1) {
            console.log(`*${text[midCount + 1 + i]}--${text[midCount + 2 + i]}*`);
            midCount++;
        }
        else if (midCount === 2) {
            console.log(`${text[midCount + 2 + i]}----${text[midCount + 3 + i]}`);
            midCount++;
        }
        else if (midCount === 3) {
            console.log(`*${text[midCount + 3 + i]}--${text[midCount + 4 + i]}*`);
            midCount++;
        }
        else if (midCount === 4) {
            console.log(`**${text[midCount + 4 + i]}${text[midCount + 5 + i]}**`);
            midCount = 0;
            i++;
        }
        count++;
    }
}

solve(10);