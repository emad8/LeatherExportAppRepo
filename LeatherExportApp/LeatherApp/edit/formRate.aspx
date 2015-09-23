<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formRate.aspx.cs" Inherits="LeatherExportApp.edit.formRate" %>

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
                                        <th>Standard Value</th>
                                        <th>Style</th>
                                        <th>Size</th>
                                        <th>Cutting Rate</th>
                                        <th>Elastic Stitching</th>
                                        <th>Over Lock</th>
                                        <th>Contractor Commission</th>
                                        <th>Binding Rate</th>
                                        <th>GloveStitching Rate</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Standard Value</th>
                                        <th>Style</th>
                                        <th>Size</th>
                                        <th>Cutting Rate</th>
                                        <th>Elastic Stitching</th>
                                        <th>Over Lock</th>
                                        <th>Contractor Commission</th>
                                        <th>Binding Rate</th>
                                        <th>GloveStitching Rate</th>
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
                <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>
                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Rate</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Standard Value</span>
                                    <asp:TextBox runat="server" ID="txtSV" required="required" class="form-control" placeholder="insert Standard Value..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Cutting Rate</span>
                                    <asp:TextBox runat="server" ID="txtCR" class="form-control" placeholder="insert Cutting Rate..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Elastic Stitching</span>
                                    <asp:TextBox runat="server" ID="txtES" required="required" class="form-control" placeholder="insert Elastic Stitching..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Over Lock</span>
                                    <asp:TextBox runat="server" ID="txtOL" class="form-control" placeholder="insert description..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Contractor Commission</span>
                                    <asp:TextBox runat="server" ID="txtCC" required="required" class="form-control" placeholder="insert Over Lock..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Binding Rate</span>
                                    <asp:TextBox runat="server" ID="txtBR" class="form-control" placeholder="insert Binding Rate..."></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Glove Stitching Rate</span>
                                    <asp:TextBox runat="server" ID="txtGSR" class="form-control" placeholder="insert Glove Stitching Rate..."></asp:TextBox>
                                </div>
                                
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Style</span>
                                    <asp:DropDownList ID="ddlStyle" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlStyle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Style.Id,Name FROM [Style] where  [Style].IsDeleted=0 "></asp:SqlDataSource>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Size</span>
                                    <asp:DropDownList ID="ddlSize" DataTextField="No" DataValueField="Id" required="required" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlSize" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Size.Id,No FROM [Size] where  [Size].IsDeleted=0 "></asp:SqlDataSource>
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
    <script src="../js/MyJs/Rate.js"></script>
    <script>
        var txtSV = '<%= txtSV.ClientID %>';
        var txtCR = '<%= txtCR.ClientID %>';
        var txtES = '<% = txtES.ClientID%>';
        var txtOL = '<% = txtOL.ClientID%>';
        var txtCC = '<% = txtCC.ClientID%>';
        var txtBR = '<% = txtBR.ClientID%>';
        var txtGSR = '<% = txtGSR.ClientID%>';
        var ddlStyle = '<% = ddlStyle.ClientID%>';
        var ddlSize = '<% = ddlSize.ClientID%>';
        var hfId = '<%= hfId.ClientID %>';
        var hfIndex = '<%= hfIndex.ClientID %>';
        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>

</asp:Content>
