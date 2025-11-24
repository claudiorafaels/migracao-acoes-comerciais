/* MENU LATERAL */
$(document).ready(function () {
    var isMenuOpen = false;

    $('.menu_btn').click(function () {
        if (isMenuOpen == false) {
            $("#menu_smartphone").clearQueue().animate({
                left: '0px'
            })
            $("#menu_btn-close").fadeIn('fast');
            $(".close").fadeIn(300);

            isMenuOpen = true;
        }
    });

    $('#menu_btn-close').click(function () {
        if (isMenuOpen == true) {
            $("#menu_smartphone").clearQueue().animate({
                left: '-75%'
            })
            $("#page").clearQueue().animate({
                "margin-left": '0px'
            })
            $("#grey_back").fadeOut(200);
            $(this).fadeOut(200);
            $(".menu_btn").fadeIn('fast');

            isMenuOpen = false;
        }
    });

    /* SWIPE MENU */
    $('.menu_mobile_app').slideAndSwipe();
});

