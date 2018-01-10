$(document).ready(function () {
    console.log("ready!");

var old_html = $(".picture-hidden").html();
    
$('img').click(function() {
    $(this).hide();
});

$("button").click(function() {
$(".picture-hidden").html(old_html);
console.log("it works!");
});

});