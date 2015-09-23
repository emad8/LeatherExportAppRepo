<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formCustomer_Info.aspx.cs" Inherits="LeatherExportApp.edit.formCustomer_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        #example_paginate ul, #example_filter label {
            float: right;
            margin: 0px;
        }

        #tblmodal tr td {
            padding: 2px;
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
                <h1 class="page-header">Customer Info</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        View Customer Info

                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%" id="example">
                                <thead>
                                    <tr>
                                        <th>Code</th>
                                        <th>Name</th>
                                        <th>Address</th>
                                        <th>City</th>
                                        <th>Zip/Postal</th>
                                        <th>State/Province</th>
                                        <th>Country</th>
                                        <th>Phone #</th>
                                        <th>Fax</th>
                                        <%--<th>CreatedBy</th>
                                        <th>CreatedDate</th>
                                        <th>UpdateBy</th>
                                        <th>UpdateDate</th>--%>
                                        <%--<th>Add</th>--%>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Code</th>
                                        <th>Name</th>
                                        <th>Address</th>
                                        <th>City</th>
                                        <th>Zip/Postal</th>
                                        <th>State/Province</th>
                                        <th>Country</th>
                                        <th>Phone #</th>
                                        <th>Fax</th>
                                        <%--<th>CreatedBy</th>
                                        <th>CreatedDate</th>
                                        <th>UpdateBy</th>
                                        <th>UpdateDate</th>--%>
                                        <%--<th>Add</th>--%>
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
                <button type="button" id="btnAdd" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add Customer Info</button>

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Customer Info</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <table id="tblmodal">
                                    <tr>
                                        <td>Code<label style="color: red;"> *</label>
                                        </td>
                                        <td style="width:100%">
                                            <asp:TextBox runat="server" ID="txtCode" class="form-control" placeholder="insert Code..."></asp:TextBox>
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
                                        <td>Address
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtAddress" class="form-control" placeholder="insert Address..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>City
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCity" class="form-control" placeholder="insert City..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Zip/Postal
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtZP" class="form-control" placeholder="insert Zip/Postal..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>State/Province
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSP" class="form-control" placeholder="insert State/Province..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Country
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCountry" class="form-control" placeholder="insert Country..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Phone #
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPhone" class="form-control" placeholder="insert Phone #..."></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fax
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtFax" class="form-control" placeholder="insert Fax..."></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <asp:HiddenField runat="server" ID="hfId" Value="" />
                                <asp:HiddenField runat="server" ID="hfNav" Value="" />
                                <%--<button id="btnSubmit" onclick="Submit()" type="button" class="btn btn-primary">Submit</button>--%>
                                <asp:Button ID="btnSubmit" OnClientClick="return Validate()" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>
    <%--<script src="../js/MyJs/ReloadAjax.js"></script>--%>
    <script src="../js/MyJs/Customer_Info.js"></script>
    <script>
        var txtCode = '<%= txtCode.ClientID%>';
        var txtName = '<%= txtName.ClientID %>';
        var txtCity = '<%= txtCity.ClientID %>';
        var txtAddress = '<%= txtAddress.ClientID %>';
        var txtZP = '<% = txtZP.ClientID %>';
        var txtSP = '<% = txtSP.ClientID%>';
        var txtCountry = '<%= txtCountry.ClientID %>';
        var txtPhone = '<%= txtPhone.ClientID%>';
        var txtFax = '<%= txtFax.ClientID %>';

        var hfId = '<%= hfId.ClientID %>';
        var hfNav = '<%= hfNav.ClientID %>';

        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>

</asp:Content>
