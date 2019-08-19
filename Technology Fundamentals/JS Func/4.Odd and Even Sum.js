function solve(input) {
    let number = input.toString();
    let sumEven = 0;
    let sumOdd = 0;
    for (let i = 0; i < number.length; i++) {
        let currN = Number(number[i].toString());
        if (currN % 2 === 0) {
            sumEven += currN;
        }
        else {
            sumOdd += currN;
        }
    }
    console.log(`Odd sum = ${sumOdd}, Even sum = ${sumEven}`);
}

solve(3495892137259234);