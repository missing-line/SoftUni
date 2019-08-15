function solve(a, b, c, d) {
    let sum = 0;
    let obj = {
        'JS Fundamentals': 170,
        'JS Advanced': 180,
        'JS Applications': 190
    };
    
    if (a === true && b === true) {
        obj['JS Advanced'] *= 0.9;
    }
    if (d === 'online') {
        obj['JS Fundamentals'] *= 0.94;
        obj['JS Advanced'] *= 0.94;
        obj['JS Applications'] *= 0.94;
    }
    if (a && b && c) {
        sum += obj['JS Fundamentals'] + obj['JS Advanced'] + obj['JS Applications'];
        sum *= 0.94;
        console.log(Math.round(sum));
    } else {
        if (a){
            sum += obj['JS Fundamentals'];
        }
        if (b) {
            sum +=  obj['JS Advanced']
        }
        if (c) {
            sum +=  obj['JS Applications']
        }
        console.log(Math.round(sum));
    }
}

solve(true, false, false, "onsite");
solve(true, false, false, "online");
solve(true, true, true, "onsite");

