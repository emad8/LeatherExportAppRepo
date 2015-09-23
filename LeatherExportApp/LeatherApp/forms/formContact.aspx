<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formContact.aspx.cs" Inherits="LeatherApp.forms.formContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style>
        #example_paginate ul, #example_filter label {
            float: right;
            margin: 0px;
        }

        #tblmodal tr td {
            padding: 2px;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Contact Info</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        View Contact Info

                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%" id="example">
                                <thead>
                                    <tr>
                                        <th>Customer Code</th>
                                        <th>Customer Name</th>
                                        <th>Name</th>
                                        <th>Tel No</th>
                                        <th>Extention No</th>
                                        <th>Mob No</th>
                                        <th>Designation</th>
                                        <th>Email</th>
                                        <th>Remarks</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Customer Code</th>
                                        <th>Customer Name</th>
                                        <th>Name</th>
                                        <th>Tel No</th>
                                        <th>Extention No</th>
                                        <th>Mob No</th>
                                        <th>Designation</th>
                                        <th>Email</th>
                                        <th>Remarks</th>
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
                <button type="button" id="btnAdd" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add Contact Info</button>

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Contact</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <table id="tblmodal">
                                    <tr>
                                        <td>Customer Code and Name<label style="color: red;"> *</label></td>
                                        <td style="width: 73%">
                                            <asp:DropDownList ID="ddlCus" DataTextField="Name" DataValueField="ID" class="form-control" runat="server"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlCus" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Customer_Info.ID, CONCAT( Code,'--',Name) as Name FROM [Customer_Info] where  [Customer_Info].IsDeleted=0"></asp:SqlDataSource>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNav" runat="server" class="btn btn-default" Text=". . ." OnClick="btnNav_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Name<label style="color: red;"> *</label>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtName" class="form-control" placeholder="insert Name..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tel No<%--<label style="color: red;"> *</label>--%>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtTN" class="form-control" placeholder="insert Tel No..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>Extention No
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtEN" class="form-control" placeholder="insert Extention No..."></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Mob No
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtMN" class="form-control" placeholder="insert Mob No..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Designation
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtDes" class="form-control" placeholder="insert Designation..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>Email
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="insert Email..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Remarks
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtRemarks" class="form-control" placeholder="insert Remarks..."></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="hfId" Value="" />
                                <asp:HiddenField runat="server" ID="hfNavBack" Value="" />
                                <button id="btnSubmit" onclick="Validate()" type="button" class="btn btn-primary">Submit</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>
    <%--<script src="../js/MyJs/ReloadAjax.js"></script>--%>
    <script src="../js/MyJs/Contact.js"></script>
    <script>
        var ddlCus = '<%= ddlCus.ClientID%>';
        var txtName = '<%= txtName.ClientID%>';
        var txtTN = '<%= txtTN.ClientID %>';
        var txtMN = '<%= txtMN.ClientID %>';
        var txtDes = '<% = txtDes.ClientID %>';
        var txtEN = '<% = txtEN.ClientID%>';
        var txtEmail = '<%= txtEmail.ClientID%>';
        var txtRemarks = '<%= txtRemarks.ClientID %>';
        var hfId = '<%= hfId.ClientID %>';

        var hfNavBack = '<%= hfNavBack.ClientID %>';

        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>



</asp:Content>
