<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="table2.aspx.cs" Inherits="LeatherExportApp.edit.table2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
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
                            <table style="width:100%" class="table table-striped table-bordered table-hover" id="example">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Name</th>
                                        <th>Description</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Id</th>
                                        <th>Name</th>
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
                <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Style</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Style</span>
                                    <asp:TextBox runat="server" ID="txtName" required="required" class="form-control" placeholder="insert style..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Description</span>
                                    <asp:TextBox runat="server" ID="txtDescription" class="form-control" placeholder="insert description..."></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Lot 1</label><label style="color: red;"> *</label><label style="margin-left: 30px"><asp:Label ID="lblLot1Pcs" runat="server"></asp:Label><asp:Label ID="lblLot1Sqft" runat="server"></asp:Label></label>
                                    <asp:DropDownList ID="ddlLot1" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" onchange="GetDDl(this);" ></asp:DropDownList>
                                    <%--<asp:SqlDataSource ID="SqlLot1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] Inner Join [Delivery] on Lot.Id=Delivery.Lot_Id where  [Lot].IsDeleted=0 and [Delivery].IsDeleted=0 "></asp:SqlDataSource>--%>
                                    <%--<asp:SqlDataSource ID="SqlLot1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] where  [Lot].IsDeleted=0"></asp:SqlDataSource>--%>
                                </div>
                                <div id="Div3" class="form-group" runat="server">
                                        <label>Lot 2</label><label style="margin-left: 30px"><asp:Label ID="lblLot2Pcs" runat="server"></asp:Label><asp:Label ID="lblLot2Sqft" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="ddlLot2" DataTextField="Name" DataValueField="Id" class="form-control" runat="server" Style="display: block; width: 100%; height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555; background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075); box-shadow: inset 0 1px 1px rgba(0,0,0,.075); -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s; -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;"></asp:DropDownList>
                                        <%--<asp:SqlDataSource ID="SqlLot2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] Inner Join [Delivery] on Lot.Id=Delivery.Lot_Id where  [Lot].IsDeleted=0 and [Delivery].IsDeleted=0 "></asp:SqlDataSource>--%>
                                        <%--<asp:SqlDataSource ID="SqlLot2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] where  [Lot].IsDeleted=0"></asp:SqlDataSource>--%>
                                    
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
    <script src="../js/MyJs/Style2.js"></script>
    <script>
        var txtName = '<%= txtName.ClientID %>';
        var txtDescription = '<%= txtDescription.ClientID %>';
        var ddlLot2 = '<%= ddlLot2.ClientID %>';
        var hfId = '<%= hfId.ClientID %>';
        var hfIndex = '<%= hfIndex.ClientID %>';
        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>

</asp:Content>
