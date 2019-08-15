function solve(input) {

    let racers = input[0].split(' ');
    let race = input.slice(1);

    for (let i = 0; i < race.length; i++) {

        let arr = race[i].split(' ');
        let command = arr[0];
        let nameOfRacer = arr[1];
        if (command === 'Join') {

            if (!racers.includes(nameOfRacer)) {
                racers.push(nameOfRacer);
            }
        } else if (command === 'Crash') {
            if (racers.includes(nameOfRacer)) {
                let index = racers.indexOf(nameOfRacer);
                racers.splice(index, 1);
            }
        } else if (command === 'Pit') {

            if (racers.includes(nameOfRacer)) {
                let index = racers.indexOf(nameOfRacer);
                if (index !== racers[racers.length - 1]) {
                    let racerForChange = racers[index + 1];
                    racers[index] = racerForChange;
                    racers[index + 1] = nameOfRacer;
                }
            }

        } else if (command === 'Overtake') {

            if (racers.includes(nameOfRacer)) {
                let index = racers.indexOf(nameOfRacer);
                if (index > 0) {
                    let racerForChange = racers[index - 1];
                    racers[index] = racerForChange;
                    racers[index - 1] = nameOfRacer;
                }
            }
        }
    }

    console.log(racers.join(' ~ '));
}

solve(
    ["Vetel Hamilton Raikonnen Botas Slavi",
        "Pit Hamilton",
        "Overtake LeClerc",
        "Join Ricardo",
        "Crash Botas",
        "Overtake Ricardo",
        "Overtake Ricardo",
        "Overtake Ricardo",
        "Crash Slavi"]
);