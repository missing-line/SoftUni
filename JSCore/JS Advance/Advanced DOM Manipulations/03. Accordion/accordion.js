function toggle() {
    let button = document.querySelector('.button').innerHTML;

    switch (button) {
        case 'More':
            document.querySelector('#extra').style.display = 'block';
            document.querySelector('.button').innerHTML = 'Less';
            break;
        case 'Less':
            document.querySelector('#extra').style.display = 'none';
            document.querySelector('.button').innerHTML = 'More';
            break;
    }

}

//document.querySelector('#extra').style.display = 'block';