function encodeAndDecodeMessages() {

    let encode = document.querySelectorAll('button')[0];
    let decode = document.querySelectorAll('button')[1];

    encode.addEventListener('click', function () {
        let text = document.querySelectorAll('textarea')[0].value;
        let decode = '';
        for (let i = 0; i < text.length; i++) {
            let char = text[i].charCodeAt(0) + 1;
            decode += String.fromCharCode(char);
        }
        document.querySelectorAll('textarea')[0].value = '';
        document.querySelectorAll('textarea')[1].value = decode;
    });

    decode.addEventListener('click', function () {
        let text = document.querySelectorAll('textarea')[1].value;
        let encode = '';
        for (let i = 0; i < text.length; i++) {
            let char = text[i].charCodeAt(0) - 1;
            encode += String.fromCharCode(char);
        }
        document.querySelectorAll('textarea')[1].value = encode;
    })
}