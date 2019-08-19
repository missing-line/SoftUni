function solve(number) {
    let arr = [];
    let sum = 0;
    for (let i = 1; i < number; i++) {
        if (number % i === 0) {
                arr.push(i)
        }
    }
    for (let i = 0; i < arr.length; i++) {
        sum += arr[i];
    }
    if (sum === number){
        console.log(`We have a perfect number!`)
        //console.log(arr.join(" + "));
    }
    else{
        console.log(`It’s not so perfect.`)
    }

}

solve(1236498);