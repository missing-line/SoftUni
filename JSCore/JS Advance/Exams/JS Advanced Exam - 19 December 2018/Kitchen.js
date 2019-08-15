class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(input) {

        for (let i = 0; i < input.length; i++) {
            let currProduct = input[i].split(' ');
            let nameOfProduct = currProduct[0];
            let quantity = +currProduct[1];
            let price = +currProduct[2];

            if (this.budget - price >= 0) {
                if (!Object.keys(this.productsInStock).includes(nameOfProduct)) {
                    this.productsInStock[nameOfProduct] = 0;
                }

                this.productsInStock[nameOfProduct] += quantity;
                this.budget -= price;
                this.actionsHistory.push(`Successfully loaded ${quantity} ${nameOfProduct}`);
            } else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${nameOfProduct}`);
            }
        }
        return this.actionsHistory.join('\n'); //
    }

    addToMenu(nameOfMeal,inputOfProducts,priceOfMeal) {

        if (Object.keys(this.menu).includes(nameOfMeal)) {
            return `The ${nameOfMeal} is already in our menu, try something different.`;
        }

        this.menu[nameOfMeal] = {
            products: inputOfProducts,
            price: +priceOfMeal,
        };

        let allKeys = Object.keys(this.menu).length;
        return `Great idea! Now with the ${nameOfMeal} we have ${allKeys} meals in the menu, other ideas?`;
    }

    showTheMenu() {
        let info = [];
        for (let meal in this.menu) {
            info.push(`${meal} - $ ${this.menu[meal].price}`);
        }

        if (info.length === 0) {
            return 'Our menu is not ready yet, please come later...';
        }
        return info.join('\n') + '\n';
    }

    makeTheOrder(meal) {

        if (!Object.keys(this.menu).includes(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        const neededProducts = this.menu[meal].products;

        for (let i = 0; i < neededProducts.length; i++) {
            let product = neededProducts[i].split(' ');
            let nameOfProduct = product[0];
            let quantity = +product[1];

            if (!this.productsInStock.hasOwnProperty(nameOfProduct)) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
            }
            if (this.productsInStock[nameOfProduct] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
            }
        }

        for (let i = 0; i < neededProducts.length; i++) {
            let product = neededProducts[i].split(' ');
            let nameOfProduct = product[0];
            let quantity = +product[1];

            this.productsInStock[nameOfProduct] -= quantity;
        }
        this.budget += this.menu[meal].price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`
    }
}
