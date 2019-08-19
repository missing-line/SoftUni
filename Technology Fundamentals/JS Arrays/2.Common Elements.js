function solve(arr1, arr2) {
    let arrResult = [];
    for (let i = 0; i < arr1.length; i++) {
        let curr = arr1[i];
        for (let j = 0; j < arr2.length; j++) {
            if (curr === arr2[j]) {
                arrResult.push(curr);
            }
        }
    }
    arrResult.forEach(function (element) {
        console.log(element);
    });
}

solve(["Hey", "hello", 2, 4, "Pesho", "e"],
    ["Pecho", 10, "hey", 4, "hello", "2"]);