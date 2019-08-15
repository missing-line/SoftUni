function solve() {
    //save kingdoms...
    let createdKingdoms = [];
    let availableKingdoms = ['CASTLE', 'DUNGEON', 'FORTRESS', 'INFERNO', 'NECROPOLIS', 'RAMPART', 'STRONGHOLD',
        'TOWER', 'CONFLUX'];
    // create castle..
    let btn = document.querySelectorAll('#kingdom div button')[0];
    btn.addEventListener('click', function () {

        let kingdom = document.querySelectorAll('#kingdom div input')[0].value.toUpperCase();
        let king = document.querySelectorAll('#kingdom div input')[1].value.toUpperCase();
        if (availableKingdoms.includes(kingdom) && king.length >= 2) {
            let castle = document.querySelectorAll(`#map #${kingdom.toLowerCase()}`)[0];

            let h1 = document.createElement('h1');
            h1.textContent = `${kingdom}`;
            castle.appendChild(h1);

            let div = document.createElement('div');
            div.className = 'castle';
            castle.appendChild(div);

            let h2 = document.createElement('h2');
            h2.textContent = `${king}`;
            castle.appendChild(h2);

            let fieldset = document.createElement('fieldset');

            let legend = document.createElement('legend');
            legend.textContent = 'Army';
            let pTank = document.createElement('p');
            pTank.textContent = 'TANKS - 0';
            let pFighters = document.createElement('p');
            pFighters.textContent = 'FIGHTERS - 0';
            let pMages = document.createElement('p');
            pMages.textContent = 'MAGES - 0';
            let armyOutput = document.createElement('div');
            armyOutput.className = 'armyOutput';

            fieldset.appendChild(legend);
            fieldset.appendChild(pTank);
            fieldset.appendChild(pFighters);
            fieldset.appendChild(pMages);
            fieldset.appendChild(armyOutput);

            castle.appendChild(fieldset);

            castle.style.display = 'inline-block';

            createdKingdoms.push(kingdom);
        } else {
            document.querySelectorAll('#kingdom div input')[0].value = '';
            document.querySelectorAll('#kingdom div input')[1].value = '';
        }
    });

    // Join warriors .....
    let joinButton = document.querySelectorAll('#characters div button')[0];
    joinButton.addEventListener('click', function () {
        let inputWithKingdom = document.querySelectorAll('#characters div')[3].children[1].value;
        let nameOfWarrior = document.querySelectorAll('#characters div')[3].children[0].value;
        let castle = createdKingdoms.find(x => x === inputWithKingdom.toUpperCase());

        if (nameOfWarrior.length < 2 || castle === undefined) {
            document.querySelectorAll('#characters div')[3].children[1].value = '';
            document.querySelectorAll('#characters div')[3].children[0].value = '';
        } else {
            let find = document.querySelectorAll(`#map #${castle.toLowerCase()}`)[0];
            let radio = Array.from(document.querySelectorAll('#characters div input')).filter(x => x.name === 'characterType');
            let findRadio = radio.find(x => x.checked);
            let radioValue = findRadio.value;

            if (radioValue === 'mage') {
                let text = find.children[3].children[3].textContent.split(' ');
                let lastElement = +text.pop() + 1;
                find.children[3].children[3].textContent = `MAGES - ${lastElement}`;
            } else if (radioValue === 'fighter') {
                let text = find.children[3].children[2].textContent.split(' ');
                let lastElement = +text.pop() + 1;
                find.children[3].children[2].textContent = `FIGHTERS - ${lastElement}`;
            } else if (radioValue === 'tank') {
                let text = find.children[3].children[1].textContent.split(' ');
                let lastElement = +text.pop() + 1;
                find.children[3].children[1].textContent = `TANKS - ${lastElement}`;
            }
            let divElement = find.children[3].children[4];
            divElement.innerHTML += `${nameOfWarrior} `;
        }
    });

    // war...
    let attackBtn = document.querySelectorAll('#actions button')[0];
    attackBtn.addEventListener('click', function () {
        let attacker = document.querySelectorAll('#actions input')[0].value.toUpperCase();
        let defender = document.querySelectorAll('#actions input')[1].value.toUpperCase();

        let findAttacker = createdKingdoms.find(x => x === attacker);
        let findDefender = createdKingdoms.find(x => x === defender);
        if (findAttacker && findDefender) {

            let attackerCastle = Array.from(document.querySelectorAll(`#map #${findAttacker.toLowerCase()}`)[0].children)[3];
            let defenderCastle = Array.from(document.querySelectorAll(`#map #${findDefender.toLowerCase()}`)[0].children)[3];

            let getAttackerTank = +Array.from(attackerCastle.children)[1].textContent.split(' ').pop() * 20;
            let getAttackerFighter = +Array.from(attackerCastle.children)[2].textContent.split(' ').pop() * 50;
            let getAttackerMage = +Array.from(attackerCastle.children)[3].textContent.split(' ').pop() * 70;

            let getDefenderTank = +Array.from(defenderCastle.children)[1].textContent.split(' ').pop() * 80;
            let getDefenderFighter = +Array.from(defenderCastle.children)[2].textContent.split(' ').pop() * 50;
            let getDefenderMage = +Array.from(defenderCastle.children)[3].textContent.split(' ').pop() * 30;

            let pointsAttacker = getAttackerTank + getAttackerFighter + getAttackerMage;
            let pointsDefender = getDefenderTank + getDefenderFighter + getDefenderMage;

            if (pointsAttacker > pointsDefender) {
                Array.from(document.querySelectorAll(`#map #${findDefender.toLowerCase()}`)[0].children)[2].textContent = Array.from(document.querySelectorAll(`#map #${findAttacker.toLowerCase()}`)[0].children)[2].textContent;
            }
        } else {
            document.querySelectorAll('#actions input')[0].value = '';
            document.querySelectorAll('#actions input')[1].value = '';
        }
    })
}

solve();
