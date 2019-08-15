function solve() {

    let regex = /^(\d+|\d+\.\d+) [/\-+x] (\d+|\d+\.\d+)$/g;

    let expressionOutput = document.querySelector('#expressionOutput');
    let resultOutput = document.querySelector('#resultOutput');

    let button = document.querySelector('.top .clear');
    let keys = Array.from(document.querySelector('.keys').children);

    console.log(keys);

    button.addEventListener('click', clear);

    keys.forEach(x => {
        x.addEventListener('click', function (e) {
            let key = e.target;

            if (key.textContent === '=') {

                let text = expressionOutput.textContent;

                if (validate(text)) {
                    let first = text.indexOf(' ');
                    let second = text.lastIndexOf(' ');

                    let left = text.slice(0, first);
                    let right = text.slice(second + 1);
                    let operator = text[second - 1];

                    switch (operator) {
                        case 'x':
                            resultOutput.textContent = Number(left) * Number(right);
                            break;
                        case '/':
                            resultOutput.textContent = Number(left) / Number(right);
                            break;
                        case '-':
                            resultOutput.textContent = Number(left) - Number(right);
                            break;
                        case '+':
                            resultOutput.textContent = Number(left) + Number(right);
                            break;

                    }
                    //validate(text);
                }
                else {
                    resultOutput.textContent = 'NaN';
                }
            }
            else if (key.textContent === 'x' || key.textContent === '-' || key.textContent === '+' || key.textContent === '/') {
                expressionOutput.textContent += ' ' + key.textContent + ' ';
            }
            else {
                expressionOutput.textContent += key.textContent;
            }
        })
    });

    function validate(text) {

       return regex.test(text);
    }

    function clear() {
        document.getElementById('resultOutput').textContent = '';
        document.getElementById('expressionOutput').textContent = '';
    }
}
//function solve() {
//
//    let buttons = Array.from(document.getElementsByTagName('button'));
//    let clearButton = buttons.splice(0, 1);
//
//    let firstNumber = '';
//    let secondNumber = '';
//    let isItFirstNumber = true;
//    let operator = '';
//    let result = 0;
//
//    buttons.forEach(button => {
//        button.addEventListener('click', calculate)
//    });
//
//    clearButton[0].addEventListener('click', clear);
//
//
//    function calculate(e) {
//        let buttonValue = e.target.textContent;
//        let expressionOutput = document.getElementById('expressionOutput');
//
//        if (buttonValue === '=') {
//            if (firstNumber !== '' && secondNumber !== '' && operator.length === 1) {
//                switch (operator) {
//                    case 'x':
//                        result = Number(firstNumber) * Number(secondNumber);
//                        break;
//                    case '/':
//                        result = Number(firstNumber) / Number(secondNumber);
//                        break;
//                    case '-':
//                        result = Number(firstNumber) - Number(secondNumber);
//                        break;
//                    case '+':
//                        result = Number(firstNumber) + Number(secondNumber);
//                        break;
//                }
//            } else {
//                result = NaN;
//            }
//
//            document.getElementById('resultOutput').textContent = result;
//
//        } else if (buttonValue >= '0' && buttonValue <= '9' || buttonValue === '.') {
//            if (isItFirstNumber) {
//                firstNumber += buttonValue;
//            } else {
//                secondNumber += buttonValue;
//            }
//            expressionOutput.textContent += buttonValue;
//        } else {
//            isItFirstNumber = false;
//            operator += buttonValue;
//            expressionOutput.textContent += ` ${buttonValue} `;
//        }
//    }
//
//    function clear() {
//        document.getElementById('resultOutput').textContent = '';
//        document.getElementById('expressionOutput').textContent = '';
//    }
//}