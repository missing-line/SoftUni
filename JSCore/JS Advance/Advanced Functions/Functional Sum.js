let add = (function () {
    let sum = 0;
    function add(n) {
        sum += n;
        console.log(sum);
        return add;
    }

    add.toString = function () {
        return sum;
    };
    return add;
})();
add(1)(2)(3);


