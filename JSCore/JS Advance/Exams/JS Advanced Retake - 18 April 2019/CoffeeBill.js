function addProduct() {

    let inputField = document.querySelectorAll('#add-product input')[0].value;
    let price = +document.querySelectorAll('#add-product input')[1].value;
    let totalSum = +Array.from(document.querySelector('tfoot tr').children)[1].textContent;

    if (inputField && price  0) {
        let tr = document.createElement('tr');
        let tdName = document.createElement('td');
        let tdPrice = document.createElement('td');

        tdName.textContent = inputField;
        tdPrice.textContent = `${price}`;


        tr.appendChild(tdName);
        tr.appendChild(tdPrice);
        document.querySelector('#product-list').appendChild(tr);
        totalSum += price;
        Array.from(document.querySelector('tfoot tr').children)[1].textContent = `${totalSum}`;

    }
    document.querySelectorAll('#add-product label input')[0].value = '';
    document.querySelectorAll('#add-product label input')[1].value = '';
}