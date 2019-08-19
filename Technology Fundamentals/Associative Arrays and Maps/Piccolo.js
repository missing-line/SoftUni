function solve(input) {
    let map =  new Map();
    map.set('cars',[]);

    for (let i = 0; i < input.length; i++) {
        let currCar = input[i].split(', ');
        let regNumber = currCar[1];
        if (currCar[0] === 'IN'){
            let arrValues = map.get('cars');
            if (!arrValues.includes(regNumber)){
                arrValues.push(regNumber);
                map.set('cars',arrValues);
            }
        }
        else{
            let arrValues = map.get('cars');
            if (arrValues.includes(regNumber)){
                let index = arrValues.indexOf(regNumber);
                arrValues.splice(index,1);
                map.set('cars',arrValues);
            }
        }
    }
    let arrValues = map.get('cars');
    if (arrValues.length === 0){
        console.log('Parking Lot is Empty');
        return;
    }
    for (let [key, value] of map){
        console.log(value.sort((a,b) => a.localeCompare(b)).join('\n'));
    }

}
solve(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']
);