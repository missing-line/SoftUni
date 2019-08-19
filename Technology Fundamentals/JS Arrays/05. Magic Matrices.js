function solve(arr) {

        let sum = Sum(arr[0]);

        for (let i = 0; i < arr[0].length; i++) {
            let sumCurr = 0;
            for (let j = 0; j < arr.length; j++) {
                sumCurr += arr[j][i];
            }
            if (sumCurr !== sum){
                console.log("false");
                return;
            }
        }

        for (let i = 0; i < arr.length; i++) {
            let sumCurr = 0;
            for (let j = 0; j < arr[i].length; j++) {
                sumCurr += arr[i][j];
            }
            if (sumCurr !== sum){
                console.log("false");
                return;
            }
        }

        console.log("true");

        function Sum(array) {
            let sum = 0;
            for (let i = 0; i < array.length; i++) {
                sum+=array[i];
            }
            return sum;
        }
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);