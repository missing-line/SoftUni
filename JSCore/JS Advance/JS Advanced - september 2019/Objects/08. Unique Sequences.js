function solve(input) {

    let unique = [];
    const reducer = ((a, b) => a + b);

    let arr = input.map(x => {
        return JSON.parse(x)
            .sort((a, b) => b - a)
    });

    for (let i of arr) {
        let sum = i.reduce(reducer);

        let check = unique.some(x => x.reduce(reducer) === sum);

        if (!check)
            unique.push(i);
    }

    unique.sort((a, b) => a.length - b.length);

    for (let i of unique){
        console.log(`[${i.join(', ')}]`);
    }
}

solve([
        "[-3, -2, -1, 0, 1, 2, 3, 4]",
        "[10, 1, -17, 0, 2, 13]",
        "[4, -3, 3, -2, 2, -1, 1, 0]"
    ]
);

