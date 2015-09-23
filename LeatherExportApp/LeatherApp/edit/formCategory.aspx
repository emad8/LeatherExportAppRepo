<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formCategory.aspx.cs" Inherits="LeatherExportApp.edit.formCategory" %>

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
                                        <th>Name</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Name</th>
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
                                <h4 class="modal-title">Form Category</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Category</span>
                                    <asp:TextBox runat="server" ID="txtName" required="required" class="form-control" placeholder="insert Category..."></asp:TextBox>
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
    <script src="../js/MyJs/Category.js"></script>
    <script>
        var txtName = '<%= txtName.ClientID %>';
        var hfId = '<%= hfId.ClientID %>';
        var hfIndex = '<%= hfIndex.ClientID %>';
        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>

</asp:Content>
