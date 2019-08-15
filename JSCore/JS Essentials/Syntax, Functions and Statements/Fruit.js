function solve(typeFruit, weight, money) {
    let fruit = typeFruit;

    weight /= 1000;

    money *= weight;

    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);