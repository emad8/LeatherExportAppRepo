//var oTable;

$(document).ready(function () {
    
    //$.ajax({
    //url: '../WebServices/ServiceCustomer.asmx/getListOfStyles',
    //method: 'post',
    //dataType: 'json',
    //success: function (data) {
    oTable = $('#example').dataTable({
        //data: data,
        columns: [
            { 'data': 'Code' },

            { 'data': 'Name' },

            { 'data': 'Address' },

            { 'data': 'City' },

            { 'data': 'Zip_Postal' },

            { 'data': 'State_Province' },

            { 'data': 'Country' },

            { 'data': 'Phone' },

            { 'data': 'Fax' },

            {
                'data': 'ForEdit',
                "bSearchable": false,
                "bSortable": false,
                'render': function (oObj) {
                    //return '<a href="#" onclick="ShowEditPopup(' + oObj.aData.DocumentCustomerCode + ')"><div align="center">Edit</div></a>';
                    return '<td><a href=\'javascript:;\' onclick="return Get_Customer_Info_By_Id(' + oObj + ')" data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>';
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
        sAjaxSource: '../WebServices/ServiceCustomer.asmx/Filter_Get_Customer_Info',
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

        document.getElementById(lblMessage).innerHTML = "";
        document.getElementById(hfId).value = "";
        document.getElementById(txtCode).value = "";
        document.getElementById(txtName).value = "";
        document.getElementById(txtAddress).value = "";
        document.getElementById(txtZP).value = "";
        document.getElementById(txtSP).value = "";
        document.getElementById(txtPhone).value = "";
        document.getElementById(txtCity).value = "";
        document.getElementById(txtCountry).value = "";
        document.getElementById(txtFax).value = "";

    });
    
    if (document.getElementById(hfNav).value != "") {
        
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
            url: "../WebServices/ServiceCustomer.asmx/Delete_Customer_Info_By_Id",
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

function Get_Customer_Info_By_Id(ID) {
    console.log(ID);
    
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = ID;
    //document.getElementById(hfIndex).value = RowIndex;
    var Info = { ID: ID };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCustomer.asmx/Get_Customer_Info_By_Id",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(txtCode).value = result.d.Code;
            document.getElementById(txtName).value = result.d.Name;
            document.getElementById(txtAddress).value = result.d.Address;
            document.getElementById(txtZP).value = result.d.Zip_Postal;
            document.getElementById(txtSP).value = result.d.State_Province;
            document.getElementById(txtPhone).value = result.d.Phone;
            document.getElementById(txtCity).value = result.d.City;
            document.getElementById(txtCountry).value = result.d.Country;
            document.getElementById(txtFax).value = result.d.Fax;
        },
        error: function () {
            alert('error');
        }
    });




}



function Submit() {
    
    if (document.getElementById(hfId).value == "") {
        
        
        Insert();
        debugger;
        var messa = document.getElementById(lblMessage).innerHTML;
        var nav= document.getElementById(hfNav).value;
        if (document.getElementById(lblMessage).innerHTML == "Inserted Sucessfully" && document.getElementById(hfNav).value !="") 
        {
            return true;
        }
    }
    else {

        Update();
    }
    return false;
}

function Insert() {

    var Info = {
        Code: document.getElementById(txtCode).value,
        Name: document.getElementById(txtName).value,
        Address: document.getElementById(txtAddress).value,
        Zip_Postal: document.getElementById(txtZP).value,
        State_Province: document.getElementById(txtSP).value,
        Phone: document.getElementById(txtPhone).value,
        City: document.getElementById(txtCity).value,
        Country: document.getElementById(txtCountry).value,
        Fax: document.getElementById(txtFax).value,
    };

    
    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/ServiceCustomer.asmx/Insert",
        data: JSON.stringify(Info),
        async: false,
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
                oTable.fnFilter();
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
        Code: document.getElementById(txtCode).value,
        Name: document.getElementById(txtName).value,
        Address: document.getElementById(txtAddress).value,
        Zip_Postal: document.getElementById(txtZP).value,
        State_Province: document.getElementById(txtSP).value,
        Phone: document.getElementById(txtPhone).value,
        City: document.getElementById(txtCity).value,
        Country: document.getElementById(txtCountry).value,
        Fax: document.getElementById(txtFax).value,
    };


    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/ServiceCustomer.asmx/Update",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            if (result.d == "1") {
                document.getElementById(lblMessage).style.color = "Red";
                document.getElementById(lblMessage).innerHTML = "Already Exists";
            }
            else if (result.d == "-1") {
                document.getElementById(lblMessage).style.color = "Red";
                document.getElementById(lblMessage).innerHTML = "You Dont Have Rights.";
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

function Clear()
{
    document.getElementById(hfId).value = "";
    document.getElementById(txtCode).value = "";
    document.getElementById(txtName).value = "";
    document.getElementById(txtAddress).value = "";
    document.getElementById(txtZP).value = "";
    document.getElementById(txtSP).value = "";
    document.getElementById(txtPhone).value = "";
    document.getElementById(txtCity).value = "";
    document.getElementById(txtCountry).value = "";
    document.getElementById(txtFax).value = "";


}

function Validate() {
    var bool = false;
    document.getElementById(lblMessage).innerHTML = "";
    if (document.getElementById(txtCode).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please insert Code<br>";
    }

    if (document.getElementById(txtName).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please insert Name";
    }

    if (document.getElementById(lblMessage).innerHTML == "") {
        var bool= Submit();
    }
    else {
        document.getElementById(lblMessage).style.color = "Red";
    }
    return bool;
}