<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formMarket.aspx.cs" Inherits="LeatherExportApp.forms.formMarket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        #widthOuter {
            width: 100%;
        }

        #widthInner {
            width: 95px;
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
                <h1 class="page-header">Form Market</h1>
            </div>
            <!-- /.col-lg-12 -->

        </div>
        <!-- /.row -->
        <div class="row">
            <div
                class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Enter Details
                       
                    </div>
                    <div
                        class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="center-block">
                                    <asp:Label Font-Size="Medium" runat="server" ID="lblMessage"></asp:Label>
                                </div>

                                <div id="widthOuter" class="form-group input-group">
                                    <span id="widthInner" class="input-group-addon">Market <label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="Name" required="required" class="form-control" placeholder="insert Market number..."
                                        runat="server"></asp:TextBox>
                                </div>

                                <div id="Div1" class="form-group input-group">
                                    <span id="Span1" class="input-group-addon">Description</span>
                                    <asp:TextBox ID="Description" class="form-control"
                                        placeholder="insert description..." runat="server"></asp:TextBox>
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
