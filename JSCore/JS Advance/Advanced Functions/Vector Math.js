let solution = (function () {
    const add = ([a, b], [c, d]) => {
        return [a + c, b + d];
    };

    const multiply = ([a, b], n) => {
        return [a * n, b * n];
    };

    const length = ([a, b]) => {
        return Math.sqrt((a ** 2 + b ** 2));
    };

    const dot = ([a, b],[c,d]) => {
        return a * c + b * d;
    };
    const cross = ([a, b],[c,d]) => {
        return a * d - b * c;
    };

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
})();

console.log(solution.add([1, 3], [3, 4]));
console.log(solution.length([3, -4]));
console.log(solution.dot([1, 0], [0, -1]));
console.log(solution.cross([3, 7], [1, 0]));
console.log(solution.multiply([3.5, -2], 2));

