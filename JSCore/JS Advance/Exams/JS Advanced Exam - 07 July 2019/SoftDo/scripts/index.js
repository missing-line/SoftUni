function mySolution() {

    let btn = document.getElementsByTagName('button')[0];

    btn.addEventListener('click', function () {
        let textArea = document.getElementsByTagName('textarea')[0].value;
        let username = document.getElementsByTagName('input')[0].value;

        let user = 'Anonymous';
        if (username) {
            user = username;
        }

        let div = document.createElement('div');
        div.classList.add('pendingQuestion');

        let img = document.createElement('img');
        img.src = './images/user.png';
        img.setAttribute("width", "32");
        img.setAttribute("height", "32");
        div.appendChild(img);

        let span = document.createElement('span');
        span.textContent = user;
        div.appendChild(span);

        let p = document.createElement('p');
        p.textContent = textArea;
        div.appendChild(p);

        let divActions = document.createElement('div');
        divActions.className = 'actions';

        let archive = document.createElement('button');
        archive.className = 'archive';
        archive.textContent = 'Archive';

        let open = document.createElement('button');
        open.className = 'open';
        open.textContent = 'Open';

        divActions.appendChild(archive);
        divActions.appendChild(open);

        div.appendChild(divActions);

        document.querySelector('#pendingQuestions').appendChild(div);


        open.addEventListener('click', function (e) {
            let target = e.target;
            target.parentElement.parentElement.remove();
            let currentP = target.parentElement.parentElement.getElementsByTagName('p')[0].textContent;
            let currentSpan = target.parentElement.parentElement.getElementsByTagName('span')[0].textContent;

            let divQue = document.createElement('div');
            divQue.classList.add('openQuestion');

            let img = document.createElement('img');
            img.src = './images/user.png';
            img.setAttribute("width", "32");
            img.setAttribute("height", "32");
            divQue.appendChild(img);

            let span = document.createElement('span');
            span.textContent = currentSpan;
            divQue.appendChild(span);

            let p = document.createElement('p');
            p.textContent = currentP;
            divQue.appendChild(p);
///
            let innerDiv = document.createElement('div');
            innerDiv.className = 'actions';

            let reply = document.createElement('button');
            reply.className = 'reply';
            reply.textContent = 'Reply';
            innerDiv.appendChild(reply);

            divQue.appendChild(innerDiv);
///
            let divSection = document.createElement('div');
            divSection.classList.add('replySection');
            divSection.style.display = 'none';

            let input = document.createElement('input');
            input.className = 'replyInput';
            input.type = 'text';
            input.placeholder = 'Reply to this question here...';
            divSection.appendChild(input);

            let button = document.createElement('button');
            button.className = 'replyButton';
            button.textContent = 'Send';
            divSection.appendChild(button);

            let ol = document.createElement('ol');
            ol.className = 'reply';
            ol.type = '1';
            divSection.appendChild(ol);

            divQue.appendChild(divSection);
            document.querySelector('#openQuestions').appendChild(divQue);

            reply.addEventListener('click', function (e) {
                let target = e.target;
                if (target.textContent === 'Reply') {
                    target.textContent = 'Back';
                    divSection.style.display = 'block';

                    button.addEventListener('click', function () {
                        if (input.value) {
                            let li = document.createElement('li');
                            li.textContent = input.value;
                            ol.appendChild(li);
                        }
                    })

                } else {
                    target.textContent = 'Reply';
                    divSection.style.display = 'none';
                }
            });
        });
        archive.addEventListener('click', function (e) {
            let target = e.target;
            target.parentElement.parentElement.remove();
        });
    })
}
