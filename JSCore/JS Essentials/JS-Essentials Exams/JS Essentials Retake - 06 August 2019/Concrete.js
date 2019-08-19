function concrete(budget, concrete, discount) {

    const gravelPrice = (240 * 5) * concrete * 0.5;
    const sandPrice = (150 * 5) * concrete * 0.2;
    const cementPrice = (60 * 5) * concrete * 1.1;

    let price = gravelPrice + sandPrice + cementPrice;

    let discountPrice =  price * (1 - (discount / 100));

    if (discountPrice > budget) {
        discountPrice -= budget;
        console.log(`You can't buy all these things! You need ${(discountPrice).toFixed(2)} BGN more`);
        return;
    }

    console.log(
        [`The price without discount is ${price.toFixed(2)} BGN`,
            `Gravel: ${gravelPrice.toFixed(2)} BGN`,
            `Sand: ${sandPrice.toFixed(2)} BGN`,
            `Cement: ${cementPrice.toFixed(2)} BGN`]
            .join('\n')
    );

    if (price > 1000) {
        console.log(`The price with discount is ${discountPrice.toFixed(2)} BGN`)
    }
}

concrete(1500, 0.5, 10);

concrete(1500, 0.95, 3);

concrete(800, 3, 10);



