function addDestination() {
    let city = document.getElementsByTagName('input')[0].value;
    let country = document.getElementsByTagName('input')[1].value;
    console.log(city);
    if (city && country) {
        let season = document.getElementById('seasons').options[document.getElementById('seasons').selectedIndex].textContent;

        let body = document.getElementById('destinationsList');

        let tr = document.createElement('tr');
        let td1 = document.createElement('td');
        td1.textContent = `${city}, ${country}`;

        let td2 = document.createElement('td');
        td2.textContent = season;

        tr.appendChild(td1);
        tr.appendChild(td2);

        body.appendChild(tr);

        let box = document.getElementById(`${season.toLowerCase()}`).value;
        document.getElementById(`${season.toLowerCase()}`).value++;

        document.getElementsByTagName('input')[0].value = '';
        document.getElementsByTagName('input')[1].value = '';
    }
}
