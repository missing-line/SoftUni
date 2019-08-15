function solve(examPoint, finishedHomework, totalOFHomeWork) {
    if (examPoint === 400) {
        console.log('6.00');
        return;
    }

    let totalPoint = (examPoint / 400 * 100) * 0.9;
    let percentFromHomework = finishedHomework / totalOFHomeWork;
    percentFromHomework *= 10;
    totalPoint += percentFromHomework;
    let grade = 3 + 2 * (totalPoint - 100 / 5) / (100 / 2);
    if (grade < 3.00) {
        grade = 2;
    } else if (grade > 6.00) {
        grade = 6;
    }
    console.log(grade.toFixed(2));
}

solve(200, 5, 5)