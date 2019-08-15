function solve(input) {

    let atm = 0;
    let banknotes = [];

    for (let i = 0; i < input.length; i++) {
        if (input[i].length > 2) {

            for (let cash of input[i]) {
                banknotes.push(cash);
            }
            let sum = input[i].reduce((a, b) => a + b);
            atm += sum;
            console.log(`Service Report: ${sum}$ inserted. Current balance: ${atm}$.`);

        } else if (input[i].length === 1) {
            let dollar = input[i][0];
            let count = 0;
            for (let b of banknotes) {
                if (b === dollar)
                    count++;
            }
            console.log(`Service Report: Banknotes from ${dollar}$: ${count}.`);
        } else if (input[i].length === 2) {

            let acc = input[i][0];
            let cashOut = input[i][1];

            if (acc < cashOut) {

                console.log(`Not enough money in your account. Account balance: ${acc}$.`);

            } else if (atm < cashOut) {

                console.log(`ATM machine is out of order!`);

            } else {
                let result = cashingOut(cashOut, acc);
                console.log(result);
            }
        }
    }

    function cashingOut(cash, acc) {
        let withdraw = cash;
        banknotes = banknotes.sort((a, b) => b - a);
        for (let i = 0; i < banknotes.length; i++) {
            const banknote = banknotes[i];

            if (banknote <= cash) {
                cash -= banknote;
                atm -= banknote;
                banknotes.splice(i, 1);
                i--;

                if (cash === 0) {
                    acc -= withdraw;
                    return `You get ${withdraw}$. Account balance: ${acc}$. Thank you!`;
                }
            }
        }
    }
}

solve([[20, 5, 100, 20, 1],
        [457, 25],
        [1],
        [10, 10, 5, 20, 50, 20, 10, 5, 2, 100, 20],
        [20, 85],
        [5000, 4500],
    ]
);