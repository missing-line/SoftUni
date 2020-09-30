function subtract() {

    let divElement = document.getElementById("wrapper");

    let div = create('300px', '300px', 'lightblue', "dashed #ccffff", null, null);
    divElement.appendChild(div);

    let div2 = create('200px', '200px', 'orange', null , '45px', '45px');
    div.appendChild(div2);


    let div3 = create('80px', '80px', null, 'solid red' , '53px', '53px',);
    div2.appendChild(div3);

    const arr = Array.from(document.getElementsByClassName('div'));

    arr.forEach(x => {
        x.addEventListener('click', function () {
            alert('Hello from div element!')
        })
    });

    function create(width , height, backgroundColor, border, marginTop, marginLeft) {

        let element = document.createElement('div');
        element.className = 'div';
        element.style.position = "absolute";
        element.style.width = width;
        element.style.height = height;
        element.style.backgroundColor = backgroundColor;
        element.style.border = border; //"dashed #ccffff";
        element.style.marginTop = marginTop;
        element.style.marginLeft = marginLeft;
        return element;
    }
}

