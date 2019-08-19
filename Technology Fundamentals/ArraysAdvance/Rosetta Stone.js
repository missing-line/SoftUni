function solve(input) {
    
    let start = Number(input[0]) + 1;  
    let matrix = input.slice(1,start);
    let decryptMatrix = input.slice(start, input.length);
    for (let i = 1; i <= decryptMatrix.length; i++) {
        let currArr = decryptMatrix[i - 1].split(" ");
        let count = 1;
        for (let j = 0; j < currArr.length; j++) {
            if (count < start){

            }
        }

    }
}
solve([ '2',
    '59 36',
    '82 52',
    '4 18 25 19 8',
    '4 2 8 2 18',
    '23 14 22 0 22',
    '2 17 13 19 20',
    '0 9 0 22 22' ]
);