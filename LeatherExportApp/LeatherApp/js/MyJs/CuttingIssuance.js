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
            { 'data': 'EmployeeName' },
            { 'data': 'OrderNo' },
            { 'data': 'StyleName' },
            { 'data': 'SizeNo' },
            { 'data': 'Pairs_Issued' },
            { 'data': 'Date' },
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
        sAjaxSource: '../WebServices/ServiceCuttingIssuance.asmx/FilterGet',
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

            aoData.push({ "name": "min", "value": $('#'+min).val()});
            aoData.push({ "name": "max", "value": $('#'+max).val()});
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
    console.log(Id);
    if (confirm('Are you sure you want to delete this Record?')) {
        var Info = { Id: Id };

        $.ajax({
            method: "post",
            //getListOfCars is my webmethod
            url: "../WebServices/ServiceCuttingIssuance.asmx/Delete",
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
    document.getElementById(lblMessage).innerHTML = "";
    document.getElementById(hfId).value = Id;

    Fill_OrderAll();

    document.getElementById(ddlOrder).disabled = true;
    document.getElementById(ddlStyle).disabled = true;
    document.getElementById(ddlSize).disabled = true;




}

function Fill_OrderAll() {
    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCuttingIssuance.asmx/GetOrderAll",
        //data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlOrder = document.getElementById(ddlOrder);
            varddlOrder.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlOrder.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Order_No;
                option.value = st.Id;

                varddlOrder.appendChild(option);


            });
            Fill_StyleAll();

        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}
function Fill_StyleAll() {
    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCuttingIssuance.asmx/GetStylesAll",
        //data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlStyle = document.getElementById(ddlStyle);
            varddlStyle.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlStyle.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Name;
                option.value = st.Id;

                varddlStyle.appendChild(option);


            });
            Fill_SizeAll();
        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}
function Fill_SizeAll() {
    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCuttingIssuance.asmx/GetSizeAll",
        //data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlSize = document.getElementById(ddlSize);
            varddlSize.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlSize.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.No;
                option.value = st.Id;

                varddlSize.appendChild(option);
            });
            SetInfo();
        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}


function SetInfo() {
    var Info = { Id: document.getElementById(hfId).value };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCuttingIssuance.asmx/Get",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (result) {
            document.getElementById(ddlStitcher).value = result.d.Employee_ID;
            document.getElementById(ddlOrder).value = result.d.Order_ID;
            document.getElementById(ddlStyle).value = result.d.Style_ID;
            document.getElementById(ddlSize).value = result.d.Size_ID;
            document.getElementById(txtPairs).value = result.d.Pairs_Issued;
            document.getElementById(txtDate).value = result.d.Date;

            //document.getElementById(hfOrder).value = result.d.Order_ID;
            //document.getElementById(hfStyle).value = result.d.Style_ID;
            //document.getElementById(hfSize).value = result.d.Size_ID;
            //document.getElementById(hfPairs).value = result.d.Pairs_Issued;
        },
        error: function () {
            alert('error');
        }
    });
}

function Update() {

    var Info = {
        Id: document.getElementById(hfId).value,
        Employee_ID: document.getElementById(ddlStitcher).value,
        Order_ID: document.getElementById(ddlOrder).value,
        Style_ID: document.getElementById(ddlStyle).value,
        Size_ID: document.getElementById(ddlSize).value,
        Pairs_Issued: document.getElementById(txtPairs).value,
        Date_Issued: document.getElementById(txtDate).value,

        //OldOrder_ID: document.getElementById(hfOrder).value,
        //OldStyle_ID: document.getElementById(hfStyle).value,
        //OldSize_ID: document.getElementById(hfSize).value,
        //OldPairs: document.getElementById(hfPairs).value
    };


    $.ajax({
        method: "post",
        //getListOfCars is my webmethod
        url: "../WebServices/ServiceCuttingIssuance.asmx/Update",
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

function onchangeOrder() {

    if (document.getElementById(ddlOrder).value == "" && document.getElementById(ddlStyle).value == "" && document.getElementById(ddlSize).value == "" ||
               document.getElementById(ddlOrder).value == "" && document.getElementById(hf1).value == "Order") {
        Refresh();
    }


    if (document.getElementById(ddlStyle).value == "") {
        Fill_Style();
    }
    if (document.getElementById(ddlSize).value == "") {
        Fill_Size();
    }

    if (document.getElementById(hf1).value == "Order") {
        document.getElementById(ddlSize).value = "";
        document.getElementById(ddlStyle).value = "";
        Fill_Size();
        Fill_Style();
    }
    else if (document.getElementById(hf2).value == "Order") {
        if (document.getElementById(hf3).value == "Style") {
            document.getElementById(ddlStyle).value = "";
            Fill_Style();
        }
        else if (document.getElementById(hf3).value == "Size") {
            document.getElementById(ddlSize).value = "";
            Fill_Size();
        }
    }
    if (document.getElementById(ddlOrder).value != "") {
        if (document.getElementById(hf1).value == "") {
            document.getElementById(hf1).value = "Order";
        }
        else if (document.getElementById(hf2).value == "") {
            document.getElementById(hf2).value = "Order";
        }
        else if (document.getElementById(hf3).value == "") {
            document.getElementById(hf3).value = "Order";
        }
    }
    Fill_Pair();
}

function onchangeStyle() {

    if (document.getElementById(ddlOrder).value == "" && document.getElementById(ddlStyle).value == "" && document.getElementById(ddlSize).value == "" ||
               document.getElementById(ddlStyle).value == "" && document.getElementById(hf1).value == "Style") {
        Refresh();
    }


    if (document.getElementById(ddlOrder).value == "") {
        Fill_Order();
    }
    if (document.getElementById(ddlSize).value == "") {
        Fill_Size();
    }

    if (document.getElementById(hf1).value == "Style") {
        document.getElementById(ddlSize).value = "";
        document.getElementById(ddlOrder).value = "";
        Fill_Size();
        Fill_Order();
    }
    else if (document.getElementById(hf2).value == "Style") {
        if (document.getElementById(hf3).value == "Order") {
            document.getElementById(ddlOrder).value = "";
            Fill_Order();
        }
        else if (document.getElementById(hf3).value == "Size") {
            document.getElementById(ddlSize).value = "";
            Fill_Size();
        }
    }
    if (document.getElementById(ddlStyle).value != "") {
        if (document.getElementById(hf1).value == "") {
            document.getElementById(hf1).value = "Style";
        }
        else if (document.getElementById(hf2).value == "") {
            document.getElementById(hf2).value = "Style";
        }
        else if (document.getElementById(hf3).value == "") {
            document.getElementById(hf3).value = "Style";
        }
    }
    Fill_Pair();
}

function onchangeSize() {

    if (document.getElementById(ddlOrder).value == "" && document.getElementById(ddlStyle).value == "" && document.getElementById(ddlSize).value == "" ||
               document.getElementById(ddlSize).value == "" && document.getElementById(hf1).value == "Size") {
        Refresh();
    }


    if (document.getElementById(ddlOrder).value == "") {
        Fill_Order();
    }
    if (document.getElementById(ddlStyle).value == "") {
        Fill_Style();
    }

    if (document.getElementById(hf1).value == "Size") {
        document.getElementById(ddlStyle).value = "";
        document.getElementById(ddlOrder).value = "";
        Fill_Style();
        Fill_Order();
    }
    else if (document.getElementById(hf2).value == "Size") {
        if (document.getElementById(hf3).value == "Order") {
            document.getElementById(ddlOrder).value = "";
            Fill_Order();
        }
        else if (document.getElementById(hf3).value == "Style") {
            document.getElementById(ddlStyle).value = "";
            Fill_Style();
        }
    }

    if (document.getElementById(ddlSize).value != "") {
        if (document.getElementById(hf1).value == "") {
            document.getElementById(hf1).value = "Size";
        }
        else if (document.getElementById(hf2).value == "") {
            document.getElementById(hf2).value = "Size";
        }
        else if (document.getElementById(hf3).value == "") {
            document.getElementById(hf3).value = "Size";
        }
    }
    Fill_Pair();
}

function Refresh() {

    document.getElementById(ddlOrder).disabled = false;
    document.getElementById(ddlStyle).disabled = false;
    document.getElementById(ddlSize).disabled = false;

    document.getElementById(ddlOrder).value = "";
    document.getElementById(ddlStyle).value = "";
    document.getElementById(ddlSize).value = "";

    document.getElementById(hf1).value = "";
    document.getElementById(hf2).value = "";
    document.getElementById(hf3).value = "";

    Fill_Order();
    Fill_Size();
    Fill_Style();

    //document.getElementById(txtPairs).value = "";
}

function Fill_Pair() {

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

function Fill_Style() {

    var Order_ID = 0, Style_ID = 0, Size_ID = 0;

    if (document.getElementById(ddlOrder).value != "") {
        Order_ID = document.getElementById(ddlOrder).value;
    }
    if (document.getElementById(ddlStyle).value != "") {
        Style_ID = document.getElementById(ddlStyle).value;
    }
    if (document.getElementById(ddlSize).value != "") {
        Size_ID = document.getElementById(ddlSize).value;
    }

    var Info = {
        Order_ID: Order_ID,
        Style_ID: Style_ID,
        Size_ID: Size_ID
    };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCuttingIssuance.asmx/GetStyle",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlStyle = document.getElementById(ddlStyle);
            varddlStyle.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlStyle.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Name;
                option.value = st.Id;

                varddlStyle.appendChild(option);
            });

        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}

function Fill_Size() {
    var Order_ID = 0, Style_ID = 0, Size_ID = 0;

    if (document.getElementById(ddlOrder).value != "") {
        Order_ID = document.getElementById(ddlOrder).value;
    }
    if (document.getElementById(ddlStyle).value != "") {
        Style_ID = document.getElementById(ddlStyle).value;
    }
    if (document.getElementById(ddlSize).value != "") {
        Size_ID = document.getElementById(ddlSize).value;
    }

    var Info = {
        Order_ID: Order_ID,
        Style_ID: Style_ID,
        Size_ID: Size_ID
    };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCuttingIssuance.asmx/GetSize",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlSize = document.getElementById(ddlSize);
            varddlSize.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlSize.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.No;
                option.value = st.Id;

                varddlSize.appendChild(option);
            });

        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}

function Fill_Order() {
    var Order_ID = 0, Style_ID = 0, Size_ID = 0;

    if (document.getElementById(ddlOrder).value != "") {
        Order_ID = document.getElementById(ddlOrder).value;
    }
    if (document.getElementById(ddlStyle).value != "") {
        Style_ID = document.getElementById(ddlStyle).value;
    }
    if (document.getElementById(ddlSize).value != "") {
        Size_ID = document.getElementById(ddlSize).value;
    }

    var Info = {
        Order_ID: Order_ID,
        Style_ID: Style_ID,
        Size_ID: Size_ID
    };

    $.ajax({
        method: "post",
        url: "../WebServices/ServiceCuttingIssuance.asmx/GetOrder",
        data: JSON.stringify(Info),
        contentType: "application/json; charset=utf-8",
        dataType: "json", // dataType is json format
        success: function (response) {

            var varddlOrder = document.getElementById(ddlOrder);
            varddlOrder.innerHTML = "";
            var option = document.createElement("option");
            option.textContent = "Select here";
            option.value = "";

            varddlOrder.appendChild(option);

            $(response.d).each(function (index, st) {
                option = document.createElement("option");
                option.textContent = st.Order_No;
                option.value = st.Id;

                varddlOrder.appendChild(option);
            });

        },
        error: function (error) {
            alert('error : ' + error);
        }
    });
}

function Clear() {
    document.getElementById(ddlStitcher).value = "";

    document.getElementById(ddlOrder).value = "";
    document.getElementById(ddlStyle).value = "";
    document.getElementById(ddlSize).value = "";

    document.getElementById(hf1).value = "";
    document.getElementById(hf2).value = "";
    document.getElementById(hf3).value = "";

    Fill_Order();
    Fill_Size();
    Fill_Style();

    document.getElementById(txtPairs).value = "";

    document.getElementById(txtDate).value = "";
}

function Validate() {
    document.getElementById(lblMessage).innerHTML = "";
    if (document.getElementById(ddlStitcher).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please select Stitcher<br>";
    }
    if (document.getElementById(ddlOrder).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please select Order<br>";
    }
    if (document.getElementById(ddlStyle).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please select Style<br>";
    }
    if (document.getElementById(ddlSize).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please select Size<br>";
    }
    if (document.getElementById(txtPairs).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please enter Pairs<br>";
    }
    if (document.getElementById(txtDate).value == "") {
        document.getElementById(lblMessage).innerHTML += "Please enter Date<br>";
    }

    if (document.getElementById(lblMessage).innerHTML == "") {
        Update();
    }
    else {
        document.getElementById(lblMessage).style.color = "Red";
    }

}