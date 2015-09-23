<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formOrderInfo.aspx.cs" Inherits="LeatherExportApp.forms.formOrderInfo" %>

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
                <h1 class="page-header">Form Order Info</h1>
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
                                    <label>Order</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlOrder" DataTextField="Order_No" DataValueField="Id" required="required" class="form-control" runat="server"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlOrder" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Order].Id,Order_No FROM [Order] where  [Order].IsDeleted=0 "></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label>Style</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlStyle" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" ></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlStyle" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Style.Id,Name FROM [Style] where  [Style].IsDeleted=0 "></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label>Size</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlSize" DataTextField="No" DataValueField="Id" required="required" class="form-control" runat="server" ></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlSize" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Size.Id,No FROM [Size] where  [Size].IsDeleted=0 "></asp:SqlDataSource>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">No Of Orders<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtNoOfOrders" required="required" class="form-control" placeholder="insert Standard Value..." runat="server"></asp:TextBox>
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
