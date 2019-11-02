function solve(input) {
    let object = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    };

    let diff = input[0] - object[input[1]];

    if (diff > 40) {
        console.log('reckless driving ');
    } else if (diff > 20) {
        console.log('excessive speeding');
    } else  if (diff <= 20 && diff > 0){
        console.log('speeding');
    }
}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);
