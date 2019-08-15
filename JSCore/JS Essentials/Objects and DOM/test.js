function solve(a,b ) {
    let result = a / (1 + (b / 100));
    console.log(result.toFixed(2));
}

solve(220.00,10.00);