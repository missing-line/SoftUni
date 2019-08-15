function solve() {

    Array.from(document.getElementsByTagName('img')).forEach((x) => {
        x.addEventListener('click', clickEvent)
    });

    function clickEvent(e) {
        let card = e.target;
        card.src = "images/whiteCard.jpg";
        card.removeEventListener('click', clickEvent);

        let parent = card.parentNode;
        let nameParent = parent.id;

        let result = document.getElementById('result').children;

        if (nameParent === 'player1Div') {
            result[0].textContent = card.name;
        }
        else if (nameParent === 'player2Div') {
            result[2].textContent = card.name;
        }

        if (result[0].textContent && result[2].textContent) {
            let winner;
            let looser;
            if (+(result[0].textContent) > +(result[2].textContent)) {
                winner = document.querySelector(`#player1Div img[name = "${result[0].textContent}"]`);
                looser = document.querySelector(`#player2Div img[name = "${result[2].textContent}"]`);
            }
            else {
                looser = document.querySelector(`#player1Div img[name = "${result[0].textContent}"]`);
                winner = document.querySelector(`#player2Div img[name = "${result[2].textContent}"]`);
            }
            winner.style.border = '2px solid green';
            looser.style.border = '2px solid red';

            document.getElementById('history').textContent += `[${result[0].textContent} vs ${result[2].textContent}] `;

            result[0].textContent = '';
            result[2].textContent = '';

        }
    }
}