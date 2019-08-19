function solve(input) {
    let map =  new Map();
    for (let i = 0; i < input.length; i++) {
        let currCompany = input[i].split(' -> ');
        if (!map.has(currCompany[0])){
            let array = [];
            array.push(currCompany[1]);
            map.set(currCompany[0],array);
        }
        else {
            let values = map.get(currCompany[0]);
            if (!values.includes(currCompany[1])) {
                values.push(currCompany[1]);
                map.set(currCompany[0], values);
            }
        }
    }

    let sorted =  [...map].sort((a,b) => a[0].localeCompare(b[0]));

    for (let [key,value] of sorted){
        console.log(key);
        for (let inner of value){
            console.log(`-- ${inner}`);
        }
    }
}

solve(['SoftUni -> AA12345',
        'SoftUni -> BB12345',
        'Microsoft -> CC12345',
        'HP -> BB12345'
    ]
);