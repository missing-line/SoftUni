function solve(input) {
    let map = new Map();

    for (let i = 0; i < input.length; i++) {
        let currTraver = input[i].split(/[> ]+/);
        let country = currTraver[0];
        let city = currTraver[1];
        let price = Number(currTraver[2]);
        if (!map.has(country)) {
            map.set(country, new Map([
                [city, price],
            ]))
        }
        else {
            let values = map.get(country);
            if (!values.has(city)) {
                values.set(city, price);
            }
            else {
                let innerValues = values.get(city);
                if (innerValues > price) {
                    innerValues = price;
                }
                values.set(city, innerValues);
            }
            map.set(country, values);
        }
    }
    let sorted = [...map].sort((a, b) => a[0].localeCompare(b[0]));
    let innerSort = [...sorted].sort((a, b) => a[2] - b[2]);
    let mapPrint = new Map();
    for (let [country, cities] of innerSort) {
        for (let [city, price] of cities) {
            if (!mapPrint.has(country)) {
                mapPrint.set(country, []);
                let values = mapPrint.get(country);
                values.push(`${city } -> ${price}`);
                mapPrint.set(country, values);
            }
            else {
                let values = mapPrint.get(country);
                    values.push(`${city } -> ${price}`);
                mapPrint.set(country, values);
            }
        }
    }

    for (let [key, value] of mapPrint) {
        console.log(`${key} -> ${value.join(' ')}`)
    }
}

solve(["Bulgaria > Sofia > 500",
    "Bulgaria > Sopot > 800",
    "France > Paris > 2000",
    "Albania > Tirana > 1000",
    "Bulgaria > Sofia > 200"]
);