function solve(input) {
    let element = 0;
    let result = [];

    input.forEach(x => {
        element++;

        if(x === 'add')
            result.push(element);
        else if(x === 'remove' && result.length !== 0)
            result.pop();
    });

    console.log(result.length> 0 ? result.join('\n') : 'Empty');
}

solve(['add',
    'add',
    'remove',
    'add',
    'add']

);

solve(['remove','remove','remove']);