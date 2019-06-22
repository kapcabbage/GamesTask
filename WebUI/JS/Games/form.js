$(function () {
    $.ajaxSetup({ cache: false });

    $('.submit').on("click", function (e) {
        e.preventDefault();
        var linkObj = $(this).closest('form');
        $.ajax({ // create an AJAX call...
            data: linkObj.serialize(), // get the form data
            type: linkObj.attr('method'), // GET or POST
            url: linkObj.attr('action'), // the file to call
            success: function (response) { // on success..
                $('#myModalContent').html(response); // update the DIV
            }
        });
    });
});