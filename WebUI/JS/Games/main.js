var TeamDetailPostBackURL = '/Games/Detail';
var TeamEditPostBackURL = '/Games/Edit'
$(function () {
    $(".detail").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.closest('.row-entity').attr('data-id');
        console.log($buttonClicked.closest('.row-entity'));
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDetailPostBackURL,
            contentType: "application/json;",
            data: { "id": id },
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

    $(".edit").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.closest('.row-entity').attr('data-id');
        console.log($buttonClicked.closest('.row-entity'));
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamEditPostBackURL,
            contentType: "application/json;",
            data: { "id": id },
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

    $(".close").click(function () {
        $('#myModal').modal('hide');
    });
});  