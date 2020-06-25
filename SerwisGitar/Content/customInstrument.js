let labels = $('label');
let cards = $('.card-header').length;
let classIndex;
let buttons = $('.selectedItem');
let item;

$(labels).on('click',
    function () {
        for (var i = 0; i < labels.length; i++) {

            if ($(this).hasClass(`c${i}`)) {
                classIndex = i;
            };

            if ($(labels[i]).hasClass(`c${classIndex}`)) {
                $(labels[i]).removeClass("boxShadow");
            };
        }
        $(buttons[classIndex]).text($(this).find('div').text());
        $(this).addClass("boxShadow");
    });

$('form').submit(function (e) {
    e.preventDefault(e);
    let flag = false;

    for (let i = 0; i < buttons.length; i++) {
        if ($(buttons[i]).text() === "") {
            $('#info').show();
            flag = true;
        }
    }
    if (!flag) {
        this.submit();
    }
});