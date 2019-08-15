function solve() {

    document.querySelector('#create-offers').style.display = 'none';

    let btn = document.getElementById('loginBtn');
    let usernameLog = document.getElementById('username');
    let createBtn = document.getElementById('create-offer-Btn');


    btn.addEventListener('click', event);

    function event(e) {
        let target = e.target;
        if (target.textContent === 'Login') {

            if (usernameLog.value.length >= 4 && usernameLog.value.length <= 10) {

                document.getElementById('create-offers').style.display = 'block';
                document.getElementById('username').className += ' border-0 bg-light';
                document.getElementById('loginBtn').textContent = 'Logout';
                document.getElementById('username').value = `Hello, ${usernameLog.value}!`;
                document.getElementById('username').disabled = true;
                document.getElementById('notification').innerHTML = '';

                createBtn.addEventListener('click', function (e) {
                    let offer = document.getElementById('offerName').value;
                    let company = document.getElementById('company').value;
                    let description = document.getElementById('description').value;

                    if (offer && company && description) {

                        let offers = document.getElementById('offers');
                        let container = document.getElementById('offers-container');
                        let colDiv = document.createElement('div');
                        colDiv.className = 'col-3';

                        let divCard = document.createElement('div');
                        divCard.className = 'card text-white bg-dark mb-3 pb-3';

                        let divCardHeader = document.createElement('div');
                        divCardHeader.className = 'card-header';
                        divCardHeader.innerHTML = offer;

                        let divCardBody = document.createElement('div');
                        divCardBody.className = 'card-body';

                        let h5 = document.createElement('h5');
                        h5.className = 'card-title';
                        h5.textContent = company;

                        let p = document.createElement('p');
                        p.className = 'card-text';
                        p.textContent = description;

                        divCardBody.appendChild(h5);
                        divCardBody.appendChild(p);

                        divCard.appendChild(divCardHeader);
                        divCard.appendChild(divCardBody);

                        colDiv.appendChild(divCard);
                        container.appendChild(colDiv);
                        offers.appendChild(container);

                        document.getElementById('offerName').value = '';
                        document.getElementById('company').value = '';
                        document.getElementById('description').value = '';
                    }
                    e.preventDefault();
                });
            } else {
                document.getElementById('notification').innerHTML = 'The username length should be between 4 and 10 characters.';
            }
        } else {
            //return false;
            document.getElementById('create-offers').style.display = 'none';
            document.getElementById('loginBtn').textContent = 'Login';
            document.getElementById('username').disabled = false;
            document.querySelector('#username').className = 'form-control mr-sm-2';
            document.getElementById('username').value = '';

            let childes = Array.from(document.getElementById('offers-container').children);
            for (let i = 2; i < childes.length; i++) {
                document.querySelector('offers-container').removeChild(childes.childNodes[i]);
            }
        }
        e.preventDefault();
    }
}

solve()