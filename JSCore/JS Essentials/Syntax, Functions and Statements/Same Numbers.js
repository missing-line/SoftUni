function solve(a) {

    let number = a.toString();
    let isSame =  new Boolean(true);

    for (let i = 0; i < number.length - 1; i++) {
        if (number[i] !== number[i + 1]) {
                isSame = false;
                break;
        }
    }
    console.log(isSame.toString());
    console.log(sum(number));

    function sum() {
        let sum = 0;

        for (let i = 0; i < number.length; i++) {
            sum += Number(number[i]);
        }
        return sum;
    }
}

solve(1234);