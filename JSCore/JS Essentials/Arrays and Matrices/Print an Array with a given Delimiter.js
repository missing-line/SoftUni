function solve(input) {

    let delimiter = input[input.length - 1];
    let arr = input.slice(0, input.length - 1);
    console.log(arr.join(`${delimiter}`));
}

solve(
    ['One',
        'Two',
        'Three',
        'Four',
        'Five',
        '-']
);

solve(
    ['How about no?',
        'I',
        'will',
        'not',
        'do',
        'it!',
        '_']

);