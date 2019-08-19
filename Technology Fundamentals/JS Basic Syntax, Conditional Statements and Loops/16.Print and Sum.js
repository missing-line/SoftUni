function solve(n, m) {
    let sum = 0;
    let arr = [];
    let count = 0;
    for (let i = n; i <= m; i++) {
        sum  += i;
        arr[count] = i;
        count++;
    }
    console.log(arr.join(" "));
    console.log(`Sum: ${sum}`);
}
