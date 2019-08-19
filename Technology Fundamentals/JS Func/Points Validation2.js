function solve(arr) {
    let x1 = arr[0];
    let y1 = arr[1];
    let x2 = arr[2];
    let y2 = arr[3];

    let c1 = Math.sqrt((x1 * x1) + (y1 * y1));
    let c2 = Math.sqrt((x2 * x2) + (y2 * y2));
    let c3 = Math.sqrt((Math.abs(x1 - x2) * Math.abs(x1 - x2)) + (Math.abs(y1 - y2) * Math.abs(y1 - y2)));
    if (Number.isInteger(c1)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
    }
    else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`)
    }
    if (Number.isInteger(c2)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
    }
    else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`)
    }
    if (Number.isInteger(c3)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
    }
    else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
    }

}

solve([3, 0, 0, 4
]);