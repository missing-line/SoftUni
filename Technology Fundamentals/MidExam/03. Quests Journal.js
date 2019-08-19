function solve(input) {
    let arr = input[0].split(",");
    let journal = [];
    for (let i = 0; i < arr.length; i++) {
        journal.push(arr[i].trim());
    }

    for (let i = 1; i <= input.length - 1; i++) {
        let curr = input[i].split("-");
        let command = curr[0].trim();
        if (command === "Start") {
            let currJournal = curr[1].trim();
            if (!journal.includes(currJournal)) {
                journal.push(currJournal);
            }
        }
        else if (command === "Complete") {
            let currJournal = curr[1].trim();
            if (journal.includes(currJournal)) {
                let index = journal.indexOf(currJournal);
                journal.splice(index, 1);
            }
        }
        else if (command === "Side Quest") {
            let innerArr = curr[1].split(":");
            let quest = innerArr[0].trim();
            let sideQuest = innerArr[1].trim();
            if (journal.includes(quest) && !journal.includes(sideQuest)){
                let index = journal.indexOf(quest);
                journal.splice(index + 1,0,sideQuest);
            }
        }
        else if (command === "Renew"){
            let quest = curr[1].trim();
            if (journal.includes(quest)){
                let currQuest = quest;
                let index = journal.indexOf(quest);
                journal.splice(index,1);
                journal.push(currQuest);
            }
        }
    }
    console.log(journal.join(", "));
}

solve(
    [`Hello World, If else`,
        `Complete - Homework`,
        `Side Quest - If else:Switch`,
        `Renew - Hello World`,
        `Retire!`
    ]
);