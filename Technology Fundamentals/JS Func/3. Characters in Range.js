function solve(ch1,ch2) {
    let first =  ch1.charCodeAt(0);
    let second =  ch2.charCodeAt(0);
    let arr = [];
    if (first <= second){
        for (let i = first + 1; i < second; i++) {
            arr.push(String.fromCharCode(i));
        }
        return arr.join(" ");
    }
    else if(second < first){
        for (let i = second + 1; i < first; i++) {
            arr.push(String.fromCharCode(i));
        }
        return arr.join(" ");
    }
  // return arr.join(" ");
}

console.log(solve('C',
    '#'
));