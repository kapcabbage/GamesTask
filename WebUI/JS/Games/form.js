$(function () {
    $.ajaxSetup({ cache: false });

    $('.submit').on("click", function (e) {
        e.preventDefault();
        var linkObj = $(this).closest('form');
        console.log(linkObj);
        console.log(linkObj.attr('method'));
        console.log(linkObj.attr('action'));
        console.log(linkObj.serialize());
        $.ajax({ // create an AJAX call...
            data: linkObj.serialize(), // get the form data
            type: linkObj.attr('method'), // GET or POST
            url: linkObj.attr('action'), // the file to call
            success: function (response) { // on success..
                if (response.success) {
                    window.location.href = response.redirectURL;
                }
                else {
                    $('#myModalContent').html(response); // update the DIV
                }
                
            }
        });
    });
});