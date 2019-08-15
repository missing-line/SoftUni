function addItem() {
    //get input fields text
    let text = document.getElementById('newItemText').value;
    let value = document.getElementById('newItemValue').value;

    if (text && value) {
        //create option
        let optionElement = document.createElement('option');
        optionElement.value = value;
        optionElement.textContent = text;
        // add option
        document.getElementById('menu').appendChild(optionElement);
        //clear input fields after operation...
        document.getElementById('newItemText').value = '';
        document.getElementById('newItemValue').value = '';
    }
}