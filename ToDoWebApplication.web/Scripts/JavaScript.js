$(function () {
    $("#choose-form").on('change', function () {
        $("#btnSubmit").trigger('click');
        console.log($("#btnSubmit").val());
    });
});