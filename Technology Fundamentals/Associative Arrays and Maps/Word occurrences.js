function solve(input) {
    let map = new Map();
    for (let i = 0; i < input.length; i++) {
        let word = input[i];
        if (!map.has(word)) {
            map.set(word, 1);
        }
        else {
            let currValue = map.get(word);
            currValue++;
            map.set(word, currValue);
        }
    }
    let sorted = [...map].sort((a, b) => b[1] - a[1])

    for (let [key, value] of sorted) {
        console.log(`${key} -> ${value} times`)
    }
}

solve(["Here", "is", "the", "first", "sentence", "Here", "is", "another", "sentence", "And", "finally", "the", "third", "sentence"]);