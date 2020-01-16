$(document).ready(function () {
    resize();
})

$(window).bind("load", function () {
    setTimeout(function () { resize();}, 500)
})

$(window).resize(function () {
    resize();
})

function resize() {
    var w = $(".slide-show").innerWidth();
    var h = $(".slide-show").innerHeight();
    var iw = $(".title-welcome").innerWidth();
    var ih = $(".title-welcome").innerHeight() / 2;

    $(".title-welcome").css("left", ((w - iw) / 2));
    $(".title-welcome").css("top", ((h - ih) / 2));
}