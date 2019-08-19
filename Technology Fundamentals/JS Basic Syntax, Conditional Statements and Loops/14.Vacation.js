function solve(n,type,day) {
    let price = 0;
    if (type === "Students") {
        if (day === "Friday")
            price = 8.45;
        else if (day ==="Saturday")
            price = 9.80;
        else if (day === "Sunday")
            price = 10.46;
        if (n >= 30)
            price  -= (price * 0.15);
    }
    else if (type === "Business"){
        if (day === "Friday")
            price = 10.90;
        else if (day ==="Saturday")
            price = 15.60;
        else if (day === "Sunday")
            price = 16;
        if (n >= 100)
            n -= 10;
    }
    else if (type === "Regular"){
        if (day === "Friday")
            price = 15;
        else if (day ==="Saturday")
            price = 20;
        else if (day === "Sunday")
            price = 22.50;
        if (n >= 10 && n <= 20)
            price  -= (price * 0.05);
    }
    console.log(`Total price: ${(price * n).toFixed(2)}`);
}
