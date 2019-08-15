function solve(input) {

    let parts = {};
    let availableModelsForRepair = [];

    for (let i = 0; i < input.length; i++) {
        let arr = input[i].split(' ');
        let command = arr[0];
        let model = arr[1];
        if (command === 'addPart') {
            let typeOfPart = arr[2];
            let serialNUmberOfPArt = arr[3];
            if (!parts.hasOwnProperty(model)) {
                parts[model] = {};
            }
            if (!parts[model].hasOwnProperty(typeOfPart)) {
                parts[model][typeOfPart] = [];
            }
            parts[model][typeOfPart].push(serialNUmberOfPArt);
        } else if (command === 'repair') {
            if (availableModelsForRepair.includes(model)) {
                let client = JSON.parse(`${arr[2]}`);
                for (let key in client) {
                    let value = client[key];
                    if (parts.hasOwnProperty(model) && value === 'broken') {
                        if (parts[model].hasOwnProperty(key)) {
                            if (parts[model][key].length > 0) {
                                let getPart = parts[model][key].shift();
                                client[key] = getPart;
                            }
                        }
                    }
                }
                console.log(`${model} client - ${JSON.stringify(client)}`);

            } else {
                console.log(`${model} is not supported`);
            }
        } else if (command === 'instructions') {
            if (!availableModelsForRepair.includes(model)) {
                availableModelsForRepair.push(model);
            }
        }
    }

    let result = {};
    Object.keys(parts).sort().forEach(function(key) {
        result[key] = parts[key];
    });

    for (let key in result) {
        console.log(`${key} - ${JSON.stringify(result[key])}`);
    }
}

solve([
        'instructions bmw',
        'addPart opel engine GV1399SSS',
        'addPart opel transmission SMF556SRG',
        'addPart bmw engine GV1399SSS',
        'addPart bmw transmission SMF444ORG',
        'addPart opel transmission SMF444ORG',
        'instructions opel',
        'repair opel {"engine":"broken","transmission":"OP8766TRS"}',
        'repair bmw {"engine":"ENG999FPH","transmission":"broken","wheels":"broken"}'
    ]
);