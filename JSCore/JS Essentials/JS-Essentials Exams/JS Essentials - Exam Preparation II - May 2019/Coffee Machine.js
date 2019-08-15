function solve(input) {

    let totalIncome = 0;

    for (let i = 0; i < input.length; i++) {

        let orderArr = input[i].split(', ');
        let sugar = Number(orderArr[orderArr.length - 1]);
        let insertMoney = Number(orderArr[0]);
        let milkPrice = Number(0);
        let orderDrink = orderArr[1];
        let product = 0;

        if (orderDrink === 'coffee') {
            if (orderArr[2] === 'decaf') {
                product = 0.9;
            }
            else {
                product = 0.8;
            }
        }
        else {
            product = 0.8;
        }


        if (sugar !== 0) {
            sugar = 0.1;
        }

        if (orderArr.includes("milk")) {
            milkPrice = 0.1;
        }

        let price = (product + milkPrice + sugar);

        if (insertMoney - price >= 0) {
            totalIncome = totalIncome + Number(price);
            console.log(`You ordered ${orderArr[1]}. Price: ${price.toFixed(2)}$ Change: ${(insertMoney - price).toFixed(2)}$`)
        }
        else {
            console.log(`Not enough money for ${orderArr[1]}. Need ${(price - insertMoney).toFixed(2)}$ more.`)
        }
    }

    console.log(`Income Report: ${totalIncome.toFixed(2)}$`);
}

//solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);
