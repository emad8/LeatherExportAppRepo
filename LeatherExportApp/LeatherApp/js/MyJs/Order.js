//var oTable;

$(document).ready(function () {
    //$.ajax({
    //url: '../WebServices/ServiceOrder.asmx/getListOfStyles',
    //method: 'post',
    //dataType: 'json',
    //success: function (data) {
    oTable = $('#example').dataTable({
        //data: data,
        columns: [
            { 'data': 'Order_No' },
            {
                'data': 'Description',
                "bSearchable": false,
                "bSortable": false,
            },
            { 'data': 'DateString' },
            { 'data': 'Name' },
            
            {
                'data': 'ForEdit',
                "bSearchable": false,
                "bSortable": false,
                'render': function (oObj) {
                    //return '<a href="#" onclick="ShowEditPopup(' + oObj.aData.DocumentCategoryCode + ')"><div align="center">Edit</div></a>';
                    return '<td><a href=\'javascript:;\' onclick="return Get_Order_By_Id(' + oObj + ')" data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>';
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
        sAjaxSource: '../WebServices/ServiceOrder.asmx/Filter_Get_Order',
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

function Get_Order_By_Id(Id) {
    console.log(Id);
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = Id;
    //document.getElementById(hfIndex).value = RowIndex;
    var Info = { Id: Id };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceOrder.asmx/Get_Order_By_Id",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(txtName).value = result.d.Order_No;
            document.getElementById(txtDescription).value = result.d.Description;
            document.getElementById(txtDate).value = result.d.DateString;
            document.getElementById(ddvendor).value = result.d.Vendor_ID;
            //e.options[e.selectedIndex].value=result.d.Vendor_ID;
           
            
            
        },
        error: function () {
            alert('error');
        }
    });
}

function Delete(Id) {
    console.log(Id);
    if (confirm('Are you sure you want to delete this Record?')) {
        var Info = { Id: Id };


        $.ajax({
            method: "post",
            //getListOfCars is my webmethod
            url: "../WebServices/ServiceOrder.asmx/DeleteOrderById",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                console.log(result.d);
                if (result.d == true) {

                    
                    oTable.fnFilter();
                    
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

function Update() {

    var Info = {
        Id: document.getElementById(hfId).value,
        Order_No: document.getElementById(txtName).value,
        Description: document.getElementById(txtDescription).value,
        Date_Of_Shipping: document.getElementById(txtDate).value,
        Vendor_ID: document.getElementById(ddvendor).value,
    };


    $.ajax({
        method: "post",
        url: "../WebServices/ServiceOrder.asmx/Update",
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
                
            }
        },
        error: function () {
            alert('error');
        }
    });

}
