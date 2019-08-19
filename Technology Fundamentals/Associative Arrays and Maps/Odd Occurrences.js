function solve(input) {
    let arr = input.split(' ');
    let map =  new Map();
    let result = [];
    for (let i = 0; i <= arr.length - 1; i++) {
        let curr = arr[i].toLowerCase();
        if (map.has(curr)){
            let value = map.get(curr);
            value++;
            map.set(curr,value);
        }
        else{
            map.set(curr,1);
        }
    }
    for (let [key,value] of map){
        if (value % 2 !== 0){
            result.push(key)
        }
    }
    console.log(result.join(' '))
}
solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');