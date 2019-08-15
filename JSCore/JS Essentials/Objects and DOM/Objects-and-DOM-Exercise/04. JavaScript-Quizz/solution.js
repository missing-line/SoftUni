function solve() {

    let count = 0;
    let p = Array.from(document.getElementsByTagName('p'));
    let section = Array.from(document.getElementsByTagName('section'));

    section[0].addEventListener('click', function (e) {
        let element = e.target;
        if (element.tagName ==='P'){
            if (element.textContent === 'onclick'){
                count++;
            }
            section[0].style.display = 'none';
            section[1].style.display = 'block';
        }
    });

    section[1].addEventListener('click', function (e) {
        let element = e.target;
        if (element.tagName ==='P'){
            if (element.textContent === 'JSON.stringify()'){
                count++;
            }
            section[1].style.display = 'none';
            section[2].style.display = 'block';
        }
    });

    section[2].addEventListener('click', function (e) {
        let element = e.target;
        if (element.tagName ==='P'){
            if (element.textContent === 'A programming API for HTML and XML documents'){
                count++;
            }
            section[2].style.display = 'none';

            let h1Element = document.getElementsByTagName('h1')[1];

            if (count === 3) {
                h1Element.textContent = 'You are recognized as top JavaScript fan!';
            }
            else {
                h1Element.textContent = `You have ${count} right answers`;
            }
            document.querySelector('#results').style.display = 'block';
        }
    });

}




