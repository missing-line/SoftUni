function solve(array) {
    let result = [];

    let first = Math.min(...array);
    let index = array.indexOf(first);
    array.splice(index,1);

    let second = Math.min(...array);
    let indexSecond = array.indexOf(second);
    array.splice(indexSecond,1);
    result.push(first);
    result.push(second);
    console.log(result.join(' '));
}

solve([30, 15, 50, 5]);