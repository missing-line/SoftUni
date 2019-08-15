function solve(input, command) {
    command = command.split(' ');
    let matrix = input.slice(1);

    if (command[0] === 'sort') {
        if (input[0].includes(command[1])) {
            let index = input[0].indexOf(command[1]);
            let sort = matrix.sort((a, b) => a[index].localeCompare(b[index]));
            console.log(input[0].join(' | '));
            for (let i = 0; i < sort.length; i++) {
                console.log(sort[i].join(' | '));
            }
        }
    } else if (command[0] === 'hide') {
        if (input[0].includes(command[1])) {
            let index = input[0].indexOf(command[1]);
            for (let i = 0; i < input.length; i++) {
                input[i].splice(index, 1);
                console.log(input[i].join(' | '));
            }
        }
    } else if (command[0] === 'filter') {
        let cell = command[1];
        if (input[0].includes(cell)) {
            let index = input[0].indexOf(cell);
            console.log(input[0].join(' | '));
            for (let i = 0; i < matrix.length; i++) {
                if (matrix[i][index] === command[2])
                    console.log(matrix[i].join(' | '));
            }
        }
    }
}


solve([['firstName', 'age', 'grade', 'course'],
        ['Peter', '25', '5.00', 'JS-Core'],
        ['George', '34', '6.00', 'Tech'],
        ['Marry', '28', '5.49', 'Ruby']],
    'filter firstName Marry'
);

