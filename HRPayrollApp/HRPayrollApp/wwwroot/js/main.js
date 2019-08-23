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
    });
    button.addEventListener("click", function (e) {
        e.preventDefault();
        window.location.href = href;
    });

    $("#check").on("click", function () {
        var id = $(this).val();
        $("#WorkPlace").href = "Employee/AddOldWorkPlaces?id=" + id;
    });


  

    $("#Search").keyup(function () {

        var search = $(this).val();

        var data = new FormData();
        data.append("value", search);
        $.ajax({
            url: "/employee/filter/",
            data: data,
            dataType: "JSON",
            type: "post",
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                $("tbody tr").remove()
                for (var item of response.data) {
                    var row = `<tr>
                             <td>${item.name}</td>
                             <td>${item.surname}</td>
                             <td>${item.fatherName}</td>
                             <td>${item.birthday}</td>
                             <td>${item.currentAddress}</td>
                             <td>${item.registerDistrict}</td>
                             <td>${item.passportNum}</td>
                             <td>${item.passExpireDate}</td>
                             <td>${item.education}</td>
                             <td>${item.familyStatus}</td>
                             <td>${item.gender}</td>
                             <td><img src=/images/${item.photo} style="width:93px; height:87px"></td>
                            <td><a href="@Url.Action("Edit","Employee",new { id=employee.Id})">Edit</a> / <a href="@Url.Action("Delete","Employee", new { id =employee.Id})">Delete</a> / <a href="@Url.Action("Details","Employee", new { id =employee.Id})">Details</a></td>
                    <td class="text-right">
                        <div class="form-check">
                            <input type="checkbox" value="@employee.Id" class="form-check-input" id="check" />
                        </div>
                  
</td>
                       </tr>`
                    $("tbody").append(row);
                }
            }
        });
    });

    //var buttonclicked = false;
    var prev =$("#prev").val();
    //$("#next").click(function () {
    //    if (buttonclicked === false) {
    //        buttonclicked = true;
    //        prev.classList.remove("disabled");
    //    };
    //});
    if ($("#next").click() === true)
    {
        $("li.disabled").removeClass('disabled');
    }
    $("#next").click(function () {

    })
});