function solve(input) {
    let num = Number(input[0]);

    for (let i = 1; i < input.length; i++) {
        if (input[i] === 'chop') {
            num /= 2;
        } else if (input[i] === 'dice') {
            num = Math.pow(num, 1 / 2)
        } else if (input[i] === 'spice') {
            num++;
        } else if (input[i] === 'bake') {
            num *= 3;
        } else if (input[i] === 'fillet') {
            num -= 0.2 * num;
        }
        console.log(num);
    }
}


//solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);