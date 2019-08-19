function solve(arr) {
    let value = 0;
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === "soap"){
            value += 10;
        }
        else if (arr[i] === "vacuum cleaner"){
            value += (value * 0.25);
        }
        else if (arr[i] === "water"){
            value += (value * 0.20);
        }
        else if (arr[i] === "mud"){
            value -= (value * 0.10);
        }
    }
    console.log(`The car is ${value.toFixed(2)}% clean.`);
}
solve(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);