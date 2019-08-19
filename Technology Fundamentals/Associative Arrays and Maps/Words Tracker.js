function solve(input) {
    let map = new Map();
    let arr = input[0].split(' ');
    for (let i = 0; i < arr.length; i++) {
        if (!map.has(arr[i])){
            map.set(arr[i],Number(0))
        }
    }

    for (let i = 1; i <= input.length - 1; i++) {
        if (map.has(input[i])){
            let getValue = map.get(input[i]);
            getValue++;
            map.set(input[i],getValue)
        }
    }
    let sorted = [...map].sort((a,b) => b[1] - a[1]);

    for (let [key,value] of sorted){
        console.log(`${key} - ${value}`)
    }
}

solve(['this sentence',
    'In','this','sentence','you','have','to','count','the','occurances','of','the'
    ,'words','this','and','because','this','is','your','task',]
);