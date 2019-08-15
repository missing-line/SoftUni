function solve(n) {

    let coffee = 0;
    let cola = 0;
    let tea = 0;
    let energy = 0;


   for (let i = 1; i <= n; i++) {
       coffee += (3 * 150);
       cola += (2 * 250);
       tea += (3 * 350);

       if (i % 5 === 0) {
           energy += (3 * 500);
       }
       if (i % 9 === 0) {
           cola += (4 * 250);
           energy += (2 * 500);
       }
   }

   coffee = (coffee / 100 ) * 40;
   cola= (cola /100) * 8;
   tea = (tea / 100) * 20;
   energy = (energy / 100) * 30;

   console.log(`${coffee + tea + cola + energy} milligrams of caffeine were consumed`);
}

solve(5);
solve(8);