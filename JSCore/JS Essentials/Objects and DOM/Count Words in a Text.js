function solve([input]) {
    let obj = {};
    let arr = input.split(/\W+/).filter(w => w !== "");

    for (let word of arr) {
        if (!obj.hasOwnProperty(word)) {
            obj[word] = 1;
        }
        else {
            obj[word] ++;
        }
    }
    console.log(JSON.stringify(obj));
}

//solve(
//    ['Far too slow',
//        'you\'re far too slow']
//);

solve(
    ['Far too slow, you\'re far too slow.']
);