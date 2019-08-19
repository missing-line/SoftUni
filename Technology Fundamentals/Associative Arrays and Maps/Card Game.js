function solve(input) {
    let map = new Map();
    let points =  new Map();
    points.set("A",14);
    points.set("K",13);
    points.set("Q",12);
    points.set("J",11);
    points.set("S",4);
    points.set("H",3);
    points.set("D",2);
    points.set("C",1);
    points.set("2",2);
    points.set("3",3);
    points.set("4",4);
    points.set("5",5);
    points.set("6",6);
    points.set("7",7);
    points.set("8",8);
    points.set("9",9);
    points.set("10",10);

    for (let i = 0; i < input.length; i++) {
        let currPlayer = input[i].split(/[: ,]+/);
        let name = currPlayer[0];
        currPlayer.shift();
        let cards = currPlayer;
        if (!map.has(name)) {
            map.set(name, new Set());
        }
        let values = map.get(name);
        for (let j = 0; j < cards.length; j++) {
            values.add(cards[j]);
        }
        map.set(name, values);
    }
    for (let [key,value] of map){
        let currSum = 0;
        for (let card of value){
            let takeP = 0;
            let takeT = 0;
            if(card.length === 3){
                 takeP = card[0] + card[1];
                    takeT = card[2];
            }
            else{
                 takeP = card[0];
                  takeT = card[1];
            }
            
            let currP = points.get(takeP);
            currP *= points.get(takeT);
            currSum += currP;
        }
        console.log(`${key}: ${currSum}`)
    }

}

solve(['Pesho: 2C, 4H, 9H, AS, QS',
    'Slav: 3H, 10S, JC, KD, 5S, 10S',
    'Peshoslav: QH, QC, QS, QD',
    'Slav: 6H, 7S, KC, KD, 5S, 10C',
    'Peshoslav: QH, QC, JS, JD, JC',
    'Pesho: JD, JD, JD, JD, JD, JD']
);