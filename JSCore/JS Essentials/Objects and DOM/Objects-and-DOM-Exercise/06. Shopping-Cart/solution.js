function solve() {
    let total = 0;
    let list = [];
    Array.from(document.getElementsByTagName('button')).forEach((x) => {
        x.addEventListener('click', clickEvent)
    });

    function clickEvent(e) {
        let nameOfClass = e.target;
        if (nameOfClass.className !== 'checkout') {
            let price = Number(nameOfClass.parentElement.parentElement.children[3].textContent);
            console.log(price);
            let nameOFProduct = nameOfClass.parentElement.parentElement.children[1].children[0].textContent;
            if (!list.includes(nameOFProduct))
                list.push(nameOFProduct);
            total += price;
            document.querySelector('textarea').value += `Added ${nameOFProduct} for ${price.toFixed(2)} to the cart.\n`;
        } else {
            document.querySelector('textarea').value += `You bought ${list.join(', ')} for ${total.toFixed(2)}.`;
            Array.from(document.getElementsByTagName('button')).forEach((x) => {
                x.removeEventListener('click', clickEvent);
            });
        }
    }
}
