function solve(capacity, array) {
    for (let i = 0; i < array.length - 1; i++) {
        let passengers = array[i];
        if (passengers > capacity) {
            array[i] = capacity;
            array[i + 1] += (passengers - capacity);
        }
    }

    let last = array[array.length - 1];
    if (last > capacity){
        array[array.length - 1] = capacity;
        console.log(array);
        console.log(`Could not fit ${last - capacity} passengers`)
    } else {
        console.log(array);
        console.log(`All passengers aboard`);
    }
}

solve(10, [9, 39, 1, 0, 0]);

solve(6, [5, 15, 2]);