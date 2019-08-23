document.addEventListener("DOMContentLoaded", function () {

    var button = document.getElementById("WorkPlace");
    //var checkedValue = $('#tBody:checked').val();
  var checkedValue = document.querySelector('#tBody').checked;

    var employee = $("#Employee").val();
    var href = null;
    $("#tBody").on("click", "tr td div #check", function () {

        if ($(this).prop("checked") == true) {
            button.style.display = "block";
            var id = $(this).val();
            href = "/Employee/AddOldWorkPlaces?id=" + id;
        }
        else {
            button.style.display = "none";
        }
    })
    button.addEventListener("click",function (e) {
        e.preventDefault();
        window.location.href = href;
    })

    $("#check").on("click", function () {
        var id = $(this).val();
        $("#WorkPlace").href = "Employee/AddOldWorkPlaces?id=" + id;
    });
});