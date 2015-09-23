

$(document).ready(function () {
    
    oTable = $('#example').dataTable({
        
        columns: [
            { 'data': 'Standard_Value' },

            { 'data': 'Name' },

            { 'data': 'No' },

            {
                'data': 'Cutting_Rate',
                "bSearchable": false,
                "bSortable": false,
            },
            {
                'data': 'Elastic_Stitching',
                "bSearchable": false,
                "bSortable": false,
            },
            {
                'data': 'OverLock',
                "bSearchable": false,
                "bSortable": false,
            },
            {
                'data': 'Contractor_Commission',
                "bSearchable": false,
                "bSortable": false,
            },
            {
                'data': 'BindingRate',
                "bSearchable": false,
                "bSortable": false,
            },
            {
                'data': 'GloveStitchingRate',
                "bSearchable": false,
                "bSortable": false,
            },
            
            
            {
                'data': 'ForEdit',
                "bSearchable": false,
                "bSortable": false,
                'render': function (oObj) {
                    
                    return '<td><a href=\'javascript:;\' onclick="return Get_Rate_By_Id(' + oObj + ')" data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>';
                }
            },
            {
                'data': 'ForDelete',
                "bSearchable": false,
                "bSortable": false,
                'render': function (oObj) {

                    
                    return '<td><a href=\'javascript:;\' id="btnDelete" onclick="return Delete(' + oObj + ')" ><span class="glyphicon glyphicon-trash" aria-hidden="true"></span>  </a></td>';
                }
            }
        ],
        bServerSide: true,
        sAjaxSource: '../WebServices/ServiceRate.asmx/Filter_Get_Rate',
        sServerMethod: 'post',
        
    });
    

});

function Get_Rate_By_Id(Id) {
    debugger;
    console.log(Id);
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = Id;
    var Info = { Id: Id };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceRate.asmx/Get_Rate_By_Id",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(txtSV).value = result.d.Standard_Value;
            document.getElementById(txtCR).value = result.d.Cutting_Rate;
            document.getElementById(txtES).value = result.d.Elastic_Stitching;
            document.getElementById(txtOL).value = result.d.OverLock;
            document.getElementById(txtCC).value = result.d.Contractor_Commission;
            document.getElementById(txtBR).value = result.d.BindingRate;
            document.getElementById(txtGSR).value = result.d.GloveStitchingRate;
            document.getElementById(ddlStyle).value = result.d.Style_ID;
            document.getElementById(ddlSize).value = result.d.Size_ID;
            
           
            
            
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
            url: "../WebServices/ServiceRate.asmx/DeleteRateById",
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
        Standard_Value: document.getElementById(txtSV).value,
        Cutting_Rate: document.getElementById(txtCR).value,
        Elastic_Stitching: document.getElementById(txtES).value,
        OverLock: document.getElementById(txtOL).value,
        Contractor_Commission: document.getElementById(txtCC).value,
        BindingRate: document.getElementById(txtBR).value,
        GloveStitchingRate: document.getElementById(txtGSR).value,
        Style_ID: document.getElementById(ddlStyle).value,
        Size_ID: document.getElementById(ddlSize).value,
    };


    $.ajax({
        method: "post",
        url: "../WebServices/ServiceRate.asmx/Update",
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
