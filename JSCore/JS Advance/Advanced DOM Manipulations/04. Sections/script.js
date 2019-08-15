function create(words) {

    let content = document.getElementById('content');

    for (let i = 0; i < words.length; i++) {
        let div = document.createElement('div');
        let p = document.createElement('p');
        p.textContent = words[i];
        p.style.display = 'none';
        div.appendChild(p);
        content.appendChild(div);
    }

    let children = Array.from(content.children);

    children.forEach(x=>{
       x.addEventListener('click', function (e) {
           let target = e.target;
           target.getElementsByTagName('p')[0].style.display = 'block';
       })
    })
}