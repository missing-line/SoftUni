function solve() {
    let sum = 0;
    let courses = [];

    let obj = {
        'JS-Fundamentals': 170,
        'JS-Advanced': 180,
        'JS-Applications': 190,
        'JS-Web': 490,
    };

    let fund = document.querySelectorAll('input')[0];
    let advance = document.querySelectorAll('input')[1];
    let app = document.querySelectorAll('input')[2];
    let web = document.querySelectorAll('input')[3];

    let online = document.querySelectorAll('input')[5];

    let ul = document.querySelectorAll('.courseBody ul')[1];

    let btn = document.querySelector('button');

    btn.addEventListener('click', function () {

        if (advance.checked && fund.checked) {
            obj['JS-Advanced'] *= 0.9;
        }

        if (online.checked) {
            for (let key in obj) {
                obj[key] *= 0.94;
            }
        }
        if (fund.checked && advance.checked && app.checked) {
            obj['JS-Fundamentals'] *= 0.94;
            obj['JS-Advanced'] *= 0.94;
            obj['JS-Applications'] *= 0.94;
        }

        if (fund.checked) {
            courses.push('JS-Fundamentals');
            sum += obj['JS-Fundamentals']
        }
        if (advance.checked) {
            courses.push('JS-Advanced');
            sum += obj['JS-Advanced']
        }
        if (app.checked) {
            courses.push('JS-Applications');
            sum += obj['JS-Applications']
        }
        if (web.checked) {
            courses.push('JS-Web');
            sum += obj['JS-Web']
        }

        if (courses.length === 4) {
            courses.push('HTML and CSS');
        }

        for (let i = 0; i < courses.length; i++) {
            let li = document.createElement('li');
            li.textContent = courses[i];
            ul.appendChild(li);
        }
        document.querySelector('.courseFoot p').textContent = `Cost: ${Math.floor(sum).toFixed(2)} BGN`;
    })
}

solve();