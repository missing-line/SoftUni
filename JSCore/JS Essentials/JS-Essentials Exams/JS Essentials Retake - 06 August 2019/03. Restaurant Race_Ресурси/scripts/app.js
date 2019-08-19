function solve() {

    function returnWorkers(workers) {
        let workerOfRestaurant = {};
        for (let worker of workers) {
            worker = worker.trim();
            let curr = worker.split(' ');
            let name = curr[0];
            let salary = +curr[1];
            workerOfRestaurant[name] = salary;
        }
        return workerOfRestaurant;
    };

    function returnSumSalaries(workers) {
        return Object.values(workers).reduce((a, b) => {
            return a + b;
        });
    };

    function returnSortedWorkers (spitedWorkers) {
        let keyOfWorkers = Object.keys(spitedWorkers).sort((a, b) => {
            return spitedWorkers[b] - spitedWorkers[a];
        });
        let sortWorkers = {};
        for (let key of keyOfWorkers) {
            sortWorkers[key] = spitedWorkers[key];
        }

        return sortWorkers;
    };

    let restaurants = {};
    const btn = document.getElementById('btnSend');

    btn.addEventListener('click', function () {
        let input = JSON.parse(document.querySelector('#inputs textarea').value);

        for (let restaurant of input) {
            let arr = restaurant.split(' - ');
            let workers = arr[1];
            restaurant = arr[0];
            let array = workers.split(',');

            let spitedWorkers = returnWorkers(array);

            if (restaurants.hasOwnProperty(restaurant)) {

                for (let key in spitedWorkers) {
                    restaurants[restaurant].spitedWorkers[key] = spitedWorkers[key];
                }
                let newAvg = returnSumSalaries(restaurants[restaurant].spitedWorkers);
                restaurants[restaurant].calculatedAverage = +(newAvg / Object.keys(restaurants[restaurant].spitedWorkers).length).toFixed(2);
            } else {

                let avg = returnSumSalaries(spitedWorkers);
                let calculatedAverage = +(avg / Object.keys(spitedWorkers).length).toFixed(2);
                restaurants[restaurant] = {spitedWorkers, calculatedAverage};
            }
        }

        let keysOfRestaurants = Object.keys(restaurants).sort((a, b) => {
            return restaurants[b].calculatedAverage - restaurants[a].calculatedAverage;
        });

        let best = restaurants[keysOfRestaurants[0]]; // най - добрия ресторант

        best.spitedWorkers = returnSortedWorkers(best.spitedWorkers);


        let workersKeys = Object.entries(best.spitedWorkers);

        let name = keysOfRestaurants[0];
        let averageSalary = best.calculatedAverage;
        let bestSalary = workersKeys[0][1];


        let workers = '';
        for (let key of workersKeys) {
            workers += `Name: ${key[0]} With Salary: ${key[1]} `;
        }

        document.querySelector('#bestRestaurant p').textContent = `Name: ${name} Average Salary: ${averageSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;

        document.querySelector('#workers p').textContent = workers.trim();

    })
}