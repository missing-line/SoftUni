function solve(arr,n) {
    arr = arr[0].split(" ");
    for (let i = 0; i < arr.length; i++) {
        let first = Number(arr[i]);
        for (let j = i + 1; j < arr.length; j++) {
            let second = Number(arr[j]);
            if (first + second === Number(n)) {
                console.log(first);
                console.log(second);
            }
        }
    }
}
solve(['2 1 6 2 3 3 2 2 2 1'],'8');