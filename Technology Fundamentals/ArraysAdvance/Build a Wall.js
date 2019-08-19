function solve(input) {
    let sum = 0;
    let arrayHeight = [];

    while(input.reduce((a,b) => a+ b ,0) !== 30 * input.length ){
        let currLevel = 0;
        for (let i = 0; i < input.length; i++) {
            if (input[i] + 1 <= 30){
                input[i]++;
                currLevel += 195;
            }
        }
        arrayHeight.push(currLevel);
    }
    sum = arrayHeight.reduce((a,b) => a+ b ,0) * 1900;
    console.log(arrayHeight.join(", "));
    console.log(`${sum} ${"pesos"}`);
}

solve([17, 22, 17, 19, 17]);