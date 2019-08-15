function solve(firstName, age, weight, height) {

    function bmi() {
        let kg = weight * 2.205;
        let inch = height / 2.54;
        return Math.round((kg / inch / inch) * 703);
    }
    function getStatus(bmi) {
        if (bmi < 18.5)
            return 'underweight';
        else if (bmi < 25)
            return 'normal';
        else if (bmi < 30)
            return 'overweight';
        else
            return 'obese';
    }
    let person = {
        'name': firstName,
        'personalInfo': {
            age,
            weight,
            height
        },
        'BMI': bmi(),
        'status': getStatus(bmi()),
    };

    if (person.status === 'obese')
        person.recommendation = 'admission required';

    return person;
}

console.log(solve('Peter', 29, 75, 182));
