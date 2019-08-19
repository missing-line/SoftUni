function solve(input) {
    let arr = [];
    for (let i = 0; i < input.length; i++) {
        let curr = input[i].split(' ');
        let name = curr[0];
        let number = curr[1];
        arr[name] = number;
    }
    for (let key in arr) {
        console.log(`${key} -> ${arr[key]}`)
    }
}

solve(['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344']
);