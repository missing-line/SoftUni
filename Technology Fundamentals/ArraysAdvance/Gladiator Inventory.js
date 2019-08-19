function solve(input) {
    let arr = input[0].split(" ");

    for (let i = 1; i < input.length; i++) {
        let arrCurr = input[i].split(" ");
        if (arrCurr[0] === "Buy") {
            if (!arr.includes(arrCurr[1])) {
                arr.push(arrCurr[1]);
            }
        }
        else if (arrCurr[0] === "Trash") {
            if (arr.includes(arrCurr[1])) {
                let index = arr.indexOf(arrCurr[1]);
                arr.splice(index, 1)
            }
        }
        else if (arrCurr[0] === "Repair") {
            if (arr.includes(arrCurr[1])) {
                let index = arr.indexOf(arrCurr[1]);
                arr.splice(index, 1);
                arr.push(arrCurr[1]);
            }
        }
        else if (arrCurr[0] === "Upgrade") {
            let innerArray = arrCurr[1].split("-");
            if (arr.includes(innerArray[0])) {
                let index = arr.indexOf(innerArray[0]);
                arr.splice(index + 1, 0, `${innerArray[0]}:${innerArray[1]}`);
            }
        }
    }
    console.log(arr.join(" "));
}

solve(['SWORD Shield Spear',
    'Trash Bow',
    'Repair Shield',
    'Upgrade Helmet-V']
);