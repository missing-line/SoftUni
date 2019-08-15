function solve() {
    let section = document.getElementById('selectMenuTo');

    let optionBinary = document.createElement('option');
    optionBinary.value = 'binary';
    optionBinary.text = 'Binary';
    section.add(optionBinary);

    let optionHexadecimal = document.createElement('option');
    optionHexadecimal.value = 'hexadecimal';
    optionHexadecimal.text = 'Hexadecimal';
    section.add(optionHexadecimal);

    let button = Array.from(document.getElementsByTagName('button'));

    button[0].addEventListener('click', function () {

        let inputLine = document.getElementById('input');
        let valueConvector = section.options[section.selectedIndex].text;

        let result;
        switch (valueConvector) {
            case 'Binary':
                result = (inputLine.value >>> 0).toString(2);
                break;
            case 'Hexadecimal':
                result = (inputLine.value >>> 0).toString(16).toUpperCase();
                break;
        }
        document.querySelector('#result').value = result;
    })
}