function solve(n, k) {
    let arr = [1];

    for (let i = 1; i < n; i++) {
        let startIndex = Math.max(0, i - k);
        let tempArray = arr.slice(startIndex, startIndex + n);
        let sum = tempArray.reduce((a, b)=>a + b);
        arr.push(sum);
    }

    console.log(arr.join(' '));
}

solve(9, 5);