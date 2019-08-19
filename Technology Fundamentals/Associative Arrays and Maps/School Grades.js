function solve(input) {
    let map = new Map();
    for (let i = 0; i < input.length; i++) {
        let curr = input[i].split(' ');
        let name = curr[0];
        let grades = [];
        for (let j = 1; j < curr.length; j++) {
            grades.push(Number(curr[j]));
        }
        if (!map.has(name)) {
            map.set(name, grades);
        }
        else {
            let oldGrades = map.get(name);
            for (let j = 0; j < grades.length; j++) {
                oldGrades.push(grades[j]);
            }
            map.set(name, oldGrades);
        }
    }
    let sorted = [...map].sort((a, b) => average(a, b));
    for (let [key, value] of sorted) {
        console.log(`${key}: ${value.join(', ')}`);
    }

    function average(a, b) {
        let aSum = 0;
        let bSum = 0;
        for (let i = 0; i < a[1].length; i++) {
            aSum += a[1][i];
        }
        for (let i = 0; i < b[1].length; i++) {
            bSum += b[1][i];
        }
        let aAve = aSum / a[1].length;
        let bAve = bSum / b[1].length;
        return aAve - bAve;
    }
}

solve(['Lilly 4 6 6 5',
    'Tim 5 6',
    'Tammy 2 4 3',
    'Tim 6 6']
);