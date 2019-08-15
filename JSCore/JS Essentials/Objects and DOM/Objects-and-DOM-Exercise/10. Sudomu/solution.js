function solve() {

    let matrix = [];
    let table = document.querySelector('tbody').rows;
    let buttons = Array.from(document.querySelectorAll('#exercise button'));

    buttons[0].addEventListener('click', function () {
        // fill matrix
        for (let i = 0; i < table.length; i++) {
            let row = Array.from(table[i].cells);
            for (let j = 0; j < row.length; j++) {
                let value = row[j].children;
                row[j] = value[0].value;
            }
            matrix.push(row);
        }
        let isValidRows = true;
        let isValidCols = true;
        // validate rows and cols
        for (let i = 0; i < matrix.length; i++) {
            let row = matrix[i];
            if (!(row.includes('1') && row.includes('2') && row.includes('3'))) {
                isValidRows = false;
                break;
            }
        }
        for (let i = 0; i < matrix.length; i++) {
            let col = getCol(matrix, i);
            if (!(col.includes('1') && col.includes('2') && col.includes('3'))) {
                isValidCols = false;
                break;
            }
        }
        // result output
        let result = Array.from(document.querySelector('#check').children)[0];
        if (isValidCols === true && isValidRows === true) {
            result.textContent = 'You solve it! Congratulations!';
            result.style.color = 'green';
            document.querySelector('table').style.border = '2px solid green';
        } else {
            result.textContent = 'NOP! You are not done yet.\.\.';
            result.style.color = 'red';
            document.querySelector('table').style.border = '2px solid red';
        }
    });
   //clear button
    buttons[1].addEventListener('click', function () {
        for (let i = 0; i < table.length; i++) {
            let row = Array.from(table[i].cells);
            for (let j = 0; j < row.length; j++) {
                let value = row[j].children;
                 value[0].value = '';
            }
            matrix.push(row);
        }
        let result = Array.from(document.querySelector('#check').children)[0];
        result.textContent = '';
        document.querySelector('table').style.border = '';
    });
    // get only col
    function getCol(matrix, col) {
        let column = [];
        for (let i = 0; i < matrix.length; i++) {
            column.push(matrix[i][col]);
        }
        return column;
    }
 }