<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formWadaGhata.aspx.cs" Inherits="LeatherExportApp.forms.formWadaGhata" %>

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
                <h1 class="page-header">Form WadaGhata</h1>
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
                                    <label>Lot 1</label><label style="color: red;"> *</label><label style="margin-left: 30px"><asp:Label ID="lblLot1Pcs" runat="server"></asp:Label><asp:Label ID="lblLot1Sqft" runat="server"></asp:Label></label>
                                    <asp:DropDownList ID="ddlLot1" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLot1_SelectedIndexChanged"></asp:DropDownList>
                                    <%--<asp:SqlDataSource ID="SqlLot1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] Inner Join [Delivery] on Lot.Id=Delivery.Lot_Id where  [Lot].IsDeleted=0 and [Delivery].IsDeleted=0 "></asp:SqlDataSource>--%>
                                    <%--<asp:SqlDataSource ID="SqlLot1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] where  [Lot].IsDeleted=0"></asp:SqlDataSource>--%>
                                </div>
                                <div id="Div2" class="form-group input-group">
                                    <span id="Span1" class="input-group-addon">Pieces<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtPcs" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pieces..." runat="server"></asp:TextBox>
                                </div>
                                <div id="Div3" class="form-group input-group">
                                    <span id="Span2" class="input-group-addon">SqFt<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtSqFt" onkeyup="ShowAvg()" required="required" class="form-control" onkeypress="return Onlyfloat(event,this);" placeholder="insert SqFt..." runat="server"></asp:TextBox>
                                </div>
                                <div id="divLot2" runat="server">
                                    <div id="Div4" class="form-group" runat="server">
                                        <label>Lot 2</label><label style="margin-left: 30px"><asp:Label ID="lblLot2Pcs" runat="server"></asp:Label><asp:Label ID="lblLot2Sqft" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="ddlLot2" DataTextField="Name" DataValueField="Id" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLot2_SelectedIndexChanged" Style="display: block; width: 100%; height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555; background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075); box-shadow: inset 0 1px 1px rgba(0,0,0,.075); -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s; -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;"></asp:DropDownList>
                                        <%--<asp:SqlDataSource ID="SqlLot2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] Inner Join [Delivery] on Lot.Id=Delivery.Lot_Id where  [Lot].IsDeleted=0 and [Delivery].IsDeleted=0 "></asp:SqlDataSource>--%>
                                        <%--<asp:SqlDataSource ID="SqlLot2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] where  [Lot].IsDeleted=0"></asp:SqlDataSource>--%>
                                    </div>
                                    <div id="Div5" class="form-group input-group">
                                        <span id="Span3" class="input-group-addon">Pieces<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtPcs2" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pieces..." runat="server"></asp:TextBox>
                                    </div>
                                    <div id="Div6" class="form-group input-group">
                                        <span id="Span5" class="input-group-addon">SqFt<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtSqFt2" onkeyup="ShowAvg()" required="required" class="form-control" onkeypress="return Onlyfloat(event,this);" placeholder="insert SqFt..." runat="server"></asp:TextBox>
                                    </div>
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
                                <div class="form-group input-group">
                                    <span id="Span4" class="input-group-addon">Description</span>
                                    <asp:TextBox ID="txtDescription" class="form-control" placeholder="insert description..." runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <asp:Button ID="btnSubmit" class="btn btn-lg btn-default center-block" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button ID="btnLot2" formnovalidate class="btn btn-lg btn-primary center-block" runat="server" Text="Show/Hide Lot2" OnClick="btnLot2_Click" />
                                </div>
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
