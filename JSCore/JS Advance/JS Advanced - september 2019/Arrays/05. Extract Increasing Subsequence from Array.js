function solve(input) {

    let arr = input.reduce(function (a, b) {
        if (a.length === 0)
            a.push(b);
        else if (a[a.length - 1] <= b)
            a.push(b);

        return a;
    }, []);

    console.log(arr.join('\n'));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);

solve([
    20,
    3,
    2,
    15,
    6,
    1
    ]
);