function solve(input) {
    let health = Number(100);
    let coins = 0;
    let count = 0;
    let arr = input[0].split("|");
    while (arr.length != 0) {
        let currArr = arr[0].split(" ");
        let command = currArr[0];
        let value = Number(currArr[1]);
        if (command === "potion") {
            let currH = health;
            health += value;
            if (health > 100) {
                health = 100;
                console.log(`You healed for ${100 - currH} hp.`)
                console.log(`Current health: 100 hp.`)
            }
            else {
                console.log(`You healed for ${value} hp.`)
                console.log(`Current health: ${health} hp.`)
            }
            count++;
        }
        else if (command === "chest") {
            console.log(`You found ${value} coins.`)
            coins += value;
            count++;
        }
        else {
            health -= value;
            count++;
            if (health > 0) {
                console.log(`You slayed ${command}.`)
            }
            else {
                console.log(`You died! Killed by ${command}.`)
                console.log(`Best room: ${count}`)
                return;
            }
        }
        arr.shift();
    }
    console.log(`You've made it!`);
    console.log(`Coins: ${coins}`);
    console.log(`Health: ${health}`)
}

solve([`rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000`]);