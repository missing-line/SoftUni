function solve(x) {

    let nums = x.toString();
    let array = Array.from(nums);

    let sum = array.reduce((a, b) => Number(a) + Number(b), 0);

    console.log(equals(array));
    console.log(sum);

    function equals(input) {
        let isEquals = true;
        for (let i = 1; i < input.length; i++) {
            if (input[0] !== input[i]){
                isEquals = false;
                break;
            }
        }

        return isEquals;
    }
}

solve(2222222);