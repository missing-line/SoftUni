function leap(n) {
    let year = "no";
         if (n % 4 === 0) {
        year = "yes";
    }
        if ( n % 100 === 0){
        year = "no";
    }
    if (n % 400 === 0){
        year = "yes";
    }
    console.log(year)
}
leap(2016);