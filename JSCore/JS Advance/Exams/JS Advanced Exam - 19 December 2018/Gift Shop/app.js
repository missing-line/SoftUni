function solution() {

    let toy = document.getElementById('toyType').value;
    let price = document.getElementById('toyPrice').value;
    let description = document.getElementById('toyDescription').value;

    if (toy && !isNaN(price) && description.length > 0 && description.length <= 50) {
        //christmasGiftShop
        let div = document.createElement('div');
        div.className = 'gift';

        let img = document.createElement('img');
        img.src = 'gift.png';
        div.appendChild(img);

        let h2 = document.createElement('h2');
        h2.textContent = toy;
        div.appendChild(h2);

        let p = document.createElement('p');
        p.textContent = description;
        div.appendChild(p);

        let button = document.createElement('button');
        button.textContent = `Buy it for $${price}`;
        button.addEventListener('click', function () {
            this.parentElement.remove();
        });

        div.appendChild(button);

        document.getElementById('christmasGiftShop').appendChild(div);
    }
    document.getElementById('toyType').value = '';
    document.getElementById('toyPrice').value = '';
    document.getElementById('toyDescription').value = '';

}