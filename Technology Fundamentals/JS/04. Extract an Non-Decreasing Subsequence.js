function solve(arr) {

    for (let i = 1; i < arr.length; i++) {
        if (arr[i] < arr[i - 1]){
            arr.splice(i, 1);
            i--;
        }
    }
    console.log(arr.join(" "));
}
solve([ 20, 3, 2, 15, 6, 1]);