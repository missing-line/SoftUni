function acceptance() {
    let btn = document.getElementById('acceptance');

    btn.addEventListener('click', function () {
        let company = document.querySelectorAll('input')[0].value;
        let product = document.querySelectorAll('input')[1].value;
        let quantity = document.querySelectorAll('input')[2].value;
        let scrape = document.querySelectorAll('input')[3].value;

        if (company && product && quantity && scrape) {
            quantity = +quantity;
            scrape = +scrape;
            if (!isNaN(quantity) &&
                !isNaN(scrape) && quantity - scrape > 0) {
                let p = document.createElement('p');
                p.textContent = `[${company}] ${product} - ${quantity - scrape} pieces`;

                let button = document.createElement('button');
                button.type = 'button';
                button.textContent = `Out of stock`;

                let div = document.createElement('div');
                div.appendChild(p);
                div.appendChild(button);
                document.querySelector('#warehouse').appendChild(div);

                document.querySelectorAll('input')[0].value = '';
                document.querySelectorAll('input')[1].value = '';
                document.querySelectorAll('input')[2].value = '';
                document.querySelectorAll('input')[3].value = '';

                button.addEventListener('click', function (e) {
                    let target = e.target;
                    let parent = target.parentElement;
                    parent.remove();
                })
            }
        }
    });
}