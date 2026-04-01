$(function () {
    $('#btnLogin').click(function (e) {
        e.preventDefault();

        var model = {
            EmailOrUserName: $('#EmailOrUsername').val(),
            Password: $('#Password').val()
        };

        $.ajax({
            url: '/Auth/User/Login',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (response) {
                if (response.success) {
                    window.location.href = '/Home/Index';
                } else {
                    $('#loginMessage').text(response.message);
                }
            },
            error: function (xhr) {
                var errorMessage = xhr.responseJSON?.message || "An error occurred. Please try again.";
                $('#loginMessage').text(errorMessage);
            }
        });
    });
});
