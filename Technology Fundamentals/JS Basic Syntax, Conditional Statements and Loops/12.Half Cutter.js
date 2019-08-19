function solve(n) {
    let count = 0;
    do {
        n /= 2;
        count++;
    }while(n>=1);
    console.log(`Length is ${n.toFixed(2)} cm. after ${count} cuts.`);
}
