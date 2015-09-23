<%@ Page Title="Log in" Language="C#" MasterPageFile="~/MasterAccount.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LeatherExportApp.Account.Login" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    

    <asp:Login ID="Login1" runat="server" ViewStateMode="Disabled" RenderOuterTable="false">

        <LayoutTemplate>
            <p class="error">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
            <fieldset>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" placeholder="User Name" required="required" runat="server" ID="UserName" autofocus />
                </div>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" TextMode="Password" placeholder="Password" required="required" runat="server" ID="Password" />
                </div>

                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">

                            <asp:Label ID="Label3" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                Remember me?</asp:Label>
                           

                        </div>
                    </div>
                    <div class="col-xs-4">
                        <asp:Button ID="Button1" CssClass="btn btn-primary btn-block btn-flat" runat="server" CommandName="Login" Text="Sign In" />
                    </div>
                </div>

            </fieldset>
        </LayoutTemplate>
    </asp:Login>
    <p>
        <%--<asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
        if you don't have an account.--%>
                <br />
        Forget Your Password?
                <asp:HyperLink runat="server" ID="ForgetPasswordHyperlink" ViewStateMode="Disabled">Click Here</asp:HyperLink>
    </p>




</asp:Content>
