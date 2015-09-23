//$(document).ready(function () {

//    $('#example tbody').on('click', '#btnDelete', function () {

//        $('#example').DataTable()
//            .row($(this).parents('tr'))
//            .remove()
//            .draw();

//    });
//});

var oTable;
//$("#myButton").on("click", function (e) {
//    e.preventDefault();
$(document).ready(function () {
    var aData = [];
    //aData[0] = $("#ddlSelectYear").val();
    //$("#contentHolder").empty();
    //var jsonData = JSON.stringify({ aData: aData });
    $.ajax({
        method: "post",
        //getListOfCars is my webmethod   
        url: "../WebServices/myfunction.asmx/getListOfStyles",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: OnSuccess,
        error: OnErrorCall
    });

    function OnSuccess(response) {

        console.log(response.d);

        var StylesTable = $('#example tbody');

        $(response.d).each(function (index, st) {

            StylesTable.append('<tr>' +
                                '<td>' + (index + 1) + '</td>' +
                                '<td>' + st.Name + '</td>' +
                                '<td>' + st.Descripton + '</td>' +
                                //'<td><a href="../forms/formStyle.aspx?Id=' + st.Id + '"> <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></a></td>' +
                                '<td><a href=\'javascript:;\' onclick="return Get_Style_By_Id(this,' + st.Id + ',' + index + ')"  data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>' +
                                //'<td><button type="button" id="btnDelete" onclick="return Delete(this,' + st.Id + ')" class="btn btn-danger" aria-label="Left Align"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span>  </button></td></tr>');
                                '<td><a href=\'javascript:;\' id="btnDelete" onclick="return Delete(this,' + st.Id + ',' + index + ')" ><span class="glyphicon glyphicon-trash" aria-hidden="true"></span>  </a></td></tr>');

        });
        oTable= $('#example').DataTable({
            
            responsive: true,
            "columnDefs": [{ "targets": 4, "orderable": false }, { "targets": 3, "orderable": false }]
        });
        $('#example tfoot th').each(function () {
            var title = $('#example thead th').eq($(this).index()).text();
            if (title != "Edit" && title != "Delete" && title != "IsDeleted") {
                $(this).html('<input type="text" placeholder="Search ' + title + '" />');
            }

        });

        // DataTable
        var table = $('#example').DataTable();

        // Apply the search
        table.columns().every(function () {
            var that = this;

            $('input', this.footer()).on('keyup change', function () {
                that
                    .search(this.value)
                    .draw();
            });
        });
    }
    function OnErrorCall(response) { console.log(error); }






});


function Delete(Control, Id, RowIndex) {
    if (confirm('Are you sure you want to delete this Record?')) {
        var Info = { Id: Id };


        $.ajax({
            method: "post",
            //getListOfCars is my webmethod
            url: "../WebServices/myfunction.asmx/DeleteStyleById",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            success: function (result) {

                if (result.d == true) {

                    location.reload(false);

                    //$('#example').DataTable()
                    //    .row($(Control).parents('tr'))
                    //    .remove()
                    //    .draw();

                    //var oTable = $('#example').dataTable();
                    //oTable.fnDeleteRow(RowIndex);

                    // Example call to load a new file
                    //oTable.fnReloadAjax('media/examples_support/json_source2.txt');

                    //Example call to reload from original file
                    //oTable.fnReloadAjax();

                    //oTable.fnFilter();

                    //var table = $('#example').dataTable();


                    //// Example call to reload from original file
                    //table.fnReloadAjax();
                }
            },
            error: function () {
                alert('error');
            }
        });

    }
    else
        return false;
}

function Get_Style_By_Id(Control, Id, RowIndex) {

    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = Id;
    document.getElementById(hfIndex).value = RowIndex;
    var Info = { Id: Id };

    $.ajax({
        method: "post",
        url: "../WebServices/myfunction.asmx/Get_Style_By_Id",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(txtName).value = result.d.Name;
            document.getElementById(txtDescription).value = result.d.Descripton;
        },
        error: function () {
            alert('error');
        }
    });


}

function Update() {

    var Info = {
        Id: document.getElementById(hfId).value,
        Name: document.getElementById(txtName).value,
        Description: document.getElementById(txtDescription).value,
    };


    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/myfunction.asmx/Update",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            if (result.d == "1") {
                document.getElementById(lblMessage).style.color = "Red";
                document.getElementById(lblMessage).innerHTML = "Already Exists";
            }
            else {
                document.getElementById(lblMessage).style.color = "Green";
                document.getElementById(lblMessage).innerHTML = "Updated Sucessfully";


                var oTable = $('#example').dataTable();
                oTable.fnUpdate(Info.Name, document.getElementById(hfIndex).value, 1); // Single cell
                oTable.fnUpdate(Info.Description, document.getElementById(hfIndex).value, 2); // Single cell
                //oTable.fnUpdate(['a', 'b', 'c', 'd', 'e'], 1); // Row
            }
        },
        error: function () {
            alert('error');
        }
    });

}