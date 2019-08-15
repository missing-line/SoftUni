function makeReservation(containerId) {
    let submit = document.getElementById('submit');

    submit.addEventListener('click', function () {
        let fullName = document.getElementById('fullName').value;
        let email = document.getElementById('email').value;
        let phoneNumber = document.getElementById('phoneNumber').value;
        let address = document.getElementById('address').value;
        let postalCode = document.getElementById('postalCode').value;

        if (fullName && email) {
            let name = document.createElement('li');
            name.textContent = `Name: ${fullName}`;
            let mail = document.createElement('li');
            mail.textContent = `E-mail: ${email}`;
            let phone = document.createElement('li');
            phone.textContent = `Phone: ${phoneNumber}`;
            let addrss = document.createElement('li');
            addrss.textContent = `Address: ${address}`;
            let postal = document.createElement('li');
            postal.textContent = `Postal Code: ${postalCode}`;

            document.querySelector('#infoPreview').appendChild(name);
            document.querySelector('#infoPreview').appendChild(mail);
            document.querySelector('#infoPreview').appendChild(phone);
            document.querySelector('#infoPreview').appendChild(addrss);
            document.querySelector('#infoPreview').appendChild(postal);

            document.getElementById('fullName').value = '';
            document.getElementById('email').value = '';
            document.getElementById('phoneNumber').value = '';
            document.getElementById('address').value = '';
            document.getElementById('postalCode').value = '';

            submit.disabled = true;
            document.getElementById('edit').disabled = false;
            document.getElementById('continue').disabled = false;
            //edin button...
            document.getElementById('edit').addEventListener('click', function () {
                let childrenName = document.querySelector('#infoPreview').children[0].textContent.split(' ').splice(1).join(' ');
                document.getElementById('fullName').value = childrenName;
                let childrenEmail = document.querySelector('#infoPreview').children[1].textContent.split(' ')[1];
                document.getElementById('email').value = childrenEmail;
                let phoneNumber = document.querySelector('#infoPreview').children[2].textContent.split(' ').splice(1).join(' ');
                document.getElementById('phoneNumber').value = phoneNumber;
                let address = document.querySelector('#infoPreview').children[3].textContent.split(' ').splice(1).join(' ');
                document.getElementById('address').value = address;
                let postalCode = document.querySelector('#infoPreview').children[4].textContent.split(' ').splice(1).pop();
                document.getElementById('postalCode').value = postalCode;


                while (document.querySelector('#infoPreview').firstChild)
                    document.querySelector('#infoPreview').firstChild.remove();

                document.getElementById('edit').disabled = true;
                document.getElementById('continue').disabled = true;
                submit.disabled = false;
            })

            //continue button..
            document.getElementById('continue').addEventListener('click', function () {
                submit.disabled = true;
                document.getElementById('edit').disabled = true;
                document.getElementById('continue').disabled = true;

                let h2 = document.createElement('h2');
                h2.textContent = 'Payment details';

                let select = document.createElement('select');
                select.setAttribute('id', 'paymentOptions');
                select.setAttribute('class', 'custom-select');

                let option = document.createElement('option');
                option.setAttribute('selected', '');
                option.setAttribute('disabled', '');
                option.setAttribute('hidden', '');
                option.textContent = 'Choose';
                select.appendChild(option);

                let optionCard = document.createElement('option');
                optionCard.value = 'creditCard';
                optionCard.textContent = 'Credit Card';
                select.appendChild(optionCard);

                let optionTransfer = document.createElement('option');
                optionTransfer.value = 'bankTransfer';
                optionTransfer.textContent = 'Bank Transfer';
                select.appendChild(optionTransfer);

                document.getElementById('container').appendChild(h2);
                document.getElementById('container').appendChild(select);

                let getSelect = document.getElementById('paymentOptions');

                let div = document.createElement('div');
                div.setAttribute('id', 'extraDetails');
                document.getElementById('container').appendChild(div);
                //////                                                  //////
                getSelect.addEventListener('click', function () {

                    while (document.querySelector('#extraDetails').firstChild)
                        document.querySelector('#extraDetails').firstChild.remove();

                    if (getSelect.options[getSelect.selectedIndex].textContent === 'Credit Card') {

                        let input = document.createElement('input');
                        let br = document.createElement('br');
                        let inputDiv = document.createElement('div');
                        inputDiv.setAttribute('class', 'inputLabel');
                        inputDiv.innerHTML = 'Card Number';
                        inputDiv.appendChild(input);

                        let input1 = document.createElement('input');
                        let br1 = document.createElement('br');
                        let inputDate = document.createElement('div');
                        inputDate.setAttribute('class', 'inputLabel');
                        inputDate.innerHTML = 'Expiration Date';
                        inputDate.appendChild(input1);

                        let input2 = document.createElement('input');
                        let br2 = document.createElement('br');
                        let inputSecurity = document.createElement('div');
                        inputSecurity.setAttribute('class', 'inputLabel');
                        inputSecurity.innerHTML = 'Security Date';
                        inputSecurity.appendChild(input2);

                        div.appendChild(inputDiv);
                        div.appendChild(br);
                        div.appendChild(inputDate);
                        div.appendChild(br1);
                        div.appendChild(inputSecurity);
                        div.appendChild(br2);

                    } else if (getSelect.options[getSelect.selectedIndex].textContent === 'Bank Transfer') {
                        let br = document.createElement('br');
                        let p = document.createElement('p');
                        let node = document.createTextNode('You have 48 hours to transfer the amount to:');
                        let node1 = document.createTextNode('IBAN: GR96 0810 0010 0000 0123 4567 890');

                        p.appendChild(node);
                        p.appendChild(br);
                        p.appendChild(node1);
                        div.appendChild(p);
                    }
                    let btn = document.createElement('button');
                    btn.setAttribute('id', 'checkOut');
                    btn.textContent = 'Check Out';
                    div.appendChild(btn);

                    document.getElementById('checkOut').addEventListener('click', function () {
                        while (document.getElementById('wrapper').firstChild) {
                            document.getElementById('wrapper').firstChild.remove();
                        }

                        let h4 = document.createElement('h4');
                        h4.textContent = 'Thank you for your reservation!';
                        document.getElementById('wrapper').appendChild(h4);
                    })
                });
            })
        }
    });
}