function lockedProfile() {

    let profile = document.querySelectorAll('.profile');

    let firstBtn = document.querySelectorAll('button')[0];
    let secondBtn = document.querySelectorAll('button')[1];
    let thBtn = document.querySelectorAll('button')[2];

    firstBtn.addEventListener('click', function () {
        let unlock = profile[0].querySelectorAll('input')[1];
        if (unlock.checked) {
            if (firstBtn.textContent === 'Show more') {
                document.querySelector('#user1HiddenFields').style.display = 'block';
                firstBtn.textContent = 'Hide it';
            } else if (firstBtn.textContent === 'Hide it'){
                document.querySelector('#user1HiddenFields').style.display = 'none';
                firstBtn.textContent = 'Show more';
            }
        }
    });

    secondBtn.addEventListener('click', function () {
        let unlock = profile[1].querySelectorAll('input')[1];
        if (unlock.checked) {
            if (firstBtn.textContent === 'Show more') {
                document.querySelector('#user2HiddenFields').style.display = 'block';
                secondBtn.textContent = 'Hide it';
            } else if (firstBtn.textContent === 'Hide it'){
                document.querySelector('#user2HiddenFields').style.display = 'none';
                secondBtn.textContent = 'Show more';
            }
        }
    });

    thBtn.addEventListener('click', function () {
        let unlock = profile[2].querySelectorAll('input')[1];
        if (unlock.checked) {
            if (firstBtn.textContent === 'Show more') {
                document.querySelector('#user3HiddenFields').style.display = 'block';
                thBtn.textContent = 'Hide it';
            } else if (firstBtn.textContent === 'Hide it'){
                document.querySelector('#user3HiddenFields').style.display = 'none';
                thBtn.textContent = 'Show more';
            }
        }
    });
}