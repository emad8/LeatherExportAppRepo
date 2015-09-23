<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formCompany.aspx.cs"
    Inherits="LeatherExportApp.forms.formCompany" %>

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
                <h1
                    class="page-header">Form Company</h1>
            </div>
            <!-- /.col-lg-12 -->
            <div>
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
            </div>
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


                                <div
                                    class="form-group input-group">
                                    <span class="input-group-addon">Company Number</span>
                                    <asp:TextBox ID="Name" class="form-control" placeholder="insert Company number..."
                                        runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group input-group">
                                    <span class="input-group-addon">Description</span>
                                    <asp:TextBox ID="Description" class="form-control"
                                        placeholder="insert description..." runat="server"></asp:TextBox>
                                </div>

                                <asp:Button ID="Button1" runat="server" class="btn btn-default" Text="Button" OnClick="Button1_Click1" />

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
