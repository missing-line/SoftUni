function solve(input) {

    let num = 1;
    let arr = [];
    for (let i = 0; i < input.length; i++) {

        if (input[i] === 'add') {
            arr.push(num);
        } else {
            arr.pop();
        }
        num++;
    }
    if (arr.length === 0) {
        console.log('Empty');
        return;
    }
    console.log(arr.join('\n'));
}

solve(['add',
    'add',
    'add',
    'add']
);
solve(['add',
    'add',
    'remove',
    'add',
    'add']
);
solve(['remove',
    'remove',
    'remove']
);
