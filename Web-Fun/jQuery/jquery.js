$(document).ready(function () {

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
$(".third").addClass("red");
console.log("it worked!");
});

$(".add-color-blue").click(function () {
$(".fourth").addClass("blue");
console.log("it worked part 2!");
});

$(".before-insert").click(function() {
    $("p").before("<p>Dr.Seuss says!</p>");
});

$(".after-insert").click(function () {
     $("p").after("<p>Dr.Seuss approves!</p>"); 
     console.log("it worked again and again!");
     
});

$(".cat").click(function() {
    $(".cat").attr("width", "500");
    console.log("not working?");
});

$(".append").click(function() {
    $(".other-stuff").append("<p>Switching Divs Now</p>")
});

$('.change').click(function () {
    $(".changing-html").html("And Jenny is <span class='bold'>great!</span>");
});

$('.change').click(function () {
      $(".changing-text").text("And Jenny pwns fools!");
});
$('.stored-data').data("monster", [1,2,3,4]);
    $('.span').text($('.stored-data").data))
});








});