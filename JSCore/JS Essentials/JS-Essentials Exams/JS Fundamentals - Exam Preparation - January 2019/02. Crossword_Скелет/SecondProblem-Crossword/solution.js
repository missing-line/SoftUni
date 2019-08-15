function solve() {
    let set = document.querySelectorAll('fieldset');


    for (let i = 0; i < set.length; i++) {
        let btn = set[i].querySelector('button');
        btn.addEventListener('click', function (e) {
            let button = e.target;
            let text = document.querySelector('#input').value;
            text = text.split('');

            if (button.textContent === 'Filter') {
                let option = document.getElementById('filterSecondaryCmd').value;
                let index = document.getElementById('filterPosition').value;
                //text = text.split('');
                if (option === 'uppercase') {
                    text = text.filter(x => x === x.toUpperCase() && isNaN(x));
                } else if (option === 'lowercase') {
                    text = text.filter(x => x === x.toLocaleLowerCase() && isNaN(x)) ;
                } else if (option === 'nums') {
                    text = text.filter(x => !isNaN(x));
                }
                document.querySelector('#output').children[0].textContent += text[index - 1];
            }
            else if (button.textContent === 'Sort') {
                let option = document.getElementById('sortSecondaryCmd').value;
                let index = Number(document.getElementById('sortPosition').value);
                let arr = [];
                if (option === 'A') {
                    arr = text.sort();
                } else if (option === 'Z') {
                    arr = text.sort().reverse();
                }
                document.querySelector('#output').children[0].textContent += arr[index - 1];
            }
            else if (button.textContent === 'Rotate') {
                let jump = document.getElementById('rotateSecondaryCmd').value;
                let index = document.getElementById('rotatePosition').value;
                let step = jump % text.length;

                for (let i = 0; i < step; i++) {
                    let lastElement = text[text.length - 1];
                    for (let j = text.length - 1; j >= 1; j--) {
                        text[j] = text[j - 1];
                    }
                    text[0] = lastElement;
                }
                document.querySelector('#output').children[0].textContent += text[index - 1];
            }
            else if (button.textContent === 'Get') {
                let index = document.getElementById('getPosition').value;
                document.querySelector('#output').children[0].textContent += text[index - 1];
            }

            document.querySelector('#input').value = '';
        })
    }
}