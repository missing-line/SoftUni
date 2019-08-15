function spaceshipCrafting() {

    let bars = document.getElementById('availableBars').children[1];
    let ships = document.getElementById('builtSpaceships').children[1];

    let titan = Number(document.getElementById('titaniumCoreFound').value);
    //titan = Math.round(titan);
    let aluminum = Number(document.getElementById('aluminiumCoreFound').value);
    //aluminum = Math.round(aluminum);
    let magnesium = Number(document.getElementById('magnesiumCoreFound').value);
    //magnesium = Math.round(magnesium);
    let carbon = Number(document.getElementById('carbonCoreFound').value);
    //carbon = Math.round(carbon);
    let percent = Number(document.getElementById('lossesPercent').value) / 4;

    let titanAfter = titan * (1 - (percent / 100));
    let aluminiumAfter = aluminum * (1 - (percent / 100));
    let magnesiumAfter = magnesium * (1 - (percent / 100));
    let carbonAfter = carbon * (1 - (percent / 100));

    titanAfter = Math.round(titanAfter / 25);
    aluminiumAfter = Math.round(aluminiumAfter / 50);
    magnesiumAfter = Math.round(magnesiumAfter / 75);
    carbonAfter = Math.round(carbonAfter / 100);

    let undefined = 0;
    let master = 0;
    let json = 0;
    let fleet = 0;

    while (titanAfter >= 2 && aluminiumAfter >= 2 && magnesiumAfter >= 3 && carbonAfter >= 1) {

        if (titanAfter >= 7 && aluminiumAfter >= 9 && magnesiumAfter >= 7 && carbonAfter >= 7) {
            undefined++;
            titanAfter -= 7;
            aluminiumAfter -= 9;
            magnesiumAfter -= 7;
            carbonAfter -= 7;
        }
        if (titanAfter >= 5 && aluminiumAfter >= 7 && magnesiumAfter >= 7 && carbonAfter >= 5) {
            master++;
            titanAfter -= 5;
            aluminiumAfter -= 7;
            magnesiumAfter -= 7;
            carbonAfter -= 5;
        }
        if (titanAfter >= 3 && aluminiumAfter >= 5 && magnesiumAfter >= 5 && carbonAfter >= 2) {
            json++;
            titanAfter -= 3;
            aluminiumAfter -= 5;
            magnesiumAfter -= 5;
            carbonAfter -= 2;
        }
        if (titanAfter >= 2 && aluminiumAfter >= 2 && magnesiumAfter >= 3 && carbonAfter >= 1) {
            fleet++;
            titanAfter -= 2;
            aluminiumAfter -= 2;
            magnesiumAfter -= 3;
            carbonAfter -= 1;
        }
    }

    let result = [];
    result.push(undefined > 0 ? `${undefined} THE-UNDEFINED-SHIP` : '');
    result.push(master > 0 ? `${master} NULL-MASTER` : '');
    result.push(json > 0 ? `${json} JSON-CREW` : '');
    result.push(fleet > 0 ? `${fleet} FALSE-FLEET` : '');

    bars.textContent = `${titanAfter} titanium bars, ${aluminiumAfter} aluminum bars, ${magnesiumAfter} magnesium bars, ${carbonAfter} carbon bars`;
    //ships.textContent = `${undefined} THE-UNDEFINED-SHIP, ${master} NULL-MASTER, ${json} JSON-CREW, ${fleet} FALSE-FLEET`;
    ships.textContent = result.filter(r => r !== '').join(', ');
}




