function solve(input) {
    let passLength = ValidateLength(input);
    let digitsAndLetters = DigitLetterValidate(input);
    let checkCountDigits = Count2Digits(input);
    if (passLength === 'true' && digitsAndLetters === 'true' && checkCountDigits === 'true') {
        console.log('Password is valid')
    }
    else {
        if (passLength !== 'true')
            console.log(passLength);
        if (digitsAndLetters !== 'true')
            console.log(digitsAndLetters);
        if (checkCountDigits !== 'true')
            console.log(checkCountDigits);

    }

    function Count2Digits(input) {
        let valid = 'Password must have at least 2 digits';
        let count = 0;
        for (let i = 0; i <input.length; i++) {
            let curr = input[i];
            if (!isNaN(+curr)){
                count++;
                if (count == 2) {
                    valid = 'true';
                    break;
                }
            }
        }
        return valid;
    }

    function DigitLetterValidate(input) {
        let valid = 'true';
        for (let i = 0; i < input.length; i++) {
            let curr = input[i];
            if (isNaN(+curr) && curr.toUpperCase() === curr.toLowerCase()) {
                valid = 'Password must consist only of letters and digits';
                break;
            }
        }
        return valid;
    }

    function ValidateLength(input) {
        let valid = 'true';
        if (input.length < 6 || input.length > 10) {
            valid = 'Password must be between 6 and 10 characters';
        }
        return valid;
    }
}

solve('logIn');