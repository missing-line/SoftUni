function solve(a, b) {

    while (b != 0) {
        let old = b;
        b = a % b;
        a = old;
    }
    console.log(a);
}

solve(2154, 458);