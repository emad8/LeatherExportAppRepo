<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formPacking.aspx.cs" Inherits="LeatherExportApp.forms.formPacking" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


    <style>
        #widthOuter {
            width: 100%;
        }

        #widthInner {
            width: 95px;
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
    </style>
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
                <h1 class="page-header">Form Packing</h1>
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
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="HiddenField3" runat="server" />
                        </div>
                        <div class="row">

                            <div class="col-lg-12">
                                <%--<div class="form-group" runat="server">
                                    <label>Packer</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlPacker" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" ></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlPacker" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Employee.Id,Employee.Name FROM [Employee] Inner Join Category on Employee.Category=Category.Id where Category.Id=3 and Employee.IsDeleted=0 and Category.IsDeleted=0"></asp:SqlDataSource>
                                </div>--%>
                                
                                <div class="form-group">
                                    <label>Order #</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlOrderNo" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrderNo_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Style</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlStyle" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStyle_SelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="form-group">
                                    <label>Size</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlSize" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSize_SelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Pairs Packed<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtPairs" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pairs..." runat="server"></asp:TextBox>
                                </div>
                                <div  class="form-group input-group">
                                <span class="input-group-addon">Date<label style="color: red;"> *</label></span>
                                <asp:TextBox ID="txtDate"  required="required" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                <asp:CalendarExtender
                                        ID="CalendarExtender2"
                                        Format="MM/dd/yyyy"
                                        TargetControlID="txtDate"
                                        runat="server" />
                            </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Description</span>
                                    <asp:TextBox ID="txtDescription" class="form-control" placeholder="insert desc..." runat="server"></asp:TextBox>
                                </div>
                                
                            </div>


                            <div class="col-lg-6">
                                <asp:Button ID="btnRefresh" formnovalidate class="btn btn-lg btn-primary center-block" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                                
                            </div>
                            <div class="col-lg-6">
                                
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
