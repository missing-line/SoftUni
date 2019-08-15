function solve(input) {
    let name = "";
    let output= [];
    for (let i = 0; i <= input.length ; i++) {
        if (i % 2 == 0) {
                name = input[i];
        }
        else{
            let result = `${name}: ${input[i]}`;
            output.push(result);
        }
    }

    console.log(`{ ${output.join(', ')} }`);
};

solve(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);