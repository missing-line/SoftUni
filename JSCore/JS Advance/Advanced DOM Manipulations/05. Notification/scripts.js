function notify(message) {
    let div = document.getElementById('notification');
    div.style.display = 'block';
    div.textContent = message;
    setTimeout(function(){
        document.getElementById('notification').style.display = 'none';
    }, 2000);
}