<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formEmployee.aspx.cs" Inherits="LeatherExportApp.forms.formEmployee" %>

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
                <h1 class="page-header">Form Employee</h1>
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
                        <div class="center-block">
                            <asp:Label Font-Size="Medium" runat="server" ID="lblMessage"></asp:Label>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Name<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="Name" required="required" class="form-control" placeholder="insert name..." runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Contact Number<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="CN" required="required" class="form-control" placeholder="insert contact number..." runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon">NIC Number<label style="color: red;"> *</label></span>
                                    <asp:TextBox ID="NIC" required="required" class="form-control" placeholder="insert NIC number..." runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" runat="server" id="divCategory">
                                    <label>Category</label><label style="color: red;"> *</label>
                                    <asp:DropDownList ID="ddlCategory" required="required" DataTextField="Name" DataValueField="Id" class="form-control" runat="server" ></asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlCategory" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT Category.Id,Category.Name FROM [Category] where Category.IsDeleted=0"></asp:SqlDataSource>
                                </div>
                                
                                <div class="form-group input-group">
                                    <span class="input-group-addon">Upload Image</span>
                                    <asp:FileUpload ID="FileUpload" Width="100%" class="btn btn-sm btn-default"  runat="server"></asp:FileUpload>
                                </div>
                            </div>
                            <div class="col-lg-offset-1 col-lg-4">
                                <div class="form-group input-group">
                                    <asp:Button ID="ImageUpload" formnovalidate Width="200" class="btn btn-sm btn-primary" runat="server" Text="Upload" OnClick="ImageUpload_Click" />
                                </div>
                                <div class="form-group input-group">
                                    <asp:Image ID="Image1" runat="server" Width="200" Height="200" placeholder="image" />
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
