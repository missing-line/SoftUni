function attachEventsListeners() {

    let daysBtn = document.getElementById('daysBtn');

    daysBtn.addEventListener('click', function () {
        let value = +document.getElementById('days').value;
        if (value) {
            document.getElementById('hours').value = value * 24;
            document.getElementById('minutes').value = +document.getElementById('hours').value * 60;
            document.getElementById('seconds').value = +document.getElementById('minutes').value * 60
        }
    });

    let hoursBtn = document.getElementById('hoursBtn');

    hoursBtn.addEventListener('click', function () {
        let value = +document.getElementById('hours').value;
        if (value) {
            document.getElementById('days').value = value / 24;
            document.getElementById('minutes').value = +document.getElementById('hours').value * 60;
            document.getElementById('seconds').value = +document.getElementById('minutes').value * 60
        }
    });

    let minutesBtn = document.getElementById('minutesBtn');

    minutesBtn.addEventListener('click', function () {
        let value = +document.getElementById('minutes').value;
        if (value) {

            document.getElementById('seconds').value = +document.getElementById('minutes').value * 60;
            document.getElementById('hours').value = +document.getElementById('minutes').value / 60;
            document.getElementById('days').value = document.getElementById('hours').value / 24;
        }
    })

    let secondsBtn = document.getElementById('secondsBtn');

    secondsBtn.addEventListener('click', function () {
        let value = +document.getElementById('seconds').value;
        if (value) {

            document.getElementById('minutes').value = value / 60;
            document.getElementById('hours').value = +document.getElementById('minutes').value / 60;
            document.getElementById('days').value = document.getElementById('hours').value / 24;
        }
    })

}