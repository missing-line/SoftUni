function triangle(n) {
    for (let i = 1; i <= n ; i++) {
        let out = '';
        for (let j = 1; j <= i ; j++) {
            if (j == i){
                out += `${i}`
            }
            else{
                out += `${i} `;
            }

        }
        console.log(out);
    }
}
