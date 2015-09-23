<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="LeatherExportApp.Account.Manage" %>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=label1.ClientID %>").style.display = "none";
            }, seconds * 1000);
        };
    </script>
    <script>

    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header"><%: Title %></h1>
            </div>
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Enter Details
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <%--<section id="passwordForm">--%>
                                    <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                                        <asp:Label runat="server" ID="label1" CssClass="success"><%: SuccessMessage %></asp:Label>
                                    </asp:PlaceHolder>


                                    <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">

                                        <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                                            <ChangePasswordTemplate>
                                                <span class="error">
                                                    <asp:Literal runat="server" ID="FailureText" />
                                                </span>
                                                <fieldset class="changePassword">


                                                    <div class="form-group input-group">
                                                        <span class="input-group-addon">Current password</span>
                                                        <asp:TextBox ID="CurrentPassword" CssClass="form-control" placeholder="Current password..." TextMode="Password" runat="server" />
                                                        
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CurrentPassword" runat="server" ErrorMessage="Required"  ></asp:RequiredFieldValidator>
                                                    <asp:ModelErrorMessage  runat="server" AssociatedControlID="RequiredFieldValidator1"  />



                                                    <div class="form-group input-group">
                                                        <span class="input-group-addon">New password</span>
                                                        <asp:TextBox ID="NewPassword" CssClass="form-control" placeholder="New password..." TextMode="Password" runat="server" />

                                                    </div>
                                                    <div class="form-group input-group">
                                                        <span class="input-group-addon">Confirm new password</span>
                                                        <asp:TextBox ID="ConfirmNewPassword" CssClass="form-control" placeholder="Confirm new password..." TextMode="Password" runat="server" />


                                                    </div>
                                                    <div>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                            CssClass="error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match." />
                                                        
                                                        
                                                    </div>
                                                    <asp:Button runat="server" CommandName="ChangePassword" Text="Change password" CssClass="btn btn-default" />
                                                </fieldset>
                                            </ChangePasswordTemplate>
                                        </asp:ChangePassword>
                                    </asp:PlaceHolder>
                                    <%--</section>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
