function solve(input) {
    let symbol1 = `%`;
    let symbol2 = `.`;
    let digit = input.toString();
    let result = "";
    for (let i = 0; i < Number(digit[0]); i++) {
        result += symbol1;
    }
    for (let i = 0; i < 10 - Number(digit[0]); i++) {
        result += symbol2;
    }
    if (input !== 100){
        console.log(`${input}% [${result}]`);
        console.log(`Still loading...`)
    }
    else{
        console.log(`100% Complete!`);
        console.log(`[%%%%%%%%%%]`);
    }

}

solve(100);