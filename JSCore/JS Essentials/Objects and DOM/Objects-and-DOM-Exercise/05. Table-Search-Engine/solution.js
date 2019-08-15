function solve() {
    let tr = Array.from(document.getElementsByTagName('tr'));
    tr.splice(0, 2);

    document.querySelector('#searchBtn').addEventListener('click', function () {
        let search = document.querySelector('#searchField').value;
        if (search) {
            document.querySelector('#searchField').value = '';
            tr.forEach(x => {
                x.className = '';
            });
            tr.forEach(x => {
                Array.from(x.children);
                for (let i = 0; i < x.children.length; i++) {
                    if ( x.children[i].textContent.toLowerCase().includes(search.toLowerCase())) {
                        x.className = 'select';
                    }
                }
            });
        }
    });
}

