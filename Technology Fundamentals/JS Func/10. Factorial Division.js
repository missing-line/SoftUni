function solve(n1,n2) {
    let first = Factorial(n1);
    let second = Factorial(n2);
    console.log((first / second).toFixed(2))
    function Factorial(n1) {
        if (n1 === 1){
            return 1;
        }
        return n1 * Factorial(n1 - 1);
    }
}
solve(6,
2
);