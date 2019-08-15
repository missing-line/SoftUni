function solve() {

    let button = document.getElementById('send');
    let inputLine = document.getElementById('chat_input');
    let boxMsg = document.getElementById('chat_messages');

    button.addEventListener('click', function () {
        if (inputLine.value) {
            let msg = inputLine.value;
            inputLine.value = '';

            let div = document.createElement('div');
            div.className = 'message my-message';
            div.innerHTML = msg;

            boxMsg.appendChild(div);
        }
    })
}