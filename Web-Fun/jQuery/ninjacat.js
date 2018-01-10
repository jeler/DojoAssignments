$(document).ready(function () {
    console.log("ready!");

// var sourceSwap = function () {
//     var jellybean = $(this);
//     var newSource = jellybean.data('alt-src');
//     jellybean.data('alt-src', jellybean.attr('src'));
//     jellybean.attr('src', newSource);
//     }

// $(function () {
//      $('img.cat').click(sourceSwap, sourceSwap);
// });

$(".cat").click(function () {
    var temp = $(this).attr('src');
    $(".cat").attr('alt-src');
    $(this).attr('src', $(this).attr('alt-src'));
    $(this).attr('alt-src', temp);
    console.log("it worked!");
});

});