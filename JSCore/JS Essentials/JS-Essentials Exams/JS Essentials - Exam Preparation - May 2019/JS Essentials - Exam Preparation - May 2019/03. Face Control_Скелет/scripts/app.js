function getData() {

    let pIn = [];
    let pOut = [];
    let blackList = [];


    let area = JSON.parse(document.querySelector('#input textarea').value);
    let lastObject = area.pop();

    for (let i = 0; i < area.length; i++) {
        let action = area[i].action;
        delete  area[i].action;
        let areaValues = Object.values(area[i]);
        if (action === 'peopleIn') {

            let isEquals = false;

            for (let j = 0; j < blackList.length; j++) {
                let values = Object.values(blackList[j]);
                let firstName = values[0];
                let secondName = values[1];
                if (firstName === areaValues[0] && secondName === areaValues[1]) {
                    isEquals = true;
                    break;
                }
            }
            if (isEquals === false) {
                pIn.push(area[i]);
            }

        } else if (action === 'peopleOut') {
            for (let j = 0; j < pIn.length; j++) {
                let values = Object.values(pIn[j]);
                let firstName = values[0];
                let secondName = values[1];
                if (firstName === areaValues[0] && secondName === areaValues[1]) {
                    pIn.splice(j, 1);
                    pOut.push(area[i]);
                    break;
                }
            }
        } else if (action === 'blacklist') {
            blackList.push(area[i]);
            for (let j = 0; j < pIn.length; j++) {
                let values = Object.values(pIn[j]);
                let firstName = values[0];
                let secondName = values[1];
                if (firstName === areaValues[0] && secondName === areaValues[1]) {
                    pIn.splice(j, 1);
                    pOut.push(area[i]);
                    break;
                }
            }
        }
    }
    let valuesOfCriteria = Object.values(lastObject);
    let criteria = valuesOfCriteria[0];
    let action = valuesOfCriteria[1];
    if (criteria && action) {
        if (action === 'peopleIn') {
            pIn = Object.values(pIn).sort((a, b) => {
                return a[`${criteria}`].localeCompare(b[`${criteria}`]);
            })
        } else if (action === 'peopleOut') {
            pOut = Object.values(pOut).sort((a, b) => {
                return a[`${criteria}`].localeCompare(b[`${criteria}`]);
            })
        } else if (action === 'blacklist') {
            blackList = Object.values(blackList).sort((a, b) => {
                return a[`${criteria}`].localeCompare(b[`${criteria}`]);
            })
        }
    }

    pIn.forEach(x => {
        document.getElementById('peopleIn').children[1].textContent += JSON.stringify(x) + ' ';
    });

    pOut.forEach(x => {
        document.getElementById('peopleOut').children[1].textContent += JSON.stringify(x) + ' ';
    });

    blackList.forEach(x => {
        document.getElementById('blacklist').children[1].textContent += JSON.stringify(x) + ' ';
    });
}
