function solve(number) {
    let num = number.toString();
    while (Average(num) < 5) {
        num += "9"
    }
    console.log(num);

    function Average(num) {
        let average = 0;
        for (let i = 0; i < num.length; i++) {
            average += Number(num[i]);
        }
        return average / num.length;
    }
}

solve(5835);