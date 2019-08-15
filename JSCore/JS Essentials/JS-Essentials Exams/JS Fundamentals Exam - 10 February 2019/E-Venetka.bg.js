function solve(input) {

    let obj = {};
    for (let i = 0; i < input.length; i++) {
        let town = input[i].town;
        if (!obj.hasOwnProperty(town)) {
            obj[town] = {
                'profit': 0,
                'vignette': 0,
            };
        }
        obj[town].profit += input[i].price;
        obj[town].vignette++;
    }

    let popularTown = Object.keys(obj).sort(function (a, b) {
        if (obj[a].profit !== obj[b].profit) {
            return obj[b].profit - obj[a].profit;
        } else if (obj[a].vignette !== obj[b].vignette) {
            return obj[b].vignette - obj[a].vignette;
        } else {
            return a.localeCompare(b);
        }
    })[0];
    console.log(`${popularTown} is most profitable - ${obj[popularTown].profit} BGN`);

    let model = {};
    for (let i = 0; i < input.length; i++) {
        let currObj = input[i];
        if (currObj.town === popularTown){
            if (!model.hasOwnProperty(currObj.model)) {
                model[currObj.model] = {
                    'counting': 0,
                    'vignette': 0,
                };
            }
            model[currObj.model].counting++;
            model[currObj.model].vignette = currObj.price;
        }
    }

    let popularModel = Object.keys(model).sort(function (a, b) {
        if (model[a].counting !== model[b].counting) {
            return model[b].counting - model[a].counting;
        } else if (model[a].vignette !== model[b].vignette) {
            return model[b].vignette - model[a].vignette;
        } else {
            return a.localeCompare(b);
        }
    })[0];

    let list = {};
    for (let i = 0; i < input.length; i++) {
        let town = input[i].town;
        if (input[i].model === popularModel) {
            if (!list.hasOwnProperty(town)) {
                list[town] = [];
            }
            list[town].push(input[i].regNumber);
        }
    }
    console.log(`Most driven model: ${popularModel}`);

    Object.keys(list).sort(function (a, b) {
        return a.localeCompare(b);
    }).forEach(x => {
        let regNumbers = list[x].sort(function (a, b) {
            return a.localeCompare(b)
        });
        console.log(`${x}: ${regNumbers.join(', ')}`);
    });
}

solve(
    [{model: 'BMW', regNumber: 'B1234SM', town: 'Varna', price: 2},
        {model: 'BMW', regNumber: 'C5959CZ', town: 'Sofia', price: 8},
        {model: 'Tesla', regNumber: 'NIKOLA', town: 'Burgas', price: 9},
        {model: 'BMW', regNumber: 'A3423SM', town: 'Varna', price: 3},
        {model: 'Lada', regNumber: 'SJSCA', town: 'Sofia', price: 3}]
);