function solve() {

    let fans = 0;
    let money = 0;

    let section = document.querySelectorAll('section');
    let area = document.getElementById('output');
    let divElement = document.getElementById('summary');

    divElement.querySelector('button').addEventListener('click', function () {
        let spanElement = divElement.querySelector('span');
        spanElement.textContent = `${money} leva, ${fans} fans.`;
    });

    for (let i = 0; i < section.length; i++) {
        let tr = section[i].querySelectorAll('table tbody tr');
        for (let j = 0; j < tr.length; j++) {
            let children = Array.from(tr[j].children);
            for (let k = 0; k < children.length; k++) {
                children[k].addEventListener('click', function (e) {
                    let btn = e.target;
                    let tableName = section[i].className;
                    let sector = getSector(k);
                    let style = btn.getAttribute('style');
                    if (style) {
                        area.textContent += ` Seat ${btn.textContent} in zone ${tableName} sector ${sector} is unavailable.\n`;
                    } else {
                        fans++;
                        btn.style.color = 'rgb(255,0,0)';
                        if (tableName !== 'VIP') {
                            if (sector === 'A')
                                money += 10;
                            else if (sector === 'B')
                                money += 7;
                            else if (sector === 'C')
                                money += 5;
                        } else {
                            if (sector === 'A')
                                money += 25;
                            else if (sector === 'B')
                                money += 15;
                            else if (sector === 'C')
                                money += 10;
                        }
                        area.textContent += ` Seat ${btn.textContent} in zone ${tableName} sector ${sector} was taken.\n`;
                    }
                })
            }
        }
    };


    function getSector(n) {
        if (n === 0) {
            return 'A';
        } else if (n === 1) {
            return 'B';
        } else {
            return 'C';
        }
    }
}