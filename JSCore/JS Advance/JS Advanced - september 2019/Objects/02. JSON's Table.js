function solve(input) {
    console.log('<table>');

    input.forEach(x => {
        let line = JSON.parse(x);

        console.log(' <tr>');

        Object.values(line).forEach(value => {
            console.log(`    <td>${value}</td>`);
        });

        console.log(' </tr>');
    });

    console.log('</table>');
}

solve(
    [
        '{"name":"Pesho","position":"Promenliva","salary":100000}',
        '{"name":"Teo","position":"Lecturer","salary":1000}',
        '{"name":"Georgi","position":"Lecturer","salary":1000}'
    ]
);