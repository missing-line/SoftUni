function solve(arr) {
    console.log(arr.sort(Sort).join("\n"));

    function Sort(a,b) {
        let aL = a.length;
        let bL = b.length;
        let result = aL - bL;
        if (result === 0) {
            return a.localeCompare(b);
        }
        return result;
    }
}

solve(["alpha", "beta", "gamma"]);