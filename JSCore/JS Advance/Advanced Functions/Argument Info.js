function solve() {
    let obj = {};

    for (let i = 0; i < arguments.length; i++) {
        let currArgm = arguments[i];
        let type = typeof (currArgm);
        if (!obj.hasOwnProperty(type)) {
            obj[type] = 1;
        } else {
            obj[type]++;
        }
        console.log(`${type}: ${currArgm}`)
    }

    Object.keys(obj).sort((a, b) => {
        return obj[b] - obj[a];
    }).forEach(x => {
        console.log(`${x} = ${obj[x]}`);
    });
}

solve('cat', 42, function () {
    console.log('Hello world!');
}, [], []);
