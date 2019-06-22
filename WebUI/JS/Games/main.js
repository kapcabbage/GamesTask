var TeamDetailPostBackURL = '/Games/Detail';
var TeamEditPostBackURL = '/Games/Edit';
var TeamDeletePostBackURL = '/Games/Delete';
var TeamAddPostBackURL = '/Games/Add';
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

    $(".add").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.closest('.row-entity').attr('data-id');
        console.log($buttonClicked.closest('.row-entity'));
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamAddPostBackURL,
            contentType: "application/json;",
            data: {},
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

    $(".delete").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.closest('.row-entity').attr('data-id');
        console.log($buttonClicked.closest('.row-entity'));
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDeletePostBackURL,
            contentType: "application/json;",
            data: { "id": id },
            datatype: "json",
            success: function (response) {
                console.log("succ")
                console.log(response)
                window.location.href = response.redirectURL;
            },
            error: function () {
                console.log("fail")
                console.log(response)
                alert("Deletion failed.");
            }
        });
    });
    $(".close").click(function () {
        $('#myModal').modal('hide');
    });
});  