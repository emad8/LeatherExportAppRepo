//var oTable;

$(document).ready(function () {
    //$.ajax({
    //url: '../WebServices/ServicePayment.asmx/getListOfStyles',
    //method: 'post',
    //dataType: 'json',
    //success: function (data) {
    oTable = $('#example').DataTable({

        //data: data,
        columns: [
            { 'data': 'Customer_Code' },

            { 'data': 'Customer_Name' },

            { 'data': 'Payment_Terms' },

            { 'data': 'Bank_Name' },

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
                    return '<td><a href=\'javascript:;\' onclick="return Get_Payment_Info_By_Id(' + oObj + ')" data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>';
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
        sAjaxSource: '../WebServices/ServicePayment.asmx/Filter_Get_Payment_Info',
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
            document.getElementById(txtPT).value = "";
            document.getElementById(txtBN).value = "";
            document.getElementById(txtAddress).value = "";
            document.getElementById(txtZP).value = "";
            document.getElementById(txtSP).value = "";
            document.getElementById(txtPhone).value = "";
            document.getElementById(txtCity).value = "";
            document.getElementById(txtCountry).value = "";
            document.getElementById(txtFax).value = "";
        }

    });
    
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
            url: "../WebServices/ServicePayment.asmx/Delete_Payment_Info_By_Id",
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

function Get_Payment_Info_By_Id(ID) {
    console.log(ID);
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = ID;
    //document.getElementById(hfIndex).value = RowIndex;
    var Info = { ID: ID };

    $.ajax({
        method: "post",
        url: "../WebServices/ServicePayment.asmx/Get_Payment_Info_By_Id",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(ddlCus).value = result.d.Customer_ID;
            document.getElementById(txtPT).value = result.d.Payment_Terms;
            document.getElementById(txtBN).value = result.d.Bank_Name;
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
    }
    else {

        Update();


    }


}

function Clear() {

    document.getElementById(hfId).value = "";
    document.getElementById(ddlCus).value = "";
    document.getElementById(txtPT).value = "";
    document.getElementById(txtBN).value = "";
    document.getElementById(txtAddress).value = "";
    document.getElementById(txtZP).value = "";
    document.getElementById(txtSP).value = "";
    document.getElementById(txtPhone).value = "";
    document.getElementById(txtCity).value = "";
    document.getElementById(txtCountry).value = "";
    document.getElementById(txtFax).value = "";


}

function Validate() {
    debugger;
    document.getElementById(lblMessage).innerHTML = "";
    if (document.getElementById(ddlCus).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please Select Customer Code and Name <br>";
    }

    if (document.getElementById(txtBN).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please insert Bank Name";
    }

    if (document.getElementById(lblMessage).innerHTML == "") {
        Submit();
    }
    else {
        document.getElementById(lblMessage).style.color = "Red";
    }

}

function Insert() {

    var Info = {
        Customer_ID: document.getElementById(ddlCus).value,
        Payment_Terms: document.getElementById(txtPT).value,
        Bank_Name: document.getElementById(txtBN).value,
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
        url: "../WebServices/ServicePayment.asmx/Insert",
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
        Payment_Terms: document.getElementById(txtPT).value,
        Bank_Name: document.getElementById(txtBN).value,
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
        url: "../WebServices/ServicePayment.asmx/Update",
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