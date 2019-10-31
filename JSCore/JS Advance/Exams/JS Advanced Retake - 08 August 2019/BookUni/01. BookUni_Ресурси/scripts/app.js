function solve() {

    let btn = document.getElementsByTagName('button')[0];

    btn.addEventListener('click', function (e) {

        let fields = Array.from(document.getElementsByTagName('input'));

        let title = fields[0].value;
        let year = +fields[1].value;
        let price = +fields[2].value;

        if (!title || year <= 0 || price <= 0) {
            return;
        }

        let addOldBook = document.querySelector('#outputs').children[0];
        let addNewBook = document.querySelector('#outputs').children[1];

        let p = createElement('p');
        p.textContent = `${title} [${year}]`;

        let buy = createElement('button');
        buy.textContent = `Buy it only for ${year >= 2000 ? price.toFixed(2) : (price -= price * 0.15).toFixed(2)} BGN`;
        buy.addEventListener('click', buyBook);

        let div = document.createElement('div');
        div.className = 'book';

        div.appendChild(p);
        div.appendChild(buy);

        if (year >= 2000) {

            let oldSection = createElement('button');
            oldSection.textContent = `Move to old section`;
            oldSection.addEventListener('click', moveBook);
            div.appendChild(oldSection);
            addNewBook.children[1].appendChild(div)

        } else
            addOldBook.children[1].appendChild(div);

        function moveBook(e) {
            let target = e.target;
            let list = target.parentElement;
            list.removeChild(list.childNodes[2]);
            list.childNodes[1]
                .textContent = `Buy it only for ${(price -= price * 0.15).toFixed(2)} BGN`;
            addOldBook.children[1].appendChild(list);
        }

        function buyBook(e) {
            let target = e.target;

            let total = +document.querySelectorAll('h1')[1]
                .textContent
                .split(' ')[3];

            document.querySelectorAll('h1')[1]
                .textContent = `Total Store Profit: ${(price + total).toFixed(2)} BGN`;

            target.parentElement.remove();
        }

        e.preventDefault();
    });

    function createElement(element) {
        return document.createElement(`${element}`)
    }
}


