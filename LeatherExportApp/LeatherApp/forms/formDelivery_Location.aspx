﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formDelivery_Location.aspx.cs" Inherits="LeatherApp.forms.formDelivery_Location" %>
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
                <h1 class="page-header">Delivery Location Info</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        View Delivery Location Info

                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%" id="example">
                                <thead>
                                    <tr>
                                        <th>Customer Code</th>
                                        <th>Customer Name</th>
                                        <th>Address</th>
                                        <th>City</th>
                                        <th>Zip/Postal</th>
                                        <th>State/Province</th>
                                        <th>Country</th>
                                        
                                        
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Customer Code</th>
                                        <th>Customer Name</th>
                                        <th>Address</th>
                                        <th>City</th>
                                        <th>Zip/Postal</th>
                                        <th>State/Province</th>
                                        <th>Country</th>
                                        
                                        
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
                <button type="button" id="btnAdd" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add Delivery Location Info</button>

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog ">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Form Delivery Location</h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                                <table id="tblmodal">
                                    <tr>
                                        <td>Customer Code and Name<label style="color: red;"> *</label></td>
                                        <td style="width: 73%">
                                            <asp:DropDownList ID="ddlCus" DataTextField="Name" DataValueField="ID" class="form-control" runat="server"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlCus" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Customer_Info.ID, (Code +' - '+ Name ) as Name FROM [Customer_Info] where  [Customer_Info].IsDeleted=0"></asp:SqlDataSource>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNav" runat="server" class="btn btn-default" Text=". . ." OnClick="btnNav_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Address<label style="color: red;"> *</label>
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
    <script src="../js/MyJs/Delivery_Location.js"></script>
    <script>
        var ddlCus = '<%= ddlCus.ClientID%>';
        var txtAddress = '<%= txtAddress.ClientID%>';
        var txtCity = '<% = txtCity.ClientID %>';
        var txtZP = '<%= txtZP.ClientID %>';
        var txtSP = '<%= txtSP.ClientID %>';
        var txtCountry = '<% = txtCountry.ClientID%>';

        var hfId = '<%= hfId.ClientID %>';

        var hfNavBack = '<%= hfNavBack.ClientID %>';

        var lblMessage = '<%= lblMessage.ClientID %>';
    </script>



</asp:Content>
