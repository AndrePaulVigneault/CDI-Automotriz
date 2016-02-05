$(function () {
    var PageUrl = '/'+window.location.href.split('/')[3];
    $("#bs-main-navbar-collapse-1 ul li a").each(function () {
        if ($(this).attr("href") === PageUrl || $(this).attr("href") === '') {
            $(this).parent().addClass("active");
        }
    });
});