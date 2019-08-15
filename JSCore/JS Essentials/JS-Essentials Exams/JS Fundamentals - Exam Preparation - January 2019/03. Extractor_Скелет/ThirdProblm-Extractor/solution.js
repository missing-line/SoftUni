function solve() {
    let input = document.querySelector('#input');
    let btn = document.querySelectorAll('#main button')[0];

    let start = /^(\d+)/g;

    btn.addEventListener('click', function () {
        let text = input.value;
        let number = Number(start.exec(text)[0]);
        text = text.split(start)[2];

        text = text.slice(0, number);
        let lastElement = text[text.length - 1];
        text = text.split(lastElement);
        let second = text[1];
        let first = new RegExp(`[${text[0]}]+`, 'g');

        second = getString(second.split(first));
        second = replace(second);
        document.querySelector('#output').value = second;

    });

    function replace(text) {
        while (text.indexOf('#') !== -1) {
            text = text.replace('#', ' ');
        }
        return text;
    }

    function getString(text) {
        let newWord = '';
        for (let i = 0; i < text.length; i++) {
            newWord += text[i];
        }
        return newWord;
    }

}