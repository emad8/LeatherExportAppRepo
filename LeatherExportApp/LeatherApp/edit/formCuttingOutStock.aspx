<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formCuttingOutStock.aspx.cs" Inherits="LeatherExportApp.edit.formCuttingOutStock" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        #widthOuter {
            width: 100%;
        }

        #widthInner {
            width: 95px;
        }

        #rangeDate td {
            padding: 5px;
        }

        .mydrop {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }


        #example_paginate ul, #example_filter label {
            float: right;
            margin: 0px;
        }

        tfoot input {
            width: 100%;
            padding: 3px;
            box-sizing: border-box;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cutting OutStock</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        View Cutting OutStock Info

                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dropdown">
                            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                                show/hide
                            <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu">
                                <li>
                                    <input class="showHide" type="checkbox" value="Company" data-column-index="1">Company
                                </li>
                                <li>
                                    <input class="showHide" type="checkbox" value="Lot1" data-column-index="2">Lot
                                </li>
                                
                            </ul>
                        </div>
                        <table class="col-lg-offset-3" id="rangeDate">
                            <tr>
                                <td>From:
                                    <asp:TextBox ID="min" required="required" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                </td>
                                <td>To:
                                    <asp:TextBox ID="max" required="required" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="btnSearch" class="btn btn-default" type="button" value="Search" />
                                </td>
                            </tr>
                        </table>

                        <asp:CalendarExtender ID="CalendarExtender1"
                            Format="MM/dd/yyyy"
                            TargetControlID="min"
                            runat="server" />


                        <asp:CalendarExtender ID="CalendarExtender3"
                            Format="MM/dd/yyyy"
                            TargetControlID="max"
                            runat="server" />
                        <div class="dataTable_wrapper">
                            <table style="width: 100%" class="table table-striped table-bordered table-hover" id="example">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Company</th>
                                        <th>Lot 1</th>
                                        <th>Pcs</th>
                                        <th>Sqft</th>
                                        <th>Lot 2</th>
                                        <th>Pcs</th>
                                        <th>Sqft</th>
                                        <th>Date</th>
                                        <th>Description</th>

                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Id</th>
                                        <th>Company</th>
                                        <th>Lot 1</th>
                                        <th>Pcs</th>
                                        <th>Sqft</th>
                                        <th>Lot 2</th>
                                        <th>Pcs</th>
                                        <th>Sqft</th>
                                        <th>Date</th>
                                        <th>Description</th>

                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </tfoot>
                                <tbody></tbody>
                            </table>

                        </div>


                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>


            <!-- /.col-lg-12 -->
        </div>
        <div class="row">
            <div class="col-lg-12">
                <!-- Trigger the modal with a button -->
                <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">
                        <%--modal-lg--%>

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Cutting OutStock</h4>
                            </div>
                            <div class="modal-body">

                                <asp:Label runat="server" ID="lblMessage"></asp:Label>

                                <div class="form-group">
                                    <label>Company</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlCompany" DataTextField="Name" DataValueField="Id" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlCompany" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id,Name FROM [Company] where IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label>Lot 1</label><label style="color: red;"> *</label><label style="margin-left: 30px"><asp:Label ID="lblLot1Pcs" runat="server"></asp:Label><asp:Label ID="lblLot1Sqft" runat="server"></asp:Label></label>
                                    <asp:DropDownList ID="ddlLot1" onchange="onchangeLot1()" DataTextField="Name" DataValueField="Id" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlLot1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Lot.Id,Name FROM [Lot] where [Lot].IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                <div id="Div2" class="form-group input-group">
                                    <span id="Span1" class="input-group-addon">Pieces<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtPcs" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pieces..." runat="server"></asp:TextBox>
                                </div>
                                <div id="Div3" class="form-group input-group">
                                    <span id="Span2" class="input-group-addon">SqFt<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtSqft" class="form-control" onkeypress="return Onlyfloat(event,this);" placeholder="insert SqFt..." runat="server"></asp:TextBox>
                                </div>
                                <div id="divLot2" runat="server">
                                    <div id="Div4" class="form-group" runat="server">
                                        <label>Lot 2</label><label style="margin-left: 30px"><asp:Label ID="lblLot2Pcs" runat="server"></asp:Label><asp:Label ID="lblLot2Sqft" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="ddlLot2" onchange="onchangeLot2()" DataTextField="Name" DataValueField="Id" class="form-control" runat="server"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlLot2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Lot.Id,Name FROM [Lot] where [Lot].IsDeleted=0"></asp:SqlDataSource>
                                    </div>
                                    <div id="Div5" class="form-group input-group">
                                        <span id="Span3" class="input-group-addon">Pieces<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtPcs2" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pieces..." runat="server"></asp:TextBox>
                                    </div>
                                    <div id="Div6" class="form-group input-group">
                                        <span id="Span5" class="input-group-addon">SqFt<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtSqft2" class="form-control" onkeypress="return Onlyfloat(event,this);" placeholder="insert SqFt..." runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Date<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtDate" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                    <asp:CalendarExtender
                                        ID="CalendarExtender2"
                                        Format="MM/dd/yyyy"
                                        TargetControlID="txtDate"
                                        runat="server" />
                                </div>
                                <div class="form-group input-group">
                                    <span id="Span4" class="input-group-addon">Description</span>
                                    <asp:TextBox ID="txtDescription" class="form-control" placeholder="insert description..." runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="hfId" Value="" />
                                <button id="btnShowHide" onclick="ShowHide()" formnovalidate type="button" class="btn btn-primary">Show/Hide</button>
                                <button id="btnRefresh" onclick="Refresh()" formnovalidate type="button" class="btn btn-primary">Refresh</button>
                                <button id="btnSubmit" onclick="Validate()" type="button" runat="server" class="btn btn-primary">Submit</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

    <script src="../js/MyJs/CuttingOutStock.js"></script>
    <script>
        var ddlLot1 = '<%= ddlLot1.ClientID %>';
        var ddlLot2 = '<%= ddlLot2.ClientID %>';
        var ddlCompany = '<%= ddlCompany.ClientID %>';
        var txtPcs = '<%= txtPcs.ClientID %>';
        var txtSqft = '<%= txtSqft.ClientID %>';
        var txtPcs2 = '<%= txtPcs2.ClientID %>';
        var txtSqft2 = '<%= txtSqft2.ClientID %>';

        var txtDescription = '<%= txtDescription.ClientID %>';
        var txtDate = '<%= txtDate.ClientID %>';

        var hfId = '<%= hfId.ClientID %>';

        var lblLot1Pcs = '<%= lblLot1Pcs.ClientID %>';
        var lblLot2Pcs = '<%= lblLot2Pcs.ClientID %>';
        var lblLot1Sqft = '<%= lblLot1Sqft.ClientID %>';
        var lblLot2Sqft = '<%= lblLot2Sqft.ClientID %>';
        var divLot2 = '<%= divLot2.ClientID %>';

        var min = '<%= min.ClientID %>';
        var max = '<%= max.ClientID %>';

        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>

</asp:Content>

