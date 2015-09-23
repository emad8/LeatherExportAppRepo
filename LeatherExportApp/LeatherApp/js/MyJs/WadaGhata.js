$(document).ready(function () {
    $('#example tfoot th').each(function () {
        var title = $('#example thead th').eq($(this).index()).text();
        if (title != "Edit" && title != "Delete") {
            $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        }
    });

    oTable = $('#example').DataTable({
        "columnDefs": [
            {
                "targets": [0],
                "visible": false
            }],
        columns: [
            {
                'data': 'Id',
                "visible": false,
            },
            { 'data': 'Lot_1Name' },
            { 'data': 'Pcs' },
            { 'data': 'Sqft' },
            { 'data': 'Lot_2Name' },
            { 'data': 'Pcs2' },
            { 'data': 'Sqft2' },

            { 'data': 'Date2' },
            {
                'data': 'Description',
                "bSortable": false,
                "bSearchable": false,
            },
            {
                'data': 'ForEdit',
                "bSearchable": false,
                "bSortable": false,
                'render': function (oObj) {
                    //return '<a href="#" onclick="ShowEditPopup(' + oObj.aData.DocumentCategoryCode + ')"><div align="center">Edit</div></a>';
                    return '<td><a href=\'javascript:;\' onclick="return Get(' + oObj + ')" data-toggle="modal" data-target="#myModal" > <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>  </a></td>';
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
        sAjaxSource: '../WebServices/ServiceWadaGhata.asmx/FilterGet',
        sServerMethod: 'post',
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        "initComplete": function () {

            // Apply the search
            oTable.columns().every(function () {
                var that = this;

                $('input', this.footer()).on('keyup change', function (index) {

                    that
                        .search(this.value)
                        .draw();


                    //oTable.column([0, 0]).search('style2').draw();
                });
            });

        },
        "fnServerData": function (sSource, aoData, fnCallback) {

            aoData.push({ "name": "min", "value": $('#' + min).val() });
            aoData.push({ "name": "max", "value": $('#' + max).val() });
            $.ajax({
                "dataType": 'json',
                "type": "POST",
                "url": sSource,
                "data": aoData,
                "success": fnCallback
            });
        }
    });

    $('#btnSearch').click(function () {

        oTable.draw();
    });
});

function Delete(Id) {
    if (confirm('Are you sure you want to delete this Record?')) {
        var Info = { Id: Id };

        $.ajax({
            method: "post",
            //getListOfCars is my webmethod
            url: "../WebServices/ServiceWadaGhata.asmx/Delete",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                console.log(result.d);
                if (result.d == true) {

                    oTable.draw();
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

function Get(Id) {
    debugger;
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = Id;
    Fill_Lot1All();
    
    Hide();
    document.getElementById(ddlLot1).disabled = true;
    document.getElementById(ddlLot2).disabled = true;

}

function Update() {
    
    var Lot2 = -1, Pcs2 = -1, Sqft2 = -1;
    if (document.getElementById(divLot2).style.display == 'block') {
        Lot2 = document.getElementById(ddlLot2).value;
        Pcs2 = document.getElementById(txtPcs2).value;
        Sqft2 = document.getElementById(txtSqft2).value;
    }

    var Info = {
        Id: document.getElementById(hfId).value,
        Lot1: document.getElementById(ddlLot1).value,
        Pcs: document.getElementById(txtPcs).value,
        Sqft: document.getElementById(txtSqft).value,

        Lot2: Lot2,
        Pcs2: Pcs2,
        Sqft2: Sqft2,
        
        Date: document.getElementById(txtDate).value,
        Description: document.getElementById(txtDescription).value,
    };


    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/ServiceWadaGhata.asmx/Update",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            
            if (result.d.indexOf("Already Exists") > -1) {
                document.getElementById(lblMessage).style.color = "Red";
            }
            else {
                document.getElementById(lblMessage).style.color = "Green";

                Clear();
                oTable.draw();
            }
            document.getElementById(lblMessage).innerHTML = result.d;
        },
        error: function () {
            alert('required');
        }
    });

}

function SetInfo() {
    var Info = { Id: document.getElementById(hfId).value };
    ///////////////////////////////////////////////////////


    $.ajax({
        method: "post",
        url: "../WebServices/ServiceWadaGhata.asmx/Get",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            
            document.getElementById(ddlLot1).value = result.d.Lot_1;
            document.getElementById(txtPcs).value = result.d.Pcs;
            document.getElementById(txtSqft).value = result.d.Sqft;

            if (result.d.Lot_2 != null) {
                Show();
                document.getElementById(ddlLot2).value = result.d.Lot_2;
                document.getElementById(txtPcs2).value = result.d.Pcs2;
                document.getElementById(txtSqft2).value = result.d.Sqft2;
            }
            document.getElementById(txtDescription).value = result.d.Description;
            document.getElementById(txtDate).value = result.d.Date2;
        },
        error: function () {
            alert('error');
        }
    });
}

function onchangeLot1() {
    debugger;
    if (document.getElementById(ddlLot1).value != "")
    {
        Fill_Lot2();
        document.getElementById(ddlLot2).disabled = false;


        var Info = { Lot_ID: document.getElementById(ddlLot1).value };

        $.ajax({
            method: "post",
            url: "../WebServices/ServiceWadaGhata.asmx/GetLot_PcsSqft",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            dataType: "json", // dataType is json format
            success: function (result) {

                document.getElementById(lblLot1Pcs).innerHTML = result.d;
            },
            error: function () {
                alert('error : onchange lot1');
            }
        });
    }
    else {
        document.getElementById(ddlLot2).disabled = true;
        document.getElementById(ddlLot2).value = "";
        Hide();
        document.getElementById(lblLot2Pcs).value = "";
    }
    
}

function onchangeLot2() {
    if (document.getElementById(ddlLot2).value != "")
    {
        var Info = { Lot_ID: document.getElementById(ddlLot2).value };

        $.ajax({
            method: "post",
            url: "../WebServices/ServiceWadaGhata.asmx/GetLot_PcsSqft",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            dataType: "json", // dataType is json format
            success: function (result) {
                
                document.getElementById(lblLot2Pcs).innerHTML = result.d;
            },
            error: function () {
                alert('error');
            }
        });
    }
    else
    {
        document.getElementById(lblLot2Pcs).value = "";
    }
}

function Fill_PcsSqft() {

    if (document.getElementById(ddlOrder).value != "" && document.getElementById(ddlSize).value != "" && document.getElementById(ddlStyle).value != "") {
        var Order_ID = 0, Style_ID = 0, Size_ID = 0;

        Order_ID = document.getElementById(ddlOrder).value;
        Style_ID = document.getElementById(ddlStyle).value;
        Size_ID = document.getElementById(ddlSize).value;

        var Info = {
            Order_ID: Order_ID,
            Style_ID: Style_ID,
            Size_ID: Size_ID
        };

        $.ajax({
            method: "post",
            url: "../WebServices/ServiceCuttingIssuance.asmx/GetPairs",
            data: JSON.stringify(Info),
            contentType: "application/json; charset=utf-8",
            dataType: "json", // dataType is json format
            success: function (response) {

                document.getElementById(txtPairs).value = response.d;
            },
            error: function (error) {
                alert('error : ' + error);
            }
        });
    }
}

function Fill_Lot1() {

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceWadaGhata.asmx/GetLot1",
        //data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlLot1 = document.getElementById(ddlLot1);
            varddlLot1.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlLot1.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Name;
                option.value = st.Id;

                varddlLot1.appendChild(option);
            });

        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}
function Fill_Lot1All() {

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceWadaGhata.asmx/GetLotAll",
        //data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlLot1 = document.getElementById(ddlLot1);
            varddlLot1.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlLot1.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Name;
                option.value = st.Id;

                varddlLot1.appendChild(option);
            });
            Fill_Lot2All();

        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}

function Fill_Lot2() {

    var Info = {
        Lot1_ID: document.getElementById(ddlLot1).value
    };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceWadaGhata.asmx/GetLot2",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlLot2 = document.getElementById(ddlLot2);
            varddlLot2.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlLot2.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Name;
                option.value = st.Id;

                varddlLot2.appendChild(option);
            });
        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}

function Fill_Lot2All() {

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceWadaGhata.asmx/GetLotAll",
        //data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlLot2 = document.getElementById(ddlLot2);
            varddlLot2.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlLot2.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Name;
                option.value = st.Id;

                varddlLot2.appendChild(option);
                
            });
            SetInfo();
        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}

function Clear() {
    document.getElementById(ddlLot1).disabled = false;
    document.getElementById(ddlLot2).disabled = true;
    Hide();

    document.getElementById(ddlLot1).value = "";
    document.getElementById(ddlLot2).value = "";

    Fill_Lot1();

    document.getElementById(txtPcs).value = "";
    document.getElementById(txtPcs2).value = "";
    document.getElementById(txtSqft).value = "";
    document.getElementById(txtSqft2).value = "";
    document.getElementById(txtDate).value = "";
    document.getElementById(txtDescription).value = "";
}

function Refresh() {

    document.getElementById(ddlLot1).disabled = false;
    document.getElementById(ddlLot2).disabled = true;
    //Hide();

    document.getElementById(ddlLot1).value = "";
    document.getElementById(ddlLot2).value = "";

    Fill_Lot1();
}

function Validate() {
    document.getElementById(lblMessage).innerHTML = "";
    if (document.getElementById(ddlLot1).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please select Lot1<br>";
    }
    if (document.getElementById(txtPcs).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please select Pcs<br>";
    }
    if (document.getElementById(txtSqft).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please enter Sqft<br>";
    }
    if (document.getElementById(divLot2).style.display == 'block') {
        if (document.getElementById(ddlLot2).value == "") {
            document.getElementById(lblMessage).innerHTML += "Please select Lot2<br>";
        }
        if (document.getElementById(txtPcs2).value == "") {
            document.getElementById(lblMessage).innerHTML += "Please select Pcs2<br>";
        }

        if (document.getElementById(txtSqft2).value == "") {
            document.getElementById(lblMessage).innerHTML += "Please enter Sqft2<br>";
        }
    }

    if (document.getElementById(txtDate).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please enter Date<br>";
    }
    //if (document.getElementById(txtDescription).value == "") {
    //    document.getElementById(lblMessage).innerHTML += "Please enter Description<br>";
    //}


    if (document.getElementById(lblMessage).innerHTML == "") {
        Update();
    }
    else {
        document.getElementById(lblMessage).style.color = "Red";
    }

}

function ShowHide() {
    var e = document.getElementById(divLot2);
    if (e.style.display == 'block')
        e.style.display = 'none';
    else
        e.style.display = 'block';
}

function Show() {
    document.getElementById(divLot2).style.display = 'block';
}

function Hide() {
    document.getElementById(divLot2).style.display = 'none';
}