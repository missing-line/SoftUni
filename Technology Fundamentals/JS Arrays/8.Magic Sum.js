function solve(arr) {
    let seq = arr[0].split(" ");
    let magic = Number(arr[1]);
    for (let i = 0; i < seq.length; i++) {
        let first = Number(seq[i]);
        for (let j = i + 1; j < seq.length; j++) {
            let second = Number(seq[j]);
            if (first + second === magic) {
                console.log(`${first} ${second}`);
            }
        }
    }
}

solve(['14 20 60 13 7 19 8', '27']);