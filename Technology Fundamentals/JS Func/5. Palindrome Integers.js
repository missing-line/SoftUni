function solve(arr) {

    for (let i = 0; i < arr.length; i++) {
        let curr = arr[i].toString();
        let rev = "";
        for (let j = curr.length - 1; j >= 0 ; j--) {
            rev += curr[j];
        }
        if (rev === curr){
            console.log("true")
        }
        else{
            console.log("false") ;
        }
    }
}

solve([123, 323, 421, 121]);;