function solve(arr) {
    let array = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === "add") {
            array.push(i + 1);
        }
        else if (arr[i] === "remove") {
            array.pop();
        }
    }
    if (array.length == 0){
        console.log("Empty")
        return;
    }
    console.log(array.join(" "));
}

solve(['remove', 'remove']);