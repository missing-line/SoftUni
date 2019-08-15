function solve(input) {
    function getName(text) {
        let name = text.replace(/[!#$@?]/g, '');
        if (/^[a-z]+$/.test(name))
            return name;

        return null;
    }

    //let regex = /^[!@#$?](.*)[!@#$?]=(\d+)--(\d+)<<([a-z]+)/g;
    let regex = new RegExp('(.*)=(\\d+)--(\\d+)<<([a-z]+)', 'g');
    let obj = {};


    for (let i = 0; i < input.length; i++) {
        let text = input[i];
        if (text === 'Stop!') {
            break;
        }

        let match = regex.exec(text);

        while (match) {

            let name = getName(match[1]);
            if (name === null) {
                match = regex.exec(text);
                break;
            }
            let number = Number(match[2]);
            let genes = Number(match[3]);
            let holder = match[4];
            if (name.length === number) {
                if (!obj.hasOwnProperty(holder)) {
                    obj[holder] = genes;
                } else {
                    obj[holder] += genes;
                }
            }
            match = regex.exec(text);
        }
    }

    let sort = Object.keys(obj).sort(function (a, b) {
        return obj[b] - obj[a]
    });
    for (let key of sort) {
        console.log(`${key} has genome size of ${obj[key]}`);
    }
}


solve([
    '!@ру?би#=4--57<<polecat',
    '?do?@#ri#=4--89<<polecat',
    '=12<<cat',
    '!vi@rus?=2--142',
    '@pa!rcu>ba@cteria$=13--234<<mouse',
    '?!cur##viba@cter!!=11--680<<cat',
    'Stop!'
]);