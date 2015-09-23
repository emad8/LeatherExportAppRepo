<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formCuttingIssuance.aspx.cs" Inherits="LeatherExportApp.edit.formCuttingIssuance" %>

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
            padding:5px ;
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
                <h1 class="page-header">Cutting Issuance</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        View Cutting Issuance Info

                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
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

                        <asp:CalendarExtender
                            Format="MM/dd/yyyy"
                            TargetControlID="min"
                            runat="server" />


                        <asp:CalendarExtender
                            Format="MM/dd/yyyy"
                            TargetControlID="max"
                            runat="server" />



                        <div class="dataTable_wrapper">
                            <table style="width: 100%" class="table table-striped table-bordered table-hover" id="example">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Stitcher</th>
                                        <th>Order</th>
                                        <th>Style</th>
                                        <th>Size</th>
                                        <th>Pairs</th>
                                        <th>Date</th>

                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Id</th>
                                        <th>Stitcher</th>
                                        <th>Order</th>
                                        <th>Style</th>
                                        <th>Size</th>
                                        <th>Pairs</th>
                                        <th>Date</th>

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
                <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">
                        <%--modal-lg--%>

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Cutting Issuance</h4>
                            </div>
                            <div class="modal-body">

                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                <%--<asp:HiddenField ID="hfOrder" runat="server" />
                                <asp:HiddenField ID="hfStyle" runat="server" />
                                <asp:HiddenField ID="hfSize" runat="server" />
                                <asp:HiddenField ID="hfPairs" runat="server" />--%>

                                <div id="Div1" class="form-group" runat="server">
                                    <label>Stitcher</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlStitcher" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlStitcher" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Employee.Id,Employee.Name FROM [Employee] Inner Join Category on Employee.Category=Category.Id where UPPER(Category.Name)='STITCHER' and Employee.IsDeleted=0"></asp:SqlDataSource>
                                </div>

                                <div class="form-group">
                                    <label>Order #</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlOrder" DataTextField="Order_No" DataValueField="Id" onchange="onchangeOrder();" required="required" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlOrder" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Order].Id,Order_No FROM [Order] where IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label>Style</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlStyle" DataTextField="Name" DataValueField="Id" required="required" onchange="onchangeStyle();" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlStyle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Style.Id,Name FROM [Style] where IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label>Size</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlSize" DataTextField="No" DataValueField="Id" required="required" class="form-control" onchange="onchangeSize();" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlSize" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Size.Id,No FROM [Size] where IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Pairs<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtPairs" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pairs..." runat="server"></asp:TextBox>
                                </div>
                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Date<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtDate" required="required" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                    <asp:CalendarExtender
                                        ID="CalendarExtender2"
                                        Format="MM/dd/yyyy"
                                        TargetControlID="txtDate"
                                        runat="server" />
                                </div>

                            </div>
                            <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="hfId" Value="" />
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

    <script src="../js/MyJs/CuttingIssuance.js"></script>
    <script>
        var ddlStitcher = '<%= ddlStitcher.ClientID %>';
        var ddlOrder = '<%= ddlOrder.ClientID %>';
        var ddlStyle = '<%= ddlStyle.ClientID %>';
        var ddlSize = '<%= ddlSize.ClientID %>';
        var txtPairs = '<%= txtPairs.ClientID %>';
        var txtDate = '<%= txtDate.ClientID %>';

        var hfId = '<%= hfId.ClientID %>';

        var hf1 = '<%= HiddenField1.ClientID %>';
        var hf2 = '<%= HiddenField2.ClientID %>';
        var hf3 = '<%= HiddenField3.ClientID %>';

        var min = '<%= min.ClientID %>';
        var max = '<%= max.ClientID %>';

        //var hfOrder = '<= hfOrder.ClientID %>';
        //var hfStyle = '<= hfStyle.ClientID %>';
        //var hfSize = '<= hfSize.ClientID %>';
        //var hfPairs = '<= hfPairs.ClientID %>';

        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>

</asp:Content>

