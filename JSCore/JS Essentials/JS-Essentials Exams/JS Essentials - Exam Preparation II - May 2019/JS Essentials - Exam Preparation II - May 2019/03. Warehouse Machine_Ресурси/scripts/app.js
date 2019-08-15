function coffeeStorage() {

    let product = {};
    let text = JSON.parse(document.querySelectorAll('textarea')[0].value);

    for (let i = 0; i < text.length; i++) {
        let arr = text[i].split(',');
        let command = arr[0];

        if (command === 'IN') {
            let brand = arr[1].trim();
            let coffee = arr[2].trim();
            let expireDate = arr[3].trim();
            let quantity = Number(arr[4].trim());

            if (!product.hasOwnProperty(brand)) {
                product[brand] = {};
            }
            if (!product[brand].hasOwnProperty(coffee)) {

                product[brand][coffee] = {date: expireDate, quantity: quantity};

            } else if (product[brand].hasOwnProperty(coffee)) {

                let dateIn = product[brand][coffee].date;
                if (dateIn < expireDate) {
                    product[brand][coffee].date = expireDate;
                    product[brand][coffee].quantity = quantity;
                } else if (dateIn === expireDate) {
                    product[brand][coffee].quantity += quantity;
                }
            }
        } else if (command === 'OUT') {
            let brand = arr[1].trim();
            let coffee = arr[2].trim();
            let expireDate = arr[3].trim();
            let quantity = Number(arr[4].trim());

            if (product.hasOwnProperty(brand) && product[brand].hasOwnProperty(coffee)) {
                let dateIn = product[brand][coffee].date;
                let quantityIn = product[brand][coffee].quantity;
                if (dateIn >= expireDate && quantityIn >= quantity) {
                    product[brand][coffee].quantity = quantityIn - quantity;
                }
            }

        } else if (command === 'REPORT') {

            for (let key in product) {
                let allProduct = `${key}:`;
                for (let keyInner in product[key]) {
                    let quantity = product[key][keyInner].quantity;
                    let date = product[key][keyInner].date;
                    allProduct += ` ${keyInner} - ${date} - ${quantity}.`
                }

                let br = document.createElement("br");
                document.querySelectorAll('section div')[0].children[1].innerHTML += allProduct;
                document.querySelectorAll('section div')[0].children[1].appendChild(br);
            }
        } else if (command === 'INSPECTION') {

            let ordered = {};
            Object.keys(product).sort().forEach(function (key) {
                ordered[key] = product[key];
            });

            for (let brand in ordered) {
                let allProduct = `${brand}:`;

                let byQuantity = Object.keys(ordered[brand])
                    .sort((a, b) => ordered[brand][b].quantity - ordered[brand][a].quantity);

                for (let innerKey of byQuantity) {
                    allProduct += ` ${innerKey} - ${ordered[brand][innerKey].date} - ${ordered[brand][innerKey].quantity}.`;
                }
                let br = document.createElement("br");
                document.querySelectorAll('section div')[1].children[1].innerHTML += allProduct;
                document.querySelectorAll('section div')[1].children[1].appendChild(br);
            }
        }
    }
}


