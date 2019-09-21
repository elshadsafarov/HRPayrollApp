document.addEventListener("DOMContentLoaded", function () {

    var OldWorkPlaceButton = document.getElementById("OldWorkPlace");
    var NewWorkPlaceButton = document.getElementById("WorkPlace");
 
    var employee = $("#Employee").val();
    var href = null;
    $("#tBody").on("click", "tr td div #check", function () {

        if ($(this).prop("checked") === true) {
            var id = $(this).val();
            OldWorkPlaceButton.style.display = "block";
            NewWorkPlaceButton.style.display = "block";
          
        }
        else {
            OldWorkPlaceButton.style.display = "none";
            NewWorkPlaceButton.style.display = "none";
        }

    });

    //search for employees
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
                $("tbody tr").remove();
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
                       </tr>`;
                    $("tbody").append(row);
                }
            }
        });
    });


    //when holdings select change companies
    $("#holdings").change(function () {

        var id = $(this).val();
        $("#companies option").remove();
        $.ajax({
            url: "/WorkPlace/FillCompanies/" + id,
            type: "post",
            dataType: "json",
            success: function (response) {
                if (response.status === 200) {

                    var EmptyOption = `<option selected>Select company</option>`;
                    $("#companies").append(EmptyOption);
                    for (var i = 0; i < response.data.length; i++) {

                        var option = `<option value="${response.data[i].id}">${response.data[i].name}</option>`;
                        $("#companies").append(option);
                    }
                }

            }

        });
    });



    //when company select change branch
    $("#companies").change(function () {

        var id = $(this).val();
        $("#branches option").remove();
        $.ajax({
            url: "/WorkPlace/FillBranches/" + id,
            type: "post",
            dataType: "json",
            success: function (response) {
                if (response.status === 200) {

                    var EmptyOption = `<option selected>Select branch</option>`;
                    $("#branches").append(EmptyOption);
                    for (var i = 0; i < response.data.length; i++) {

                        var option = `<option value="${response.data[i].id}">${response.data[i].name}</option>`;
                        $("#branches").append(option);
                    }
                }

            }

        });
    });



    //when department select change position
    $("#departments").change(function () {

        var id = $(this).val();
        $("#positions option").remove();
        $.ajax({
            url: "/WorkPlace/FillPositions/" + id,
            type: "post",
            dataType: "json",
            success: function (response) {
                if (response.status === 200) {

                    var EmptyOption = `<option selected>Select Position</option>`;
                    $("#positions").append(EmptyOption);
                    for (var i = 0; i < response.data.length; i++) {

                        var option = `<option value="${response.data[i].id}">${response.data[i].name}</option>`;
                        $("#positions").append(option);
                    }
                }

            }

        });
    });
});