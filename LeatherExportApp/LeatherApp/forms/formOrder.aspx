<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formOrder.aspx.cs" Inherits="LeatherExportApp.forms.formOrder" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblMessage.ClientID %>").style.display = "none";

            }, seconds * 1000);
        };

    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Form Order</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Enter Details
                       
                    </div>
                    <div class="panel-body">
                        <div>
                            <asp:Label Font-Size="Medium" runat="server" ID="lblMessage"></asp:Label>
                        </div>
                        <div class="row">

                            <div class="col-lg-12">
                                <div class="form-group">
                                    <label>Vendor</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlVendor" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlVendor" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Vendor.Id,Name FROM [Vendor] where  [Vendor].IsDeleted=0 "></asp:SqlDataSource>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Order No<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtOrderNo" required="required" class="form-control" placeholder="insert Standard Value..." runat="server"></asp:TextBox>
                                </div>
                                
                                <div id="Div3" class="form-group input-group">
                                    <span id="Span1" class="input-group-addon">Date<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtDate" required="required" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                    <asp:CalendarExtender
                                        ID="CalendarExtender2"
                                        Format="MM/dd/yyyy"
                                        TargetControlID="txtDate"
                                        runat="server" />
                                </div>
                                <div class="form-group input-group">
                                    <span id="Span6" class="input-group-addon">Description</span>
                                    <asp:TextBox ID="txtDescription" class="form-control" placeholder="insert description..." runat="server"></asp:TextBox>
                                </div>

                                </div>

                            <div class="col-lg-12">
                                <asp:Button ID="btnSubmit" class="btn btn-lg btn-default center-block" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
