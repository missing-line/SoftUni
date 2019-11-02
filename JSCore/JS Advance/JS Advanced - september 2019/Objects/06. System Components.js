function solve(input) {

    let components = {};

    input.forEach(x => {
        let repos = x.split(' | ');

        let systemName = repos[0];
        let componentName = repos[1];
        let subcomponentsName = repos[2];

        if (!components.hasOwnProperty(systemName))
            components[systemName] = {};

        if (!components[systemName].hasOwnProperty(componentName))
            components[systemName][componentName] = [];

        components[systemName][componentName].push(subcomponentsName);
    });

    let keys = Object.keys(components)
        .sort((a, b) => {
            return Object.keys(components[b]).length - Object.keys(components[a]).length ||
                a.localeCompare(b)
        });


    for (let systemName of keys) {
        console.log(systemName);
        //
        let values = Object.keys(components[systemName])
            .sort((a, b) => components[systemName][b].length - components[systemName][a].length);

        for (let componentName of values) {
            console.log(`|||${componentName}`);
            for (let subcomponentsName of components[systemName][componentName]) {
                console.log(`||||||${subcomponentsName}`);
            }
        }
    }
}

solve(
    ['SULS | Main Site | Home Page',
        'SULS | Main Site | Login Page',
        'SULS | Main Site | Register Page',
        'SULS | Judge Site | Login Page',
        'SULS | Judge Site | Submittion Page',
        'Lambda | CoreA | A23',
        'SULS | Digital Site | Login Page',
        'Lambda | CoreB | B24',
        'Lambda | CoreA | A24',
        'Lambda | CoreA | A25',
        'Lambda | CoreC | C4',
        /*  'Lambda | CoreC | C41',
          'Lambda | CoreC | C42',
          'Lambda | CoreC | C43',
          'Lambda | CoreC | C44',*/
        'Indice | Session | Default Storage',
        'Indice | Session | Default Security']
);