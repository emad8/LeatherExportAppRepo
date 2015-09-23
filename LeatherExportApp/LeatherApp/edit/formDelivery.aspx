<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formDelivery.aspx.cs" Inherits="LeatherExportApp.edit.formDelivery" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        #example_paginate ul, #example_filter label {
            float: right;
            margin: 0px;
        }

        /*tfoot input {
            width: 100%;
            padding: 3px;
            box-sizing: border-box;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Tables</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        DataTables Advanced Tables

                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <table class="table table-striped table-bordered table-hover" style="width:100%" id="example">
                                <thead>
                                    <tr>
                                        <th>Date</th>
                                        <th>Lot</th>
                                        <th>Description</th>
                                        <th>Pcs</th>
                                        <th>Sqrft</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Date</th>
                                        <th>Lot</th>
                                        <th>Description</th>
                                        <th>Pcs</th>
                                        <th>Sqrft</th>
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
                <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>
                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Delivery</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Pcs</span>
                                    <asp:TextBox runat="server" ID="txtPcs" required="required" class="form-control" placeholder="insert Lot..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Sqrft</span>
                                    <asp:TextBox runat="server" ID="txtSqrft" required="required" class="form-control" placeholder="insert Lot..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Description</span>
                                    <asp:TextBox runat="server" ID="txtDescription" class="form-control" placeholder="insert description..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Date</span>
                                    <asp:TextBox ID="txtDate" required="required" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                    <asp:CalendarExtender
                                        ID="CalendarExtender2"
                                        Format="MM/dd/yyyy"
                                        TargetControlID="txtDate"
                                        runat="server" />
                                </div>
                                
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Lot ID</span>
                                    <asp:DropDownList ID="ddlLot" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlLot" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Lot.Id,Name FROM [Lot] where  [Lot].IsDeleted=0 "></asp:SqlDataSource>
                                </div>


                            </div>
                            <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="hfId" Value="" />
                                <asp:HiddenField runat="server" ID="hfIndex" Value="" />
                                <button id="btnSubmit" onclick="Update()" type="button" class="btn btn-primary">Submit</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>
    <%--<script src="../js/MyJs/ReloadAjax.js"></script>--%>
    <script src="../js/MyJs/Delivery.js"></script>
    <script>
        var txtPcs = '<%= txtPcs.ClientID %>';
        var txtSqrft = '<%= txtSqrft.ClientID %>';
        var txtDescription = '<%= txtDescription.ClientID %>';
        var txtDate = '<% = txtDate.ClientID%>';
        var ddlLot = '<% = ddlLot.ClientID%>';
        var hfId = '<%= hfId.ClientID %>';
        var hfIndex = '<%= hfIndex.ClientID %>';
        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>

</asp:Content>
