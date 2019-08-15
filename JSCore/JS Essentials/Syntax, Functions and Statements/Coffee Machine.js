function coffeeMachine(arr) {
   
    let totalIncome = 0;
 
    let obj = {
        'coffee caffeine': 0.80,
        'coffee decaf' : 0.90,
        'tea' : 0.80,
    };
   
    for (var order of arr) {
       
        let orderArr = order.split(", ");
        let hasMilk = false;
        let insertMoney = Number(orderArr[0]);
        let orderDrink = orderArr[1];
        if (orderDrink === 'coffee')
        {
            let odrerDrinkspecify = orderArr[2];
            orderDrink += " " + odrerDrinkspecify;
        }
        if (order.includes("milk"))
        {
            hasMilk = true;
        }
 
        let sugar = Number(orderArr[orderArr.length - 1]);
        let sugarPrice = sugar === 0 ? 0 : 0.1;
        let milkPrice = 0;
        let priceDrink = obj[orderDrink];
        if (hasMilk)
        {
            milkPrice = Math.round((priceDrink * 0.1) * 10) / 10;
        }
 
        let price = (priceDrink + milkPrice + sugarPrice).toFixed(2);
       
        let difference = (insertMoney - price).toFixed(2);
        if (difference >= 0)
        {
            totalIncome = Number(totalIncome) + Number(price);
        }
        console.log(difference >= 0 ? `You ordered ${orderArr[1]}. Price: $${price} Change: $${difference}` : `Not enough money for ${orderArr[1]}. Need $${Math.abs(difference).toFixed(2)} more.`);
    }
 
    console.log(`Income Report: $${totalIncome.toFixed(2)}`);
}

//offeeMachine(['8.00, coffee, decaf, 4', '1.00, tea, 2']);