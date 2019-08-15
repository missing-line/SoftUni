function solve() {

    let ol = document.querySelector('#exercise ol').children;
    let btn = document.querySelector('#exercise button');

    console.log(ol);
    console.log(btn);

// 97 122
    btn.addEventListener('click', function () {
        let text = document.querySelector('#exercise input').value;
        if (validate(text.toLowerCase()) && text){

            text = text.charAt(0).toUpperCase() + text.slice(1).toLowerCase();
            let code = text.charCodeAt(0);
            let position = (code - 64) - 1;

            if (ol[position].textContent)
                ol[position].textContent += ',' + ' ' + text;
            else{
                ol[position].textContent += text;
            }
            document.querySelector('#exercise input').value = '';
        }

    });

    function validate(name) {
        for (let i = 0; i < name.length; i++) {
           let ch =  name[i].charCodeAt(0);
            if (ch < 97 || ch > 122){
               return false;
           }
        }
        return true;
    }
}

//function solve() {
//    let regex = /^[A-Z]+$/i;
//    let li = Array.from(document.getElementsByTagName('li'));
//    document.querySelector('button').addEventListener('click', function () {
//        if (document.querySelector('input').value) {
//            let text = document.querySelector('input').value;
//            if (regex.test(text)){
//                let code = text.toUpperCase().charCodeAt(0);
//                let position = (code - 64);
//                text = text.charAt(0).toUpperCase() + text.slice(1).toLowerCase();
//
//                if (li[position - 1].textContent)
//                    li[position - 1].textContent += ',' + ' ' + text;
//                else{
//                    li[position - 1].textContent += text;
//                }
//                document.querySelector('input').value = '';
//            }
//        }
//    })
//}