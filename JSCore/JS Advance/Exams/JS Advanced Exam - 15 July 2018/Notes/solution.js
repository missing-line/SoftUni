function addSticker() {
    let title = $('.title');
    let content = $('.content');
    if (title.val() !== '' && content.val() !== '') {
        $('#sticker-list').append($("<li class='note-content'>")
            .append($("<a class='button'>x</a>"))
            .append($("<h2></h2>").text(title.val()))
            .append($("<hr>"))
            .append($("<p></p>").text(content.val())));
        $('.title').val("");
        $('.content').val("");
        $('.button').on('click', function () {
            $(this).parent().remove();
        })
    }
}