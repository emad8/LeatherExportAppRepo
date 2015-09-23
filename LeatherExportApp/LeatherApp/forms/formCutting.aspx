<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formCutting.aspx.cs" Inherits="LeatherExportApp.forms.formCutting" %>

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
                <h1 class="page-header">Form Cutting</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Enter Details
                        <span id="spanCuttedPcsSqft" runat="server" style="float: right; margin-right: 20px; margin-left: 20px"></span>
                        <span id="PairAvg" style="float: right"></span>
                        <span id="PcsAvg" style="float: right"></span>
                    </div>
                    <div class="panel-body">
                        <div>
                            <asp:Label Font-Size="Medium" runat="server" ID="lblMessage"></asp:Label>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="HiddenField3" runat="server" />
                        </div>
                        <div class="row">

                            <div class="col-lg-6">
                                <div class="form-group" runat="server" id="divCutter">
                                    <label>Cutter</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlCutter" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCutter_SelectedIndexChanged" Style="display: block; width: 100%; height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555; background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075); box-shadow: inset 0 1px 1px rgba(0,0,0,.075); -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s; -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;"></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlCutter" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Employee.Id,Employee.Name FROM [Employee] Inner Join Category on Employee.Category=Category.Id where Upper(Category.Name) ='CUTTER' and Employee.IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                <div class="form-group" runat="server" id="divCompany">
                                    <label>Company</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlCompany" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" Style="display: block; width: 100%; height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555; background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075); box-shadow: inset 0 1px 1px rgba(0,0,0,.075); -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s; -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlCompany" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Company.Id,Name from Cutting_Outstock Inner Join Company on Cutting_Outstock.Company=Company.Id  where Cutting_Outstock.IsDeleted=0 and Cutting_Outstock.Pcs_Rem>0 and Cutting_Outstock.Sqft_Rem>0 order by Name asc"></asp:SqlDataSource>
                                </div>
                                <div class="form-group" runat="server" id="divMarket">
                                    <label>Market</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlMarket" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMarket_SelectedIndexChanged" Style="display: block; width: 100%; height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555; background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075); box-shadow: inset 0 1px 1px rgba(0,0,0,.075); -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s; -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlMarket" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Id,Name FROM [Market] where Market.IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                <div class="form-group">
                                    <label>Order #</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlOrderNo" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrderNo_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Shipping Date:   </label>
                                    <asp:Label ID="lblShippingDate" runat="server"> </asp:Label>

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
                                    <span id="widthInner" class="input-group-addon">Pairs<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="txtPairs" onkeyup="ShowAvg()" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pairs..." runat="server"></asp:TextBox>
                                </div>


                            </div>


                            <!-- /.col-lg-6 (nested) -->
                            <div class="col-lg-6">
                                <div id="divPcsSqft" runat="server">

                                    <div class="form-group">
                                        <label>Lot 1</label><label style="color: red;"> *</label><label style="margin-left: 30px"><asp:Label ID="lblLot1Pcs" runat="server"></asp:Label><asp:Label ID="lblLot1Sqft" runat="server"></asp:Label></label>
                                        <asp:DropDownList ID="ddlLot1" DataTextField="Name" DataValueField="Id" required="required" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLot1_SelectedIndexChanged"></asp:DropDownList>
                                        <%--<asp:SqlDataSource ID="SqlLot1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] Inner Join [Delivery] on Lot.Id=Delivery.Lot_Id where  [Lot].IsDeleted=0 and [Delivery].IsDeleted=0 "></asp:SqlDataSource>--%>
                                        <%--<asp:SqlDataSource ID="SqlLot1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] where  [Lot].IsDeleted=0"></asp:SqlDataSource>--%>
                                    </div>
                                    <div id="widthOuter" class="form-group input-group">
                                        <span id="widthInner" class="input-group-addon">Pieces<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtPcs" onkeyup="ShowAvg()" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pieces..." runat="server"></asp:TextBox>
                                    </div>
                                    <div id="widthOuter" class="form-group input-group">
                                        <span id="widthInner" class="input-group-addon">SqFt<label style="color: red;"> *</label></span>
                                        <asp:TextBox ID="txtSqFt" onkeyup="ShowAvg()" required="required" class="form-control" onkeypress="return Onlyfloat(event,this);" placeholder="insert SqFt..." runat="server"></asp:TextBox>
                                    </div>

                                    <div id="divLot2" runat="server">
                                        <div class="form-group" runat="server">
                                            <label>Lot 2</label><label style="margin-left: 30px"><asp:Label ID="lblLot2Pcs" runat="server"></asp:Label><asp:Label ID="lblLot2Sqft" runat="server"></asp:Label></label>
                                            <asp:DropDownList ID="ddlLot2" DataTextField="Name" DataValueField="Id" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLot2_SelectedIndexChanged" Style="display: block; width: 100%; height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.42857143; color: #555; background-color: #fff; background-image: none; border: 1px solid #ccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075); box-shadow: inset 0 1px 1px rgba(0,0,0,.075); -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s; -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s; transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;"></asp:DropDownList>
                                            <%--<asp:SqlDataSource ID="SqlLot2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] Inner Join [Delivery] on Lot.Id=Delivery.Lot_Id where  [Lot].IsDeleted=0 and [Delivery].IsDeleted=0 "></asp:SqlDataSource>--%>
                                            <%--<asp:SqlDataSource ID="SqlLot2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT distinct Lot.Id,Name FROM [Lot] where  [Lot].IsDeleted=0"></asp:SqlDataSource>--%>
                                        </div>
                                        <div id="widthOuter" class="form-group input-group">
                                            <span id="widthInner" class="input-group-addon">Pieces<label style="color: red;"> *</label></span>
                                            <asp:TextBox ID="txtPcs2" onkeyup="ShowAvg()" required="required" class="form-control" onkeypress="return OnlyNumbers(event)" placeholder="insert Pieces..." runat="server"></asp:TextBox>
                                        </div>
                                        <div id="widthOuter" class="form-group input-group">
                                            <span id="widthInner" class="input-group-addon">SqFt<label style="color: red;"> *</label></span>
                                            <asp:TextBox ID="txtSqFt2" onkeyup="ShowAvg()" required="required" class="form-control" onkeypress="return Onlyfloat(event,this);" placeholder="insert SqFt..." runat="server"></asp:TextBox>
                                        </div>
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
                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Description</span>
                                    <asp:TextBox ID="txtDescription" class="form-control" placeholder="insert description..." runat="server"></asp:TextBox>
                                </div>
                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Gp #</span>
                                    <asp:TextBox ID="txtGp_No" class="form-control" placeholder="insert Gp #..." runat="server"></asp:TextBox>
                                </div>
                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Remarks</span>
                                    <asp:TextBox ID="txtRemarks" class="form-control" placeholder="insert Remarks..." runat="server"></asp:TextBox>
                                </div>
                                <%--<div class="form-group">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" value="">Is Paid
                                        </label>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="col-lg-12">
                                <div class="col-lg-4">
                                    <asp:Button ID="btnRefresh" formnovalidate class="btn btn-lg btn-primary center-block" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button ID="btnSubmit" class="btn btn-lg btn-default center-block" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button ID="btnLot2" formnovalidate class="btn btn-lg btn-primary center-block" runat="server" Text="Show/Hide Lot2" OnClick="btnLot2_Click" />
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
    </div>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("#btnLot2").click(function () {
                if (document.getElementById('<%= divLot2.ClientID %>').style.display == "none")
                {
                    document.getElementById('<%= divLot2.ClientID %>').style.display = "block";
                }
                else
                {
                    document.getElementById('<%= divLot2.ClientID %>').style.display = "none";
                }
                //document.getElementById('divLot2').style.visibility = !(document.getElementById('divLot2').style.visibility);
            });

        });
    </script>--%>

    <script type="text/javascript">

        function ShowAvg() {
            debugger;
            var x = document.getElementById("PairAvg");
            var y = document.getElementById("PcsAvg");
            var Pairs = document.getElementById('<%= txtPairs.ClientID %>');
            var Footing1 = document.getElementById('<%= txtSqFt.ClientID %>');
            var Footing2 = document.getElementById('<%= txtSqFt2.ClientID %>');
            var Pieces = document.getElementById('<%= txtPcs.ClientID %>');
            var Pieces2 = document.getElementById('<%= txtPcs2.ClientID %>');

            if (isNaN(Footing2)) {
                var Pairsavg = (Number(Footing1.value) + Number(Footing2.value)) / Number(Pairs.value);
                var Pcsavg = (Number(Footing1.value) + Number(Footing2.value)) / (Number(Pieces.value) + Number(Pieces2.value));
            }
            else {
                var Pairsavg = (Number(Footing1.value)) / Number(Pairs.value);
                var Pcsavg = (Number(Footing1.value)) / Number(Pieces.value);
            }

            x.innerHTML = 'Pairs Avg : ' + parseFloat(Pairsavg).toFixed(2) + '&nbsp;';
            y.innerHTML = 'Pcs Avg : ' + parseFloat(Pcsavg).toFixed(2) + '&nbsp;&nbsp;&nbsp;';

            
        }

    </script>
</asp:Content>
