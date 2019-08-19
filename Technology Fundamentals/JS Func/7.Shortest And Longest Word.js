function solve(input) {
    let min = 9999999;
    let max = -9999999;
    let minIndex = 0;
    let maxIndex = 0;
    input = input.split(/[\ \?\,\.\!]+/g);

    for (let i = 0; i < input.length; i++) {
        if (input[i].length < min && input[i] !== ""){
            min = input[i].length;
            minIndex = i;
        }
        if (input[i].length > max){
            max = input[i].length;
            maxIndex = i;
        }
    }
    console.log(`Longest -> ${input[maxIndex]}`);
    console.log(`Shortest -> ${input[minIndex]}`);
}

solve('Loren Ipsum is simply dummy text of the printing and typesetting industry.');