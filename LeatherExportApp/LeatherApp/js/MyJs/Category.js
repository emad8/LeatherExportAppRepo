﻿//var oTable;

$(document).ready(function () {
    //$.ajax({
        //url: '../WebServices/ServiceCategory.asmx/getListOfStyles',
        //method: 'post',
        //dataType: 'json',
        //success: function (data) {
            oTable= $('#example').dataTable({
                //data: data,
                columns: [
                    { 'data': 'Name'},
                    {
                        'data': 'ForEdit',
                        "bSearchable": false,
                        "bSortable": false,
                        'render': function (oObj) {
                            //return '<a href="#" onclick="ShowEditPopup(' + oObj.aData.DocumentCategoryCode + ')"><div align="center">Edit</div></a>';
                            return '<td><a href=\'javascript:;\' onclick="return Get_Category_By_Id(' + oObj + ')" data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>';
                        }
                    },
                    {
                        'data': 'ForDelete',
                        "bSearchable": false,
                        "bSortable": false,
                        'render': function (oObj) {
                            //return '<a href="#" onclick="DeleteDocCategory(' + oObj.aData.ForDelete + ')"><div align="center">Delete</div></a>';
                            return '<td><a href=\'javascript:;\' id="btnDelete" onclick="return Delete(' + oObj + ')" ><span class="glyphicon glyphicon-trash" aria-hidden="true"></span>  </a></td>';
                        }
                    }
                ],
                bServerSide: true,
                sAjaxSource: '../WebServices/ServiceCategory.asmx/Filter_Get_Category',
                sServerMethod: 'post',
                //"sDom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>',
                //"bProcessing": true,
                
                //"bFilter": true,
                //"sServerMethod": "POST",
                //"sAjaxDataProp": "aaData",
                
                //"bLengthChange": true
                //,"sPaginationType": "full_numbers"
            });
    //    }
    //});

});


function Delete(Id) {
    console.log(Id);
    if (confirm('Are you sure you want to delete this Record?')) {
        var Info = { Id: Id };


        $.ajax({
            method: "post",
            //getListOfCars is my webmethod
            url: "../WebServices/ServiceCategory.asmx/DeleteCategoryById",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                console.log(result.d);
                if (result.d == true) {
                    
                    //location.reload(false);
                    oTable.fnFilter();
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

function Get_Category_By_Id(Id) {
    console.log(Id);
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = Id;
    //document.getElementById(hfIndex).value = RowIndex;
    var Info = { Id: Id };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCategory.asmx/Get_Category_By_Id",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(txtName).value = result.d.Name;
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
    };


    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/ServiceCategory.asmx/Update",
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

                oTable.fnFilter();
                //var oTable = $('#example').dataTable();
                //oTable.fnUpdate(Info.Name, document.getElementById(hfIndex).value, 1); // Single cell
                //oTable.fnUpdate(Info.Description, document.getElementById(hfIndex).value, 2); // Single cell

                //oTable.fnUpdate(['a', 'b', 'c', 'd', 'e'], 1); // Row
            }
        },
        error: function () {
            alert('error');
        }
    });

}