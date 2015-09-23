<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formStitching.aspx.cs" Inherits="LeatherExportApp.forms.formStitching" %>

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
                <h1 class="page-header">Form Stitching</h1>
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
                            <asp:HiddenField ID="HiddenField4" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <div id="Div1" class="form-group" runat="server">
                                        <label>Stitcher</label><label style="color: red;"> *</label>
                                        <asp:DropDownList ID="ddlStitcher" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStitcher_SelectedIndexChanged"></asp:DropDownList>
                                        <%--<asp:SqlDataSource ID="sqlStitcher" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Employee.Id,Employee.Name FROM [Employee] Inner Join Category on Employee.Category=Category.Id where Category.Id=2 and Employee.IsDeleted=0 and Category.IsDeleted=0"></asp:SqlDataSource>--%>
                                    </div>
                                    
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
                                </div>
                                <div class="col-lg-6">
                                    <div id="Div2" class="form-group" runat="server">
                                        <label>Contractor</label><label style="color: red;"> *</label>
                                        <asp:DropDownList ID="ddlContractor" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server"></asp:DropDownList>
                                        <asp:SqlDataSource ID="sqlContractor" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Contractor.Id,Contractor.Name FROM [Contractor] where Contractor.IsDeleted=0"></asp:SqlDataSource>
                                    </div>
                                    <div id="Div3" class="form-group input-group">
                                        <span id="Span1" class="input-group-addon">Select Date of Issuance<label style="color: red;"> *</label></span>
                                        <asp:RadioButtonList required="required" AutoPostBack="true" DataTextField="Date_Issued" DataValueField="Date_Issued" ID="rblDateOfIssuance" runat="server" OnSelectedIndexChanged="rblDateOfIssuance_SelectedIndexChanged"></asp:RadioButtonList>
                                    </div>
                                    <div id="widthOuter" class="form-group input-group">
                                        <span id="widthInner" class="input-group-addon">Pairs<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtPairs" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pairs..." runat="server"></asp:TextBox>
                                    </div>

                                    <div id="widthOuter" class="form-group input-group">
                                        <span id="widthInner" class="input-group-addon">Date<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtDate" required="required" class="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                                        <asp:CalendarExtender
                                            ID="CalendarExtender2"
                                            Format="MM/dd/yyyy"
                                            TargetControlID="txtDate"
                                            runat="server" />
                                    </div>
                                    <div id="widthOuter" class="form-group input-group">
                                        <span id="widthInner" class="input-group-addon">Description</span>
                                        <asp:TextBox ID="txtDescription" class="form-control" placeholder="insert desc..." runat="server"></asp:TextBox>
                                    </div>

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
