function solve(arr) {
    let object = {};

    for (let i = 0; i < arr.length; i += 2) {
        object[arr[i]] = Number(arr[i + 1])
    }

    console.log(object);
}

solve(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);