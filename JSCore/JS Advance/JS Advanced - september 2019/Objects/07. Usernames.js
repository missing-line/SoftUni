function solve(input) {
    console
        .log([...new Set(input)]
            .sort((a, b) => {
                return a.length - b.length || a.localeCompare(b);
            })
            .join('\n'));
}

solve(['Ashton', 'Kutcher', 'Ariel', 'Lilly', 'Keyden', 'Aizen', 'Billy', 'Braston']);