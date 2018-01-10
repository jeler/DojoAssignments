$(document).ready(function () {
    console.log("ready!");
//     $('button').click(function () {
//         $(this).text("RESET THE BUTTON");
//         $('.arena').append("<p>ANOTHER CHALLENGER</p>");
//     });
//     $('.arena').on("click", "p", function () { // MUST use .on for content that is CREATED by your jquery
//         console.log("CLICKED A P TAG")
//     });
// });
$(".hide").click(function() {
    $(".paragraph").hide();
});
$(".show").click(function() {
    $(".paragraph").show();
});
$(".toggle").click(function() {
    $(".toggle-p").toggle();
});

$(".sliden-up").click(function() {
    $(".sliden-p").slideUp();
});

$(".sliden-down").click(function () {
    $(".sliden-p").slideDown();
});
 $(".slide-toggle").click(function () {
    $(".slide-toggle-p").slideToggle();
});
$(".fade-in").click(function() {
    $(".fidget-toy").fadeIn("slow");
});
$(".fade-out").click(function () {
     $(".fidget-toy").fadeOut("slow");
     console.log("I clicked fade out");
});
$(".add-color").click(function() {
    $("third").addClass("red");
});


});