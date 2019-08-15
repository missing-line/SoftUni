function solve(input) {

    let currentSpeed = input[0];
    let area = input[1];
    if (area === "city") {
        if (currentSpeed <= 50) {
            console.log();
        }
        else if (currentSpeed > 50 && currentSpeed <= 70) {
            console.log("speeding");
        }
        else if (currentSpeed > 70 && currentSpeed <= 90) {
            console.log("excessive speeding ");
        }
        else {
            console.log("reckless driving");
        }}
    else if (area === "motorway") {
        if (currentSpeed <= 130) {
            console.log();
        }
        else if (currentSpeed > 130 && currentSpeed <= 150) {
            console.log("speeding");
        }
        else if (currentSpeed > 150 && currentSpeed <= 170) {
            console.log("excessive speeding ");
        }
        else {
            console.log("reckless driving");
        }
    }
    else if (area === "interstate") {
        if (currentSpeed <= 90) {
            console.log();
        }
        else if (currentSpeed > 90 && currentSpeed <= 110) {
            console.log("speeding");
        }
        else if (currentSpeed > 110 && currentSpeed <= 130) {
            console.log("excessive speeding ");
        }
        else {
            console.log("reckless driving");
        }
    }
    else if (area === "residential") {
        if (currentSpeed <= 20) {
            console.log();
        }
        else if (currentSpeed > 20 && currentSpeed <= 40) {
            console.log("speeding");
        }
        else if (currentSpeed > 40 && currentSpeed <= 60) {
            console.log("excessive speeding ");
        }
        else {
            console.log("reckless driving");
        }
    }
};

solve([160, 'city']);

//•	On the motorway the limit is 130 km/h
//•	On the interstate the limit is 90 km/h
//•	In the city the limit is 50 km/h
//•	Within a residential area the limit is 20 km/h
