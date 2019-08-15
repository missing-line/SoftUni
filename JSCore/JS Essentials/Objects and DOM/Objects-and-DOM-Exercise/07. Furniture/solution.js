function solve() {
    document.querySelectorAll('button')[0].addEventListener('click', addFurniture);

    function addFurniture() {
        let text = document.querySelectorAll('textarea')[0].value;
        if (text) {
            let arrayOfobj = JSON.parse(text);
            for (let obj of arrayOfobj) {

                let parent = document.querySelector('tbody');

                let tr = document.createElement('tr');

                let imgTd = document.createElement('td');
                imgTd.appendChild(document.createElement('img')).src = obj['img'];
                tr.appendChild(imgTd);

                let nameTd = document.createElement('td');
                nameTd.appendChild(document.createElement('p')).textContent = obj['name'];
                tr.appendChild(nameTd);

                let priceTd = document.createElement('td');
                priceTd.appendChild(document.createElement('p')).textContent = obj['price'];
                tr.appendChild(priceTd);

                let decFactorTd = document.createElement('td');
                decFactorTd.appendChild(document.createElement('p')).textContent = obj['decFactor'];
                tr.appendChild(decFactorTd);

                let checkTd = document.createElement('td');
                checkTd.appendChild(document.createElement('input')).setAttribute("type", "checkbox");
                tr.appendChild(checkTd);

                parent.appendChild(tr);
            }
        }
    }

    document.getElementsByTagName('button')[1].addEventListener('click', showCheckedItems);

    function showCheckedItems() {
        let checkedRows = [];
        Array.from(document.getElementsByTagName('input')).forEach((input) => {
            if (input.checked) {
                checkedRows.push(input);
            }
        });
        document.getElementsByTagName('textarea')[1].value = '';
        let arrayNames = [];
        let totalPrice = 0;
        let TotalDecFactor = 0;

        for (let row of checkedRows) {

            let parent = row.parentElement.parentElement;

            parent = Array.from(parent.children);
            console.log(parent);
            let name = parent[1].children[0].textContent;
            arrayNames.push(name);

            let price = Number(parent[2].children[0].textContent);
            totalPrice += price;

            let decFac = Number(parent[3].children[0].textContent);
            TotalDecFactor += decFac;
        }
        let averageDecFactor = TotalDecFactor / checkedRows.length;

        document.getElementsByTagName('textarea')[1].value = `Bought furniture: ${arrayNames.join(', ')}
Total price: ${totalPrice.toFixed(2)}
Average decoration factor: ${averageDecFactor}`;

    }
}