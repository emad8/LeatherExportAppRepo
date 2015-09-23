//var oTable;

$(document).ready(function () {
    //$.ajax({
    //url: '../WebServices/ServiceContact.asmx/getListOfStyles',
    //method: 'post',
    //dataType: 'json',
    //success: function (data) {
    oTable = $('#example').DataTable({

        //data: data,
        columns: [
            { 'data': 'Customer_Code' },

            { 'data': 'Customer_Name' },

            { 'data': 'Name' },

            { 'data': 'Tel_No' },

            { 'data': 'Extention_No' },

            { 'data': 'Mob_No' },

            { 'data': 'Designation' },

            { 'data': 'Email' },

            { 'data': 'Remarks' },

            {
                'data': 'ForEdit',
                "bSearchable": false,
                "bSortable": false,
                'render': function (oObj) {
                    //return '<a href="#" onclick="ShowEditPopup(' + oObj.aData.DocumentCustomerCode + ')"><div align="center">Edit</div></a>';
                    return '<td><a href=\'javascript:;\' onclick="return Get_Contact_By_Id(' + oObj + ')" data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>';
                }
            },
            {
                'data': 'ForDelete',
                "bSearchable": false,
                "bSortable": false,
                'render': function (oObj) {
                    //return '<a href="#" onclick="DeleteDocCustomer(' + oObj.aData.ForDelete + ')"><div align="center">Delete</div></a>';
                    return '<td><a href=\'javascript:;\' id="btnDelete" onclick="return Delete(' + oObj + ')" ><span class="glyphicon glyphicon-trash" aria-hidden="true"></span>  </a></td>';
                }
            }
        ],
        bServerSide: true,
        sAjaxSource: '../WebServices/ServiceContact.asmx/Filter_Get_Contact',
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

    $('#btnAdd').on('click', function () {
        if (document.getElementById(hfNavBack).value == "") {

            document.getElementById(lblMessage).innerHTML = "";
            document.getElementById(hfId).value = "";
            document.getElementById(ddlCus).value = "";
            document.getElementById(txtName).value = "";
            document.getElementById(txtTN).value = "";
            document.getElementById(txtMN).value = "";
            document.getElementById(txtDes).value = "";
            document.getElementById(txtEN).value = "";
            document.getElementById(txtEmail).value = "";
            document.getElementById(txtRemarks).value = "";

        }
    });
    debugger;
    if (document.getElementById(hfNavBack).value != "") {

        $('#btnAdd').trigger('click');
    }
});


function Delete(ID) {
    console.log(ID);
    if (confirm('Are you sure you want to delete this Record?')) {
        var Info = { ID: ID };


        $.ajax({
            method: "post",
            //getListOfCars is my webmethod
            url: "../WebServices/ServiceContact.asmx/Delete_Contact_By_Id",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                console.log(result.d);
                if (result.d == true) {

                    //location.reload(false);
                    //oTable.fnFilter();
                    oTable.draw();
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

function Get_Contact_By_Id(ID) {
    console.log(ID);
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = ID;
    //document.getElementById(hfIndex).value = RowIndex;
    var Info = { ID: ID };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceContact.asmx/Get_Contact_By_Id",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(ddlCus).value = result.d.Customer_ID;
            document.getElementById(txtName).value = result.d.Name;
            document.getElementById(txtTN).value = result.d.Tel_No;
            document.getElementById(txtMN).value = result.d.Mob_No;
            document.getElementById(txtDes).value = result.d.Designation;
            document.getElementById(txtEN).value = result.d.Extention_No;
            document.getElementById(txtEmail).value = result.d.Email;
            document.getElementById(txtRemarks).value = result.d.Remarks;
        },
        error: function () {
            alert('error');
        }
    });




}



function Submit() {
    
    if (document.getElementById(hfId).value == "") {


        Insert();
    }
    else {

        Update();


    }


}

function Insert() {

    var Info = {
       Customer_ID: document.getElementById(ddlCus).value,
       Name: document.getElementById(txtName).value,
       Tel_No: document.getElementById(txtTN).value,
       Mob_No: document.getElementById(txtMN).value,
       Designation: document.getElementById(txtDes).value,
       Extention_No: document.getElementById(txtEN).value,
       Email: document.getElementById(txtEmail).value,
       Remarks: document.getElementById(txtRemarks).value,
    };


    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/ServiceContact.asmx/Insert",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            if (result.d == "1") {
                document.getElementById(lblMessage).style.color = "Red";
                document.getElementById(lblMessage).innerHTML = "Already Exists";
            }
            else {
                document.getElementById(lblMessage).style.color = "Green";
                document.getElementById(lblMessage).innerHTML = "Inserted Sucessfully";

                Clear();
                //oTable.fnFilter();
                oTable.draw();
            }
        },
        error: function () {
            alert('error');
        }
    });


}

function Update() {

    var Info = {
        ID: document.getElementById(hfId).value,
        Customer_ID: document.getElementById(ddlCus).value,
        Name: document.getElementById(txtName).value,
        Tel_No: document.getElementById(txtTN).value,
        Mob_No: document.getElementById(txtMN).value,
        Designation: document.getElementById(txtDes).value,
        Extention_No: document.getElementById(txtEN).value,
        Email: document.getElementById(txtEmail).value,
        Remarks: document.getElementById(txtRemarks).value,
    };


    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/ServiceContact.asmx/Update",
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

                //oTable.fnFilter();
                oTable.draw();
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

function Clear()
{
   // document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = "";
    document.getElementById(ddlCus).value = "";
    document.getElementById(txtName).value = "";
    document.getElementById(txtTN).value = "";
    document.getElementById(txtMN).value = "";
    document.getElementById(txtDes).value = "";
    document.getElementById(txtEN).value = "";
    document.getElementById(txtEmail).value = "";
    document.getElementById(txtRemarks).value = "";

}


function Validate() {
    
    document.getElementById(lblMessage).innerHTML = "";
    if (document.getElementById(ddlCus).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please Select Customer Code and Name <br>";
    }

    if (document.getElementById(txtName).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please insert Name";
    }

    if (document.getElementById(lblMessage).innerHTML == "") {
        Submit();
    }
    else {
        document.getElementById(lblMessage).style.color = "Red";
    }

}