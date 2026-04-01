$(document).ready(function () {
    // Add active class to the clicked nav-link and remove from others
    $('.nav-link').on('click', function () {
        $('.nav-link').removeClass('active'); // Remove active class from all links
        $(this).addClass('active'); // Add active class to the clicked link
    });
});
